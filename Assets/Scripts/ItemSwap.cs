using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSwap : MonoBehaviour
{
    //Initial item which we will be swapping
    public GameObject StartItem;

    //Item which will replace initial one
    public GameObject SwapItem;
   

    public void SwapItems()
    {
        //Check if the item isn't destroyed
        if (StartItem != null)
        {
            GameObject SwappedItem = Instantiate(SwapItem) as GameObject;

            SwappedItem.transform.position = StartItem.transform.position;

            Destroy(StartItem);

        }
    }





}
