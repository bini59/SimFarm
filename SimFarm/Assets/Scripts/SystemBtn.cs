using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemBtn : MonoBehaviour
{
    [SerializeField]
    private GameObject grid;

    public void exitGame() {
        Application.Quit();
    }

    public void OnEnable() {
        grid.GetComponent<AudioSource>().Play();
    }

}
