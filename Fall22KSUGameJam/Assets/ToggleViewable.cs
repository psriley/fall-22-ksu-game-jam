using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleViewable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Toggle"))
        {
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Toggle"))
        {
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
