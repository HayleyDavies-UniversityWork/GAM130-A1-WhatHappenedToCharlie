using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SlidingPuzzleBoard {

    public int boardSize = 3;

    public Sprite[] board1d;
    public Sprite[, ] board2d;
    

    public SlidingPuzzleBoard(SlidingPuzzleBoard board) {
        boardSize = board.boardSize;
        board1d = board.board1d;
        board2d = board.board2d;
    }

    public SlidingPuzzleBoard() {
        
    }
}

public static class SetupSlidingBoard {
    public static void SetupBoard(this SlidingPuzzleBoard board, int size) {
        board.boardSize = size;
        board.board2d = board.board1d.Convert2D(board.boardSize);
    }
}