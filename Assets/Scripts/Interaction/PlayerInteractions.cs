using System.Collections;
using System.Collections.Generic;
using InventorySystem;
using UnityEngine;
using UnityEngine.UI;

namespace InteractionSystem {
    public class PlayerInteractions : MonoBehaviour {
        private Collider currentCollider;

        public Canvas canvas;

        public Animator anim;

        // Start is called before the first frame update
        void Start() {
            canvas.enabled = false;
            anim = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update() {
            // if the interact button is pressed
            if (Input.GetButtonUp("Interact") && currentCollider != null) {
                // run the interaction script
                Interact();
            } else {
                anim.ResetTrigger("Pickup");
            }
        }

        /// <summary>
        /// Interact handles the interactions of the player
        /// </summary>
        void Interact() {
            canvas.enabled = false;
            // if the current collider has been set
            if (currentCollider != null) {
                // get the tag of the collider
                currentCollider.GetComponent<Interactable>().interact.Invoke();
            }

            PlayAnimation();
        }

        /// <summary>
        /// OnTriggerEnter is called when the Collider other enters the trigger.
        /// </summary>
        /// <param name="other">The other Collider involved in this collision.</param>
        void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Interactable")) {
                // set the current collider collider triggered
                currentCollider = other;
                canvas.enabled = true;
            }
        }

        /// <summary>
        /// OnTriggerExit is called when the Collider other has stopped touching the trigger.
        /// </summary>
        /// <param name="other">The other Collider involved in this collision.</param>
        void OnTriggerExit(Collider other) {
            // if the player exits the currentCollider
            if (currentCollider == other) {
                // set the currentCollider to null
                currentCollider = null;
            }
            canvas.enabled = false;
        }

        void PlayAnimation() {
            anim.SetTrigger("Pickup");
        }
    }
}