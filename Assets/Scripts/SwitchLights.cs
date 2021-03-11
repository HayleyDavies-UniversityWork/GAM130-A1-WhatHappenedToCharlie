using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLights : MonoBehaviour
{
    public GameObject[] lights;

    [SerializeField]
    public bool isOn;
    public void LightsOff()
    {
        foreach(var item in lights)
        {
            item.SetActive(false);
        }
        isOn = false;
    }

    public void LightsOn()
    {
        foreach (var item in lights)
        {
            item.SetActive(true);
        }
        isOn = true;
    }
}
