using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// namespace to control the inventory system
/// </summary>
namespace InventorySystem {
    /// <summary>
    /// this class controls how the inventory system works
    /// </summary>
    public static class Inventory {
        // a dictionary to store the inventory items
        public static Dictionary<string, InventoryItem> Contents = new Dictionary<string, InventoryItem>();

        /// <summary>
        // add an item to the dictionary
        /// </summary>
        /// <param name="item">the item to be added to the inventory</param>
        public static void Add(InventoryItem item) {
            Contents.Add(item.Name, item);
            Debug.Log($"Added: {item.Name}");
        }

        /// <summary>
        // remove an item from the inventory
        /// </summary>
        /// <param name="itemName">the name of the item to remove from the inventory</param>
        public static void Remove(string itemName) {
            if (ItemExists(itemName)) {
                Contents.Remove(itemName);
            }
        }

        /// <summary>
        // check if an item exists within the inventory
        /// </summary>
        /// <param name="itemName">the name of the item to check for</param>
        /// <returns>true or false</returns>
        public static bool ItemExists(string itemName) {
            if (Contents.ContainsKey(itemName)) {
                return true;
            }
            return false;
        }
    }
}