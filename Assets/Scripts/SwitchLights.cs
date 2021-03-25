using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLights : MonoBehaviour
{
    public GameObject[] lights;

    [SerializeField]
    public bool isOn;

    public void Switch()
    {
        if (isOn)
        {
            foreach (var item in lights)
            {
                item.SetActive(false);
            }
            isOn = false;
        }
        else
        {
            foreach (var item in lights)
            {
                item.SetActive(true);
            }
            isOn = true;
        }
    }
}
