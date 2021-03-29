using UnityEngine.Audio;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomAudio : MonoBehaviour {
    // room sources
    public AudioSource[] sources;

    public float volume = 0.5f;

    public void Start() {
        if (name == "BedroomCamera") {
            PlayAudio();
        }
    }
    
    public void PlayAudio() {
        Debug.Log($"{transform.name} is playing audio.");
        foreach (AudioSource source in sources) {
            source.Play();
        }
    }

    public void StopAudio() {
        Debug.Log($"{transform.name} is stopping audio.");
        foreach (AudioSource source in sources) {
            source.Stop();
        }
    }
}
