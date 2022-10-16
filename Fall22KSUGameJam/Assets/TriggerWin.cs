using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWin : MonoBehaviour
{
    private MenuManager menu;

    private void Awake() {
        menu = FindObjectOfType<MenuManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            menu.ShowWin();
        }
    }
}
