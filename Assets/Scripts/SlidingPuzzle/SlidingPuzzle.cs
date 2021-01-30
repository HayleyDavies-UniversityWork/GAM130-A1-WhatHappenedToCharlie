using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlidingPuzzle : MonoBehaviour {
    public GameObject defaultTile;

    public float drawTileSize;

    [Range(3, 6)] public int boardSize = 3;

    public SlidingPuzzleBoard puzzleBoard;
    public SlidingPuzzleBoard puzzleBoardSolution;

    // Start is called before the first frame update
    void Start() {
        puzzleBoard.SetupBoard();
        puzzleBoardSolution.SetupBoard();
        DisplayBoard();
    }

    // Update is called once per frame
    void Update() {

    }

    void DisplayBoard() {
        Canvas childCanvas = CreateBlankCanvas();

        boardSize = puzzleBoard.boardSize;
        Rect newTransform = new Rect();

        newTransform.size = new Vector2(drawTileSize, drawTileSize);

        for (int i = 0; i < boardSize; i++) {
            for (int j = 0; j < puzzleBoard.boardSize; j++) {

                CreateNewTile(i, j, childCanvas);
            }
        }
    }

    Canvas CreateBlankCanvas() {
        GameObject newObject = new GameObject();
        newObject.name = "Sliding Puzzle Canvas";
        newObject.transform.parent = transform;
        Canvas newCanvas = newObject.AddComponent<Canvas>();
        newObject.AddComponent<GraphicRaycaster>();
        newCanvas.renderMode = RenderMode.ScreenSpaceOverlay;

        return newCanvas;
    }

    void CreateNewTile(int x, int y, Canvas canvas) {
        if (puzzleBoard.board2d[x, y] == null)
            return;

        int xOffset = x - (boardSize / 2);
        int yOffset = (boardSize / 2) - y;

        Vector2 position = new Vector2(xOffset * drawTileSize, yOffset * drawTileSize);
        GameObject newTile = Instantiate(defaultTile, position, Quaternion.identity, canvas.transform);
        newTile.transform.localPosition = position;
        newTile.name = $"Sliding Puzzle Tile ({x}, {y})";

        Button newButton = newTile.GetComponent<Button>();
        newButton.onClick.AddListener(ClickTileButton);

        Image newImage = newTile.GetComponent<Image>();
        newImage.sprite = puzzleBoard.board2d[x, y];
    }

    public void ClickTileButton() {
        Debug.Log("2");
    }
}