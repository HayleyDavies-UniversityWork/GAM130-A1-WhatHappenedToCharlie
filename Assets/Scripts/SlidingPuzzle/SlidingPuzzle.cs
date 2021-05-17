using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;
using UnityEngine.UI;

namespace Puzzles {
    public class SlidingPuzzle : MonoBehaviour {
        public enum Difficulty {
            Easy = 25,
            Medium = 50,
            Hard = 100,

            Expert = 1000
        }

        public Difficulty boardMovementCount = Difficulty.Easy;
        public string CompletionFungusMessage = "";
        public GameObject defaultTile;

        public float drawTileSize;

        [Range(3, 10)] public int boardSize = 3;

        public Texture2D wholeTexture;

        public SlidingPuzzleBoard puzzleBoard;
        public SlidingPuzzleBoard puzzleBoardSolution;

        public Button[, ] buttonArray2D;

        bool created = false;

        bool shuffleMode = true;

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

        public SlidingPuzzleBoard SplitTexture() {
            int imageWidth = wholeTexture.width / boardSize;
            int imageHeight = wholeTexture.height / boardSize;

            SlidingPuzzleBoard board = new SlidingPuzzleBoard();

            int sqrSize = boardSize * boardSize;

            board.board1d = new Sprite[sqrSize];

            int count = 0;
            for (int i = 0; i < boardSize; i++) {
                for (int j = boardSize - 1; j >= 0; j--) {
                    if (i == boardSize - 1 && j == 0) {
                        break;
                    }

                    Texture2D texture = new Texture2D(imageWidth, imageHeight);
                    texture.SetPixels(wholeTexture.GetPixels(i * imageWidth, j * imageHeight, imageWidth, imageHeight));
                    texture.Apply();
                    Rect rect = new Rect(0, 0, imageWidth, imageHeight);
                    Sprite sprite = Sprite.Create(texture, rect, new Vector2(0, 0), .2f);
                    sprite.name = $"({i}, {j})";
                    board.board1d[count] = sprite;
                    count++;
                }
            }

            board.SetupBoard(boardSize);

            board.board2d.Convert1D();

            return board;
        }

        public void CreateBoard() {
            puzzleBoard = SplitTexture();
            puzzleBoardSolution = new SlidingPuzzleBoard(puzzleBoard);
            puzzleBoardSolution.board1d = puzzleBoardSolution.board2d.Convert1D();
            buttonArray2D = new Button[boardSize, boardSize];
            Vector2Int blankPos = new Vector2Int(boardSize - 1, boardSize - 1);
            DisplayBoard();

            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            StartCoroutine(ShuffleTiles((int) boardMovementCount, blankPos, blankPos));
            watch.Stop();

            Debug.Log($"Execution Time: {watch.ElapsedMilliseconds} ms");
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
            if (!puzzleBoard.board2d[x, y])
                return;

            int xOffset = x - (boardSize / 2);
            int yOffset = (boardSize / 2) - y;

            Vector2 position = new Vector2(xOffset * drawTileSize, yOffset * drawTileSize);
            GameObject newTile = Instantiate(defaultTile, position, Quaternion.identity, canvas.transform);
            newTile.transform.localPosition = position;
            newTile.name = $"Sliding Puzzle Tile ({x}, {y})";

            Vector2 size = new Vector2(drawTileSize, drawTileSize);
            newTile.GetComponent<RectTransform>().sizeDelta = size;

            buttonArray2D[x, y] = newTile.GetComponent<Button>();
            buttonArray2D[x, y].onClick.AddListener(() => ClickTileButton(buttonArray2D[x, y], new Vector2Int(x, y)));

            print("listener added");

            Image newImage = newTile.GetComponent<Image>();
            newImage.sprite = puzzleBoard.board2d[x, y];
        }

        bool IsTileEmpty(int x, int y) {
            if (x < 0 || y < 0 || x >= boardSize || y >= boardSize)
                return false;

            if (!puzzleBoard.board2d[x, y])
                return true;

            return false;
        }

        void MoveTileTo(Button self, Vector2Int oldPos, Vector2Int newPos) {
            puzzleBoard.board2d[newPos.x, newPos.y] = puzzleBoard.board2d[oldPos.x, oldPos.y];
            puzzleBoard.board2d[oldPos.x, oldPos.y] = null;
            buttonArray2D[newPos.x, newPos.y] = buttonArray2D[oldPos.x, oldPos.y];
            buttonArray2D[oldPos.x, oldPos.y] = null;

            int xOffset = newPos.x - (boardSize / 2);
            int yOffset = (boardSize / 2) - newPos.y;
            Vector2 position = new Vector2(xOffset * drawTileSize, yOffset * drawTileSize);
            self.transform.localPosition = position;

            //Debug.Log($"[{oldPos.x}, {oldPos.y}] moving to [{newPos.x}, {newPos.y}]");

            puzzleBoard.board1d = puzzleBoard.board2d.Convert1D();

            self.onClick.RemoveAllListeners();
            self.onClick.AddListener(() => ClickTileButton(self, newPos));
        }

        IEnumerator ShuffleTiles(int movements, Vector2Int blankPos, Vector2Int previousBlankPos) {
            yield return new WaitForSeconds(0);
            movements--;

            Vector2Int clickPos = GetAdjacentTile(blankPos, previousBlankPos);

            buttonArray2D[clickPos.x, clickPos.y].onClick.Invoke();
            if (movements > 0) {
                StartCoroutine(ShuffleTiles(movements, clickPos, blankPos));
            }
            shuffleMode = false;
        }

        Vector2Int GetAdjacentTile(Vector2Int blankPos, Vector2Int previousBlankPos) {
            List<Vector2Int> directions = new List<Vector2Int>();

            if (blankPos.x < boardSize - 1 && blankPos.x + 1 != previousBlankPos.x) {
                directions.Add(Vector2Int.right);
            }
            if (blankPos.x > 0 && blankPos.x - 1 != previousBlankPos.x) {
                directions.Add(Vector2Int.left);
            }
            if (blankPos.y < boardSize - 1 && blankPos.y + 1 != previousBlankPos.y) {
                directions.Add(Vector2Int.up);
            }
            if (blankPos.y > 0 && blankPos.y - 1 != previousBlankPos.y) {
                directions.Add(Vector2Int.down);
            }

            int d = Random.Range(0, directions.Count);

            Vector2Int tile = blankPos + directions[d];

            return tile;
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

            if (IsPuzzleComplete() && shuffleMode == false) {
                Debug.Log("Puzzle has been completed!");
                gameObject.SetActive(false);
                Destroy(transform.parent.gameObject);
            }
        }

        bool IsPuzzleComplete() {
            int sqrSize = boardSize * boardSize;
            for (int i = 0; i < sqrSize; i++) {
                if (puzzleBoard.board1d[i] != puzzleBoardSolution.board1d[i]) {
                    return false;
                }
            }

            Fungus.Flowchart.BroadcastFungusMessage(CompletionFungusMessage);
            return true;
        }
    }
}