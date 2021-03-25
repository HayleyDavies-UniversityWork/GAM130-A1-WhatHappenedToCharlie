using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventorySystem;

public class TornPaper : MonoBehaviour
{
    public int Score = 0;

    public GameObject WinText;

    public GameObject exitButton;

    public GameObject InteractableObj;

    public GameObject missingPiece;
    private void Update()
    {
        Debug.Log(Inventory.ItemExists("Piece"));
        if (Inventory.ItemExists("Piece of paper"))
        {
            missingPiece.SetActive(true);
        }
        GameObject[] piece = GameObject.FindGameObjectsWithTag("TPP_Piece");
        foreach (var item in piece)
        {
            if (item.GetComponent<Piece>().isDone)
            {
                Score += 1;
                item.tag = "Untagged";
               
            }
            
        }

        if(Score >= 4)
        {
            
            WinText.SetActive(true);
            exitButton.SetActive(true);
        }
    }
    public void RestartPuzzle()
    {
        this.gameObject.SetActive(false);
        Destroy(this.gameObject);
        
    }

}
