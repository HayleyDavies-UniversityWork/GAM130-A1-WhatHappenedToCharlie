using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InteractionSystem {
    public class InInteractableRange : MonoBehaviour {
        public Material highlightMaterial;

        void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Interactable")) {
                Material[] materials = other.GetComponent<MeshRenderer>().materials;
                for (int i = 0; i < materials.Length; i++) {
                    materials[i] = highlightMaterial;
                }
                other.GetComponent<MeshRenderer>().materials = materials;
            }
        }

        void OnTriggerExit(Collider other) {
            if (other.CompareTag("Interactable")) {
                other.GetComponent<Interactable>().ResetMaterial();
            }
        }
    }
}