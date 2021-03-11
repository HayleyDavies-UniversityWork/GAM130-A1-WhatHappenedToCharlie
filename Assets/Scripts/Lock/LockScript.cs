using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventorySystem;

public class LockScript : MonoBehaviour
{

    public bool isLocked = true;
    public GameObject Door;
    public InventoryItem Key;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Inventory.ItemExists(Key.Name))
        {
            UnlockDoor();
        }


    }

    public void UnlockDoor()
    {
        Door.GetComponent<BoxCollider>().enabled = false;
    }

    public void LockDoor()
    {
        Door.GetComponent<BoxCollider>().enabled = true;
    }


}
