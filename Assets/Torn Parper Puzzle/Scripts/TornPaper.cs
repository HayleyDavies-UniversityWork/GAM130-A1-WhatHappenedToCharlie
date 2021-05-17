using System.Collections;
using System.Collections.Generic;
using InventorySystem;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class TornPaper : MonoBehaviour {
    public int Score = 0;
    [Header("Kek")]
    public GameObject WinText;

    public GameObject exitButton;

    public GameObject InteractableObj;

    public GameObject missingPiece;

    public GameObject piecePrefab;

    public GameObject piecePlacePrefab;

    public Texture2D RawImage;

    public int ImageSize;

    private void Start()
    {
        SliceImage();
        Fungus.Flowchart.BroadcastFungusMessage("DisablePlayerControls");
    }

    private void Update() {
        MissingPieceCheck();

        CheckPiecesPlace();

        
        if (Score >= ImageSize * ImageSize) {

            Fungus.Flowchart.BroadcastFungusMessage("Torn Paper Puzzle Complete");
            Destroy(this.gameObject);
        }
    }
    public void RestartPuzzle() {
        this.gameObject.SetActive(false);
        if (Score == ImageSize) {
            Inventory.Remove("Piece of paper");
            FindObjectOfType<InventroyButton>().ReloadItems();
            Destroy(this.transform.parent.gameObject);
        }
        Destroy(this.gameObject);
        Fungus.Flowchart.BroadcastFungusMessage("EnablePlayerControls");
    }

    public void MissingPieceCheck()
    {
        if (Inventory.ItemExists("Piece of paper"))
        {
            missingPiece.SetActive(true);
        }
    }
    public void CheckPiecesPlace()
    {
        GameObject[] piece = GameObject.FindGameObjectsWithTag("TPP_Piece");
        foreach (var item in piece)
        {
            if (item.GetComponent<Piece>().isDone)
            {
                Score += 1;
                item.tag = "Untagged";
            }

        }
    }

    public void SliceImage()
    {

        int imageWidth = RawImage.width / ImageSize;
        int imageHeight = RawImage.height / ImageSize;
        int PieceSize = ImageSize * ImageSize;
        Sprite[] images = new Sprite[PieceSize];
        GameObject Pieces = GameObject.Find("TPP_Pieces");
        //images = Pieces.GetComponentsInChildren<Image>();
        GameObject Panel = GameObject.Find("TPP_Panel");
        RectTransform panelTrans = Panel.GetComponent<RectTransform>();
        panelTrans.sizeDelta.Set(RawImage.width, RawImage.height);
        GameObject[] pieces = new GameObject[PieceSize];
        GameObject[] piecePlaces = new GameObject[PieceSize];
        int count = 0;

        for (int i = 0; i < ImageSize; i++)
        {
            for (int j = 0; j < ImageSize ; j++)
            {


                Texture2D texture = new Texture2D(imageWidth, imageHeight);
                texture.SetPixels(RawImage.GetPixels(i * imageWidth, j * imageHeight, imageWidth, imageHeight));
                texture.Apply();
                Rect rect = new Rect(0, 0, imageWidth, imageHeight);
                Sprite sprite = Sprite.Create(texture, rect, new Vector2(0, 0), .2f);
                sprite.name = $"({i}, {j})";
                images[count] = sprite;
                
                count++;
            }
        }

        Image[] new_array = new Image[images.Length];
        Piece[] new_array2 = new Piece[images.Length];
        for (int i = 0; i < images.Length; i++)
        {
            piecePlaces[i] = Instantiate(piecePlacePrefab, Panel.transform) as GameObject;
            pieces[i] = Instantiate(piecePrefab, Pieces.transform) as GameObject;
            pieces[i].transform.position = new Vector3(Random.Range(200.0f, 400.0f), Random.Range(200.0f, 400.0f), 0);
            new_array2[i] = pieces[i].GetComponent<Piece>();
            new_array2[i].piecePlace = piecePlaces[i].gameObject;
            new_array[i] = pieces[i].GetComponent<Image>();
            new_array[i].sprite = images[i];
        }

        missingPiece = pieces[1];
        missingPiece.SetActive(false);
        //GameObject Pieces = GameObject.Find("Pieces");
        //GameObject[] pieces = GameObject.FindGameObjectsWithTag("TPP_Piece");
        //Sprite[] images = Pieces.GetComponentsInChildren<Sprite>();
        //foreach (var item in pieces)
        //{
        //    for (int X = 0; X < ImageSize; X++)
        //    {
        //        for (int Y = 0; Y < ImageSize; Y++)
        //        {

        //            Image pieceTexture = item.GetComponent<Image>();
        //            pieceTexture.sprite = pieceImage[X, Y];
        //        }
        //    }
        //}
    }

    
}