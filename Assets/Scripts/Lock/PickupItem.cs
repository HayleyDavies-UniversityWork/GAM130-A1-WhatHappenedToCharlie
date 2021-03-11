using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventorySystem;

public class PickupItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "InventoryItem")
        {
            InventoryObject inventoryObject = other.GetComponent<InventoryObject>();
            Inventory.Add(inventoryObject.item);
            Debug.Log("its all brians fault");
            Destroy(other.gameObject);
        }
    }
}
