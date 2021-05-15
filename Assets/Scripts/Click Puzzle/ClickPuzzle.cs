using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ClickPuzzle {
    public class ClickPuzzle : MonoBehaviour {
        // the message to be broadcast once the puzzle is completed
        public string fungusCompletionMessage = "ClickPuzzleComplete";

        // the order, and objects that will be clicked
        public List<Clickable> clickOrder;

        public UnityEvent clickAction;

        // the currently clicked objects
        private List<Clickable> currentClicks;

        // the camera used before this one
        private Camera previousCamera;

        private GameObject puzzleTrigger;

        public void StartPuzzle(GameObject trigger, Camera previousCam) {
            previousCamera = previousCam;
            previousCamera.enabled = false;
            puzzleTrigger = trigger;
            GetComponent<Camera>().enabled = true;

            foreach (Clickable c in clickOrder) {
                c.enabled = true;
                c.SetMaterial(c.defaultMaterial);
            }

            // create a new list for the current clicks
            currentClicks = new List<Clickable>(clickOrder.Count);
        }

        // Start is called before the first frame update
        void Start() {
            clickAction.Invoke();
            GetComponent<Camera>().enabled = false;

            // add a new item for each item in the clickOrder array
            // set the puzzle of each of the clicks to be this script
            for (int i = 0; i < clickOrder.Count; i++) {
                clickOrder[i].enabled = false;
                clickOrder[i].puzzle = this;
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
                        StartPuzzle(puzzleTrigger, previousCamera);
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
        }

        public void ChangeMaterial(Material material) {
            foreach (Clickable c in clickOrder) {
                c.clickMaterial = material;
                c.action += c.ChangeMaterial;
                c.defaultMaterial = c.GetComponent<MeshRenderer>().material;
            }
        }

    }
}