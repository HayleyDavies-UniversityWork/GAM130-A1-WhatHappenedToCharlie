using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Puzzles {
    public class SlidingPuzzle : MonoBehaviour {
        public GameObject defaultTile;

        public float drawTileSize;

        [Range(3, 6)] public int boardSize = 3;

        public SlidingPuzzleBoard puzzleBoard;
        public SlidingPuzzleBoard puzzleBoardSolution;

        bool created = false;

        // Start is called before the first frame update
        void Start() {

        }

        // Update is called once per frame
        void Update() {
            if (gameObject.activeSelf == true && created == false) {
                CreateBoard();
                created = true;
                print("create");
            }
        }

        public void CreateBoard() {
            puzzleBoard.SetupBoard(boardSize);
            puzzleBoardSolution.SetupBoard(boardSize);
            DisplayBoard();
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
            newButton.onClick.AddListener(() => ClickTileButton(newButton, new Vector2Int(x, y)));

            print("listener added");

            Image newImage = newTile.GetComponent<Image>();
            newImage.sprite = puzzleBoard.board2d[x, y];
        }

        bool IsTileEmpty(int x, int y) {
            if (x < 0 || y < 0 || x >= boardSize || y >= boardSize)
                return false;

            if (puzzleBoard.board2d[x, y] == null)
                return true;

            return false;
        }

        void MoveTileTo(Button self, Vector2Int oldPos, Vector2Int newPos) {
            puzzleBoard.board2d[newPos.x, newPos.y] = puzzleBoard.board2d[oldPos.x, oldPos.y];
            puzzleBoard.board2d[oldPos.x, oldPos.y] = null;

            int xOffset = newPos.x - (boardSize / 2);
            int yOffset = (boardSize / 2) - newPos.y;
            Vector2 position = new Vector2(xOffset * drawTileSize, yOffset * drawTileSize);

            self.transform.localPosition = position;

            Debug.Log($"[{oldPos.x}, {oldPos.y}] moving to [{newPos.x}, {newPos.y}]");

            puzzleBoard.board1d = puzzleBoard.board2d.Convert1D();

            self.onClick.RemoveAllListeners();
            self.onClick.AddListener(() => ClickTileButton(self, newPos));
        }

        public void ClickTileButton(Button self, Vector2Int buttonPos) {
            if (IsTileEmpty(buttonPos.x - 1, buttonPos.y)) {
                MoveTileTo(self, buttonPos, buttonPos + new Vector2Int(-1, 0));
            } else if (IsTileEmpty(buttonPos.x + 1, buttonPos.y)) {
                MoveTileTo(self, buttonPos, buttonPos + new Vector2Int(1, 0));
            } else if (IsTileEmpty(buttonPos.x, buttonPos.y - 1)) {
                MoveTileTo(self, buttonPos, buttonPos + new Vector2Int(0, -1));
            } else if (IsTileEmpty(buttonPos.x, buttonPos.y + 1)) {
                MoveTileTo(self, buttonPos, buttonPos + new Vector2Int(0, 1));
            }

            if (IsPuzzleComplete()) {
                Debug.Log("Puzzle has been completed!");
                gameObject.SetActive(false);
            }
        }

        bool IsPuzzleComplete() {
            for (int i = 0; i < boardSize; i++) {
                for (int j = 0; j < boardSize; j++) {
                    if (puzzleBoard.board2d[i, j] != puzzleBoardSolution.board2d[i, j]) {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}