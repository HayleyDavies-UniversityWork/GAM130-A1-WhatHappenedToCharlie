using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ClickPuzzle {
    public class Clickable : MonoBehaviour {
        // the puzzle this object is part of
        public ClickPuzzle puzzle;

        public UnityAction action;

        public Material clickMaterial;
        public Material defaultMaterial;

        /// <summary>
        /// when the object is clicked
        /// </summary>
        void OnMouseDown() {
            action.Invoke();
            // run the object clicked function for the puzzle
            puzzle.ObjectClicked(this);
        }

        public void ChangeMaterial() {
            SetMaterial(clickMaterial);
        }

        public void SetMaterial(Material material) {
            GetComponent<MeshRenderer>().material = material;
        }
    }
}