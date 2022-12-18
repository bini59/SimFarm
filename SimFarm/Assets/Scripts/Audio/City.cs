using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour
{
    private AudioSource gridAudio;
    void Awake() {
        gridAudio = GameObject.Find("Grid").GetComponent<AudioSource>();
    }
    void OnEnable() {
        gridAudio.mute = true;
    }

}
