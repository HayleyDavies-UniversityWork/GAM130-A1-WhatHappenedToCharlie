using System.Collections;
using System.Collections.Generic;
using InventorySystem;
using UnityEngine;
using UnityEngine.Events;

namespace ClickPuzzle {
    public class ClickPuzzle : MonoBehaviour {
        public InventoryItem requiredItem;
        // the message to be broadcast once the puzzle is completed
        public string fungusCompletionMessage = "ClickPuzzleComplete";

        // the order, and objects that will be clicked
        public List<Clickable> clickOrder;

        // the camera used before this one
        public Camera previousCamera;

        public UnityEvent clickAction;
        public UnityEvent hoverAction;

        // the currently clicked objects
        public List<Clickable> currentClicks;

        private GameObject puzzleTrigger;

        private Canvas UI;

        string caller = "";
        public void StartPuzzle(GameObject trigger) {
            if (!Inventory.Contents.ContainsValue(requiredItem) && requiredItem != null) {
                Fungus.Flowchart.BroadcastFungusMessage("ItemNotOwned");
            } else {
                // previousCamera = previousCam;
                previousCamera.enabled = false;
                puzzleTrigger = trigger;
                GetComponent<Camera>().enabled = true;

                foreach (Clickable c in clickOrder) {
                    c.enabled = true;
                }

                puzzleTrigger.GetComponent<Collider>().enabled = false;
                UI.enabled = true;
                SetPlayerColliders(false);
            }
        }

        // Start is called before the first frame update
        void Start() {
            // create a new list for the current clicks
            currentClicks = new List<Clickable>(clickOrder.Count);
            UI = GetComponentInChildren<Canvas>();

            UI.enabled = false;
            caller = "click";
            clickAction.Invoke();
            caller = "hover";
            hoverAction.Invoke();

            GetComponent<Camera>().enabled = false;

            // add a new item for each item in the clickOrder array
            // set the puzzle of each of the clicks to be this script
            for (int i = 0; i < clickOrder.Count; i++) {
                clickOrder[i].enabled = false;
                clickOrder[i].puzzle = this;
            }

            foreach (Clickable c in clickOrder) {
                c.clickAction.Invoke();
            }
        }

        /// <summary>
        /// when an object has been clicked
        /// </summary>
        /// <param name="clickable">the object that has been clicked</param>
        public void ObjectClicked(Clickable clickable) {
            // if the object doesn't already exist in the list
            if (!currentClicks.Contains(clickable)) {
                // add the object to the end of the list
                currentClicks.Add(clickable);

                // check if the game is complete, if it is, run GameWin()
                if (clickOrder.Count == currentClicks.Count) {
                    if (isComplete()) {
                        GameWin();
                    } else {
                        currentClicks = new List<Clickable>(clickOrder.Count);
                        foreach (Clickable c in clickOrder) {
                            c.clickAction.Invoke();
                        }
                        StartPuzzle(puzzleTrigger);
                    }
                }
            }
        }

        /// <summary>
        /// check if the puzzle is complete
        /// </summary>
        /// <returns>true if the puzzle is complete</returns>
        bool isComplete() {
            // run through the clickOrder and currentClicks lists,
            // if the objects aren different, return false (cuts down on O(n))
            // if all objects are the same, return true
            for (int i = 0; i < clickOrder.Count; i++) {
                if (clickOrder[i] != currentClicks[i]) {
                    return false;
                }
            }
            return true;
        }

        // broadcast a fungus message/debug message
        void GameWin() {
            Fungus.Flowchart.BroadcastFungusMessage(fungusCompletionMessage);
            Debug.Log(fungusCompletionMessage);
            Destroy(puzzleTrigger);
            ClosePuzzle();
        }

        public void ClosePuzzle() {
            GetComponent<Camera>().enabled = false;
            previousCamera.enabled = true;

            foreach (Clickable c in clickOrder) {
                c.enabled = false;
            }

            puzzleTrigger.GetComponent<Collider>().enabled = true;
            UI.enabled = false;
            Fungus.Flowchart.BroadcastFungusMessage("EnablePlayerControls");
            SetPlayerColliders(true);
        }

        public void ChangeMaterial(Material material) {
            foreach (Clickable c in clickOrder) {
                c.changeMaterial = material;
                if (caller == "click") {
                    c.clickAction.AddListener(() => c.ChangeMaterial());
                } else if (caller == "hover") {
                    c.hoverAction.AddListener(() => c.ChangeMaterial());
                }
                c.defaultMaterial = c.GetComponent<MeshRenderer>().material;
            }
        }

        public void ToggleParticles() {
            Debug.Log("ToggleParticles");
            foreach (Clickable c in clickOrder) {
                if (caller == "click") {
                    c.clickAction.AddListener(() => c.ToggleParticles());
                } else if (caller == "hover") {
                    c.hoverAction.AddListener(() => c.ToggleParticles());
                }
            }
        }

        void SetPlayerColliders(bool enabled) {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            foreach (BoxCollider bc in player.GetComponents<BoxCollider>()) {
                bc.enabled = enabled;
            }

            foreach (CharacterController cc in player.GetComponents<CharacterController>()) {
                cc.enabled = enabled;
            }
        }

    }
}