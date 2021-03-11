using System.Collections;
using System.Collections.Generic;
using InventorySystem;
using Puzzles;
using UnityEngine;
using UnityEngine.Events;

namespace InteractionSystem {
    public enum InteractionType {
        Pickup,
        OpenPuzzle
    }

    public class Interactable : MonoBehaviour {

        public InteractionType interactionType = InteractionType.Pickup;

        public UnityAction interact;

        public GameObject puzzle;

        // Start is called before the first frame update
        void Start() {
            switch (interactionType) {
                case InteractionType.Pickup:
                    interact += PickupInteraction;
                    break;
                case InteractionType.OpenPuzzle:
                    interact += OpenPuzzleInteraction;
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
            Destroy(this.gameObject);
        }

        void OpenPuzzleInteraction() {
            puzzle.SetActive(true);
        }
    }
}