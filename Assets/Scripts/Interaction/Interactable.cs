using System.Collections;
using System.Collections.Generic;
using ClickPuzzle;
using Fungus;
using InventorySystem;
using Puzzles;
using UnityEngine;
using UnityEngine.Events;

namespace InteractionSystem {
    public enum InteractionType {
        Pickup,
        OpenPuzzle,
        SwitchLights,
        TornPaperPuzzle,
        ClickPuzzle
    }

    public class Interactable : MonoBehaviour {

        public InteractionType interactionType = InteractionType.Pickup;

        public UnityAction interact;

        public GameObject puzzle;

        public GameObject TornPaper;

        public Camera puzzleCamera;

        private Material defaultMaterial;

        // Start is called before the first frame update
        void Start() {
            defaultMaterial = GetComponent<Renderer>().material;
            switch (interactionType) {
                case InteractionType.Pickup:
                    interact += PickupInteraction;
                    break;
                case InteractionType.OpenPuzzle:
                    interact += OpenPuzzleInteraction;
                    break;
                case InteractionType.SwitchLights:
                    interact += SwitchLights;
                    break;
                case InteractionType.TornPaperPuzzle:
                    interact += OpenTornPaperPuzzle;
                    break;
                case InteractionType.ClickPuzzle:
                    interact += OpenClickPuzzle;
                    break;
            }

        }

        /// <summary>
        /// PickupInteraction handles interactions with inventory items
        /// </summary>
        void PickupInteraction() {
            Flowchart flowchart = GameObject.Find("BrainFlowchart").GetComponent<Flowchart>();

            // get the item
            InventoryItem item = GetComponent<InventoryObject>().item;

            flowchart.SetStringVariable("LastItemPickup", item.Name.ToLower());
            Flowchart.BroadcastFungusMessage("PickedUpItem");

            // add the item to the inventory
            Inventory.Add(item);
            // destory the collider object
            FindObjectOfType<InventroyButton>().ReloadItems();
            Destroy(this.gameObject);
        }

        void OpenPuzzleInteraction() {
            puzzle.SetActive(true);
        }

        void SwitchLights() {
            SwitchLights light = GetComponent<SwitchLights>();
            light.Switch();
        }

        public void OpenTornPaperPuzzle() {
            puzzle.GetComponent<Canvas>().enabled = true;
            OpenPuzzleInteraction();
        }

        public void OpenClickPuzzle() {
            puzzleCamera.GetComponent<ClickPuzzle.ClickPuzzle>().StartPuzzle(gameObject, Camera.main);
        }

        public void ResetMaterial() {
            GetComponent<Renderer>().material = defaultMaterial;
        }
    }
}