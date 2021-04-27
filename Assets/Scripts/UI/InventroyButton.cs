using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventroyButton : MonoBehaviour
{
    public Image image;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            OpenInventroy();
        }
    }
    public void OpenInventroy()
    {
        if(image.enabled == true)
        {
            image.enabled = false;
        }
        else
        {
            image.enabled = true;
        }
    }
}
