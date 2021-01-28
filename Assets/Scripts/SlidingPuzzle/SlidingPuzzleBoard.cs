using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SlidingPuzzleBoard {

    [System.Serializable] public struct column {
        public Sprite[] row;
    }

    public column[] board;

    public int boardSize;
}