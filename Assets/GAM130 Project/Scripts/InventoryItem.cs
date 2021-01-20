using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem {
    [CreateAssetMenu(fileName = "InventoryItem", menuName = "Inventory/Inventory Item", order = 1)]
    public class InventoryItem : ScriptableObject {

        // name of the item
        public string Name;

        // short description of the item
        public string Description;

        // icon for the item
        public Texture Icon;

        // how to declare a new Item()
        public InventoryItem(string name, string description, Texture icon) {
            Icon = icon;
            Name = name;
            Description = description;
        }
    }
}