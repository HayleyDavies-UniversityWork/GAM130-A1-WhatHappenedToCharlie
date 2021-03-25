using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Togglelight : MonoBehaviour { 



    public GameObject UVflashlight;
    public GameObject Markings;
    private bool on = false;

    
    void Start()
    {
        //Toggle f key 
        //enable uvflashlight
        //enable markings
    }

  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !on)
        {
            UVflashlight.SetActive(true);
            Markings.SetActive(true);
            on = true;
        }
        else if (Input.GetKeyDown(KeyCode.F) && on)
        {
            UVflashlight.SetActive(false);
            Markings.SetActive(false);
            on = false;
        }
    }
}
