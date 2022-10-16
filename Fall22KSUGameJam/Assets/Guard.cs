using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    public float distance;
    public LineRenderer lineOfSight;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Physics2D.queriesStartInColliders = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.hasChanged) {
            Debug.Log("Transform has changed!");
            anim.SetBool("isWalking", true);
        }
        else {
            anim.SetBool("isWalking", false);
        }

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, -transform.up, distance);
        if (hitInfo.collider != null) {
            Debug.DrawLine(transform.position, hitInfo.point, Color.red);
            lineOfSight.SetPosition(1, hitInfo.point);

            if (hitInfo.collider.CompareTag("Player")){
                FindObjectOfType<MenuManager>().ShowFail();
            }
        }
        else {
            Debug.DrawLine(transform.position, transform.position + transform.right * distance, Color.green);
            lineOfSight.SetPosition(1, transform.position + transform.right * distance);
        }

        lineOfSight.SetPosition(0, transform.position);
    }
}
