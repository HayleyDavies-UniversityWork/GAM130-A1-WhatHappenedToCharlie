using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public Dictionary<string, Item> inventory;

    // Start is called before the first frame update
    void Start()
    {
        inventory = new Dictionary<string, Item>();
    }

    public void AddItemToDictionary(Item item)
    {
        inventory.Add(item.Name, item);
    }

    public bool ItemExists(string itemName)
    {
        if (inventory.ContainsKey(itemName))
        {
            return true;
        }
        return false;
    }

    public void Remove(string itemName)
    {
        inventory.Remove(itemName);
    }

    [CreateAssetMenu(fileName = "Inventory Item", menuName = "Inventory/Item", order = 1)]
    public class Item : ScriptableObject
    {
        public Image Icon { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Item(string name, string description, Image icon)
        {
            Icon = icon;
            Name = name;
            Description = description;
        }
    }
}