using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Togglelight : MonoBehaviour {

    public GameObject UVflashlight;
    public GameObject UVflashlight2;
    public GameObject Markings;
    public GameObject Markings2;
    public GameObject Markings3;
    public GameObject Markings4;
    public GameObject Markings5;
    public GameObject Markings6;
    public GameObject Markings7;
    public GameObject Markings8;
    public bool on = false;

    void Start() {
        //Toggle f key 
        //enable uvflashlight
        //enable markings
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.F) && !on) {
            UVflashlight.SetActive(true);
            UVflashlight2.SetActive(true);
            Markings.SetActive(true);
            Markings2.SetActive(true);
            Markings3.SetActive(true);
            Markings4.SetActive(true);
            Markings5.SetActive(true);
            Markings6.SetActive(true);
            Markings7.SetActive(true);
            on = true;
        } else if (Input.GetKeyDown(KeyCode.F) && on) {
            UVflashlight.SetActive(false);
            UVflashlight2.SetActive(false);
            Markings.SetActive(false);
            Markings2.SetActive(false);
            Markings3.SetActive(false);
            Markings4.SetActive(false);
            Markings5.SetActive(false);
            Markings6.SetActive(false);
            Markings7.SetActive(false);
            on = false;
        }
    }
}