using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornPaper : MonoBehaviour
{
    public int Score = 0;

    public GameObject WinText;

    private void Update()
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

        if(Score >= 4)
        {
            
            WinText.SetActive(true);
        }
    }
}
