using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ClickPuzzle {
    public class Clickable : MonoBehaviour {
        // the puzzle this object is part of
        public ClickPuzzle puzzle;

        public UnityEvent clickAction;
        public UnityEvent hoverAction;

        public Material changeMaterial;
        public Material defaultMaterial;
        MeshRenderer r;

        void Start() {
            r = GetComponent<MeshRenderer>();
            defaultMaterial = r.material;
        }

        /// <summary>
        /// when the object is clicked
        /// </summary>
        void OnMouseDown() {
            if (!puzzle.currentClicks.Contains(this)) {
                Debug.Log(name);
                clickAction.Invoke();
                // run the object clicked function for the puzzle
                puzzle.ObjectClicked(this);
            }
        }

        void OnMouseEnter() {
            if (!puzzle.currentClicks.Contains(this)) {
                Debug.Log($"{name} hovered over.");
                SetMaterial(changeMaterial);
            }
        }

        void OnMouseExit() {
            Debug.Log($"{name} not hovered over.");
            SetMaterial(defaultMaterial);
        }

        public void ChangeMaterial() {
            if (r.material == changeMaterial) {
                r.material = defaultMaterial;
            } else {
                r.material = changeMaterial;
            }
        }

        public void SetMaterial(Material material) {
            r.material = material;
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