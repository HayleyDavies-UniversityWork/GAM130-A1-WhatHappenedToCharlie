using System.Collections;
using System.Collections.Generic;
using ClickPuzzle;
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

        // Start is called before the first frame update
        void Start() {
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
            // get the item
            InventoryItem item = GetComponent<InventoryObject>().item;
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
            puzzle = Instantiate(TornPaper);
            puzzle.transform.parent = transform;
        }

        public void OpenClickPuzzle() {
            puzzleCamera.GetComponent<ClickPuzzle.ClickPuzzle>().StartPuzzle(gameObject);
        }
    }
}