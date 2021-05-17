using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ClickPuzzle {
    public class Clickable : MonoBehaviour {
        // the puzzle this object is part of
        public ClickPuzzle puzzle;

        public UnityEvent action;

        public Material clickMaterial;
        public Material defaultMaterial;

        /// <summary>
        /// when the object is clicked
        /// </summary>
        void OnMouseDown() {
            if (!puzzle.currentClicks.Contains(this)) {
                Debug.Log(name);
                action.Invoke();
                // run the object clicked function for the puzzle
                puzzle.ObjectClicked(this);
            }
        }

        public void ChangeMaterial() {
            SetMaterial(clickMaterial);
        }

        public void SetMaterial(Material material) {
            MeshRenderer r = GetComponent<MeshRenderer>();
            if (r.material == material) {
                r.material = defaultMaterial;
            } else {
                r.material = material;
            }
        }

        public void ToggleParticles() {
            Debug.Log(name);
            ParticleSystem[] ps = GetComponentsInChildren<ParticleSystem>();
            foreach (ParticleSystem p in ps) {
                if (p.isPlaying) {
                    p.Stop();
                } else {
                    p.Play();
                }
            }
        }
    }
}