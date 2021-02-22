using System.Collections;
using System.Collections.Generic;
using InventorySystem;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour {
    private Collider currentCollider;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        // if the interact button is pressed
        if (Input.GetButtonUp("Interact")) {
            // run the interaction script
            Interact();
        }
    }

    /// <summary>
    /// Interact handles the interactions of the player
    /// </summary>
    void Interact() {
        // if the current collider has been set
        if (currentCollider != null) {
            // get the tag of the collider
            string tag = currentCollider.tag;

            // test the tag
            switch (tag) {
                case "InventoryItem":
                    // if tag is "InventoryItem"
                    // run the InventoryInteraction function
                    InventoryInteraction();
                    break;
                default:
                    // if the tag doesn't exist
                    // log a warning that the tag doesn't exist
                    Debug.LogWarning($"Interaction for {tag} doesn't exist! Make sure this is added in PlayerInteractions.cs");
                    break;
            }
        }
    }

    /// <summary>
    /// InventoryInteraction handles interactions with inventory items
    /// </summary>
    void InventoryInteraction() {
        // get the item
        InventoryItem item = currentCollider.GetComponent<InventoryObject>().item;
        // add the item to the inventory
        Inventory.Add(item);
        // destory the collider object
        Destroy(currentCollider.gameObject);
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other) {
        // set the current collider collider triggered
        currentCollider = other;
    }

    /// <summary>
    /// OnTriggerExit is called when the Collider other has stopped touching the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerExit(Collider other) {
        // if the player exits the currentCollider
        if (currentCollider == other) {
            // set the currentCollider to null
            currentCollider = null;
        }
    }
}