using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SlidingPuzzleBoard {

    public int boardSize;

    public Sprite[] board1d;
    public Sprite[, ] board2d;
}