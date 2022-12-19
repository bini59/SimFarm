using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopAudio : MonoBehaviour
{

    public AudioClip purchaseSound;
    public AudioClip buttonSound;

    private AudioSource audioSource;


    void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    public void clickButton() {
        audioSource.clip = buttonSound;
        audioSource.Play();
    }

    public void purchaseSuccess() {
        audioSource.clip = purchaseSound;
        audioSource.Play();
    }

}
