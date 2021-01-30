using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SlidingPuzzleBoard {

    public int boardSize;

    public Sprite[] board1d;
    public Sprite[, ] board2d;
}

public static class SetupSlidingBoard {
    public static void SetupBoard(this SlidingPuzzleBoard board) {
        board.board2d = board.board1d.Convert2D(board.boardSize);
    }
}