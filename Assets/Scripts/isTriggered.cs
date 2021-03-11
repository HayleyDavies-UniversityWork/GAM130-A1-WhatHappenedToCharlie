using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isTriggered : MonoBehaviour
{
    public bool isEntered;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            isEntered = true;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            isEntered = false;
        }
    }
}
