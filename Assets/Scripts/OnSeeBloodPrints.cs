using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSeeBloodPrints : MonoBehaviour {
    public Togglelight togglelight;

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("BloodOnFloor") && togglelight.on) {
            Fungus.Flowchart.BroadcastFungusMessage("BloodOnFloorComment");
        }
    }
}