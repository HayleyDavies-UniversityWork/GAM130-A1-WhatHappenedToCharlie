using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClickPuzzle {
    public class Clickable : MonoBehaviour {
        // the puzzle this object is part of
        public ClickPuzzle puzzle;

        /// <summary>
        /// when the object is clicked
        /// </summary>
        void OnMouseDown() {
            // run the object clicked function for the puzzle
            puzzle.ObjectClicked(this);
        }
    }
}