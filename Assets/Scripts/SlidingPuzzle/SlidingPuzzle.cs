using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingPuzzle : MonoBehaviour {
    public SlidingPuzzleBoard puzzleBoard;
    public SlidingPuzzleBoard puzzleBoardSolution;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void DisplayBoard() {

    }
}

[System.Serializable]
public class SlidingPuzzleBoard {

    [System.Serializable] public struct column {
        public Sprite[] row;
    }

    public column[] board;
    public int boardSize;
}