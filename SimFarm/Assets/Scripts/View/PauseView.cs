using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseView : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    void OnEnable() {
        player.GetComponent<PlayerAction>().moveToggle();
    }
    void OnDisable() {
        player.GetComponent<PlayerAction>().moveToggle();
    }
}
