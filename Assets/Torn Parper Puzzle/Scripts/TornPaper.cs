using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornPaper : MonoBehaviour
{
    public int Score = 0;

    private void Update()
    {
        GameObject pieces = GameObject.Find("Pieces");
        if (pieces.GetComponentInChildren<Piece>().isDone)
        {
            Score += 1;
        }

        if(Score <= 4)
        {
            GameObject.Find("WinText").SetActive(true);
        }
    }
}
