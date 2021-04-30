using System.Collections;
using System.Collections.Generic;
using InventorySystem;
using UnityEngine;

public class TornPaper : MonoBehaviour {
    public int Score = 0;

    public GameObject WinText;

    public GameObject exitButton;

    public GameObject InteractableObj;

    public GameObject missingPiece;
    private void Update() {
        Debug.Log(Inventory.ItemExists("Piece"));
        if (Inventory.ItemExists("Piece of paper")) {
            missingPiece.SetActive(true);
        }

        GameObject[] piece = GameObject.FindGameObjectsWithTag("TPP_Piece");
        foreach (var item in piece) {
            if (item.GetComponent<Piece>().isDone) {
                Score += 1;
                item.tag = "Untagged";
            }

        }

        if (Score >= 4) {

            WinText.SetActive(true);
            exitButton.SetActive(true);
        }
    }
    public void RestartPuzzle() {
        this.gameObject.SetActive(false);
        if (Score == 4) {
            Inventory.Remove("Piece of paper");
            FindObjectOfType<InventroyButton>().ReloadItems();
            Destroy(this.transform.parent.gameObject);
        }
        Destroy(this.gameObject);
    }

}