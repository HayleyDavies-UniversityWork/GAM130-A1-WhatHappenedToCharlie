using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InventorySystem;

public class InventroyButton : MonoBehaviour
{
    public GameObject image;
    public List<Image> images;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            OpenInventroy();
        }
    }
    public void OpenInventroy()
    {
        if(image.activeInHierarchy)
        {
            image.SetActive(false);
        }
        else
        {
            image.SetActive(true);
        }
        int pos = 0;
        foreach (var item in Inventory.Contents)
        {
            images[pos].sprite = item.Value.Icon;
            pos++;
        }
    }
}
