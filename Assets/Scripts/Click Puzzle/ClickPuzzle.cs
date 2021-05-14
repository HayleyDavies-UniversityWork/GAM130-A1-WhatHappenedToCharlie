using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClickPuzzle {
    public class ClickPuzzle : MonoBehaviour {
        // the order, and objects that will be clicked
        public List<Clickable> clickOrder;

        // the currently clicked objects
        public List<Clickable> currentClicks;

        // the camera used before this one
        public Camera previousCamera;

        // the message to be broadcast once the puzzle is completed
        public string fungusCompletionMessage = "ClickPuzzleComplete";

        GameObject puzzleTrigger;

        public void StartPuzzle(GameObject trigger) {
            previousCamera = Camera.main;
            previousCamera.enabled = false;
            puzzleTrigger = trigger;
            GetComponent<Camera>().enabled = true;
        }

        // Start is called before the first frame update
        void Start() {
            GetComponent<Camera>().enabled = false;
            // create a new list for the current clicks
            currentClicks = new List<Clickable>(clickOrder.Count);

            // add a new item for each item in the clickOrder array
            // set the puzzle of each of the clicks to be this script
            for (int i = 0; i < clickOrder.Count; i++) {
                currentClicks.Add(null);
                clickOrder[i].puzzle = this;
            }
        }

        /// <summary>
        /// when an object has been clicked
        /// </summary>
        /// <param name="clickable">the object that has been clicked</param>
        public void ObjectClicked(Clickable clickable) {
            // add the object to the end of the list
            currentClicks.Add(clickable);
            // whilst the there are more objects in the currentClicks list
            while (currentClicks.Count > clickOrder.Count) {
                // remove the first index
                currentClicks.RemoveAt(0);
            }

            // check if the game is complete, if it is, run GameWin()
            if (isComplete()) {
                GameWin();
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
        }
    }
}