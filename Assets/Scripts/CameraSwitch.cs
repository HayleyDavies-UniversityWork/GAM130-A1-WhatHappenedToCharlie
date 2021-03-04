using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour {
    //Camera object which is being used at the moment
    public GameObject CurrentCamera;

    //Camera array list which should include both cameras
    public GameObject[] Cameras = new GameObject[2];

    //Event handler which triggers fucntions when camera being switched (eg ItemSwap.cs)
    public GameObject EventHandler;

    //Fucntion for switching camera forth
    private void NextCameraSwitch() {
        Cameras[0].SetActive(false);
        Cameras[1].SetActive(true);
        CurrentCamera = Cameras[1];
    }
    //Fucntion for switching camera back
    private void PreviousCameraSwitch() {
        Cameras[1].SetActive(false);
        Cameras[0].SetActive(true);
        CurrentCamera = Cameras[0];
    }

    //Function being called when Player goes through Collider
    private void OnTriggerExit(Collider col) {

        if (col.gameObject.CompareTag("Player")) {
            //Detecting to which camera next switch should be
            if (CurrentCamera == Cameras[1]) {
                PreviousCameraSwitch();
            } else {
                NextCameraSwitch();
            }

            //TEST: When player leaves Bedroom items will be swapped
            if (CurrentCamera.name != "BedroomCamera") {
                EventHandler.GetComponent<ItemSwap>().SwapItems();
            }
        }

    }

}