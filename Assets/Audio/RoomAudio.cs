using UnityEngine.Audio;
using System;
using UnityEngine;

public class RoomAudio : MonoBehaviour
{
    public static RoomAudio instance;
    public GameObject Kitchen;
    public GameObject Corridor;
    public GameObject Bedroom;


    void Awake()
    {
        if (Kitchen.activeSelf == true)
        {
            Debug.Log("kitchen Active");
        }

        if (Corridor.activeSelf == true)
        {
            Debug.Log("Corridoor Active");
        }

        if (Bedroom.activeSelf == true)
        {
            Debug.Log("Bedroom Active");
        }
    }
    public void CheckRoomAudio()
    {
        if (Kitchen.activeSelf == true)
        {
            Debug.Log("kitchen Active");
        }

        if (Corridor.activeSelf == true)
        {
            Debug.Log("Corridoor Active");
        }

        if (Bedroom.activeSelf == true)
        {
            Debug.Log("Bedroom Active");
        }
    }
    //XAVS CODE HERE DONT MIND ME IF THIS BREAKS SOMETHING IM SO SORRY
    //RoomAudio.instance.CheckRoomAudio();
                //Debug.Log("TEST");
}
