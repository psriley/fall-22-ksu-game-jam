using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWin : MonoBehaviour
{
    private MenuManager mm;
    private GameManager gm;

    private void Awake() {
        mm = FindObjectOfType<MenuManager>();
        gm = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            Destroy(gameObject);
            if (gm.GetCat()) {
                mm.ShowWin();
            }
            //mm.ShowWin();
        }
    }
}
