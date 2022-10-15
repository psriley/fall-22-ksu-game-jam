using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector2 walkSpeed = new Vector2(4f, 4f);

    public Rigidbody2D rb;
    public GameManager manager;

    protected virtual void Awake()
    {
        manager = FindObjectOfType<GameManager>();
    }
}
