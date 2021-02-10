using System.Collections;
using System.Collections.Generic;
using InventorySystem;
using UnityEngine;

namespace InteractionSystem {
    public enum InteractionType {
        Inventory
    }

    public class Interactable : MonoBehaviour {

        public InteractionType interactionType = InteractionType.Inventory;

        public delegate void Interact(GameObject self);
        public Interact interact = null;

        // Start is called before the first frame update
        void Start() {
            switch (interactionType) {
                case InteractionType.Inventory:
                    interact = InventoryInteraction(gameObject);
                    break;
            }
        }

        // Update is called once per frame
        void Update() {

        }

        /// <summary>
        /// InventoryInteraction handles interactions with inventory items
        /// </summary>
        public Interact InventoryInteraction(GameObject self) {
            // get the item
            InventoryItem item = self.GetComponent<InventoryObject>().item;
            // add the item to the inventory
            Inventory.Add(item);
            // destory the collider object
            Destroy(self);

            return null;
        }
    }
}