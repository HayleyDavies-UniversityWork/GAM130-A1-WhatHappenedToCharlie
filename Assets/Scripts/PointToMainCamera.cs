﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToMainCamera : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        gameObject.SetActive(false);
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update() {
        if (Camera.main != null) {
            transform.LookAt(Camera.main.transform);
        }
    }
}