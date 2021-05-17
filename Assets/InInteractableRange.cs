using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InteractionSystem {
    public class InInteractableRange : MonoBehaviour {
        public Material highlightMaterial;

        void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Interactable")) {
                other.GetComponent<MeshRenderer>().material = highlightMaterial;
            }
        }

        void OnTriggerExit(Collider other) {
            if (other.CompareTag("Interactable")) {
                other.GetComponent<Interactable>().ResetMaterial();
            }
        }
    }
}