using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public Transform camTarget;

    public Camera startCamera;
    List<Camera> cameras;

    // Start is called before the first frame update
    void Start() {
        cameras = new List<Camera>(FindObjectsOfType<Camera>());

        foreach (Camera c in cameras) {
            if (c.enabled == true) {
                startCamera = c;
                break;
            }
        }

        // WE DO THIS BECAUSE DUMB ASS REASONS - CAMERA BOUNCES IF NOT ?!?!?!
        startCamera.gameObject.SetActive(false);
        startCamera.gameObject.SetActive(true);
    }

    // Update is called once per frame

    private void FixedUpdate() {
        foreach (Camera c in cameras) {
            c.transform.forward = camTarget.transform.position - c.transform.position;
        }
    }
}