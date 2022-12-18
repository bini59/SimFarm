using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAudio : MonoBehaviour
{
    private AudioSource gridAudio;
    void Awake() {
        gridAudio = GameObject.Find("Grid").GetComponent<AudioSource>();
    }

    void OnEnable() {
        gridAudio.mute = true;
    }

    void OnDisable() {
        gridAudio.mute = false;
    }
}
