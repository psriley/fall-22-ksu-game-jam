using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : PlayerController
{
    [SerializeField] private FOV fov;

    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;
    Animator anim;

    protected override void Awake()
    {
        base.Awake();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (movement.x == 0 && movement.y == 0){
            anim.SetBool("isWalking", false);
        }
        else {
            anim.SetBool("isWalking", true);
        }
    }

    private void FixedUpdate() {
        rb.MovePosition(rb.position + movement * walkSpeed * Time.fixedDeltaTime);

        Vector3 lookDir = (mousePos - rb.position);

        fov.SetAimDirection(lookDir);
        fov.SetOrigin(rb.position);

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90f;
        rb.rotation = angle;
    }
}
