using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraSwitch : MonoBehaviour
{
    public GameObject CurrentCamera;
    public GameObject[] Cameras;

    private void NextCameraSwitch()
    {
        Cameras[0].SetActive(false);
        Cameras[1].SetActive(true);
        CurrentCamera = Cameras[1];
    }
    private void PreviousCameraSwitch()
    {
        Cameras[1].SetActive(false);
        Cameras[0].SetActive(true);
        CurrentCamera = Cameras[0];
    }
    private void OnTriggerExit(Collider col)
    {

        if (col.gameObject.CompareTag("Player"))
        {
            if(CurrentCamera == Cameras[1])
            {
                PreviousCameraSwitch();
            }
            else
            {
                NextCameraSwitch();
            }
        }
        
    }


}