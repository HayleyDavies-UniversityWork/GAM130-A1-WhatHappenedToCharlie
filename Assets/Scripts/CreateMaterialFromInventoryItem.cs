using System.Collections;
using System.Collections.Generic;
using InventorySystem;
using UnityEngine;

public class CreateMaterialFromInventoryItem : MonoBehaviour {
    private InventoryObject inventoryObject;
    // Start is called before the first frame update
    void Start() {
        inventoryObject = GetComponent<InventoryObject>();
        GetComponent<Renderer>().material.mainTexture = inventoryObject.item.Icon.texture;
    }

    // Update is called once per frame
    void Update() {

    }
}