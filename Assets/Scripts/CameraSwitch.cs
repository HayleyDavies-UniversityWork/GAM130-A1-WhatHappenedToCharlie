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

    //RoomAudio script to tell the audio manager the players location
    public RoomAudio roomAudio;

    //Second trigger which is being used to make sure that player went through the door
    public GameObject Second_Trigger;

    Transform CamTarget;

    void Start() {
        CamTarget = GameObject.Find("CamTarget").GetComponent<Transform>();
    }

    //Fucntion for switching camera 
    private void NextCameraSwitch() {
        Cameras[0].SetActive(false);
        //Cameras[0].GetComponent<RoomAudio>().StopAudio();
        Cameras[1].SetActive(true);
        //Cameras[1].GetComponent<RoomAudio>().PlayAudio();
        CurrentCamera = Cameras[1];
    }

    //Function being called when Player goes through Collider
    private void OnTriggerExit(Collider col) {
        isTriggered Second_Col = Second_Trigger.GetComponent<isTriggered>();

        if (col.gameObject.name == "Player" && Second_Col.isEntered && col == GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>()) {
            // PLACE YOUT FUNCTIONS HERE XAV!!!!
            NextCameraSwitch();

            //Debug.Log("TEST");
            //TEST: When player leaves Bedroom items will be swapped
            if (CurrentCamera.name != "BedroomCamera") {
                EventHandler.GetComponent<ItemSwap>().SwapItems();
            }
        }
    }
    private void FixedUpdate() {
        transform.LookAt(CamTarget.transform);
    }

}