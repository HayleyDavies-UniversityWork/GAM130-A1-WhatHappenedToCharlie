using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSwap : MonoBehaviour
{
    //Initial item which we will be swapping
    public GameObject[] StartItems;

    //Item which will replace initial one
    public GameObject[] SwapItem;
   

    public void SwapItems()
    {
            

        //GameObject SwappedItem = Instantiate(SwapItem) as GameObject;

        //SwappedItem.transform.position = StartItem.transform.position;

        //Destroy(StartItem);
            
        for (int i = 0; i < StartItems.Length; i++)
        {
            if (StartItems[i] != null)
            {
                GameObject SwappedItem = Instantiate(SwapItem[i]) as GameObject;
                SwappedItem.transform.position = StartItems[i].transform.position;
                Destroy(StartItems[i]);
            }
        }

    }
}

