// ###########################################################################
//=================================
// PickupItem.cs
// By Paul Hedley: 05/02/2020
//=================================
// Attatch this to item prefabs that the player picks up.
// Make sure the prefab is on the "Player Trigger" layer 
// so only the player controller can trigger it.
// When the trigger is entered, this script will send a message to Fungus.
// A Fungus Flowchart listening for the "pickupMessage" will deal with what
// happens when the item is collected.
// ###########################################################################
using UnityEngine;
using Fungus;

public class PickupItem : MonoBehaviour
{
    public string pickupMessage = "PickupQuestItem";

    // This script needs the renderer and collider components attached to the Pickup Object so it can control them.
    Collider col;
    public Renderer ren;

    private void Start()
    {
        //Get references to the components this script needs and setup ttheir initial values.

        col = GetComponent<Collider>();
        //ren = GetComponent<Renderer>();

        col.enabled = true;
        ren.enabled = true;
    }

    // If the layers, physics and objects are setup correctly, only the player object should trigger this method.
    private void OnTriggerEnter(Collider other)
    {
        // Disable the collider immediately to prevent this method triggering again.
        // Additional behaviours such as animation will last more than one frame.
        col.enabled = false;
        // Broadcast the Fungus Message.  Any Flowcharts listening for the pickupMessage will run.
        Flowchart.BroadcastFungusMessage(pickupMessage);

        // We could add other things like triggering a particle system, sound effect or game logic.
        // These behaviours could be handled by a flowchart listening for the above message Flowchart.BroadcastFungusMessage(pickupMessage);
        // but we have the option of making them happen here using script instead.

        // Instead of destroying the item, we are just going to disable the collider and renderer.
        // Objects like this are often spawned using another system, might be referenced by other things in the scene
        // or might be a part of an object pool.
        ren.enabled = false;
    }
}
