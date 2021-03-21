using UnityEngine.Audio;
using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RoomAudio : MonoBehaviour
{
    public static RoomAudio instance;
    public GameObject Kitchen;
    public GameObject Corridor;
    public GameObject Bedroom;

    //Kitchen noises
    public AudioSource sink;
    public AudioClip drip;
    public float volume = 0.5f;


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

    void Start()
    {
        
    }

    public void CheckRoomAudio()
    {
        if (Kitchen.activeSelf == true)
        {
            Debug.Log("kitchen Active");
            sink.PlayOneShot(drip, volume);
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
