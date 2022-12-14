using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5f;

    public Rigidbody2D rb;
    public GameManager manager;

    protected virtual void Awake()
    {
        manager = FindObjectOfType<GameManager>();
    }
}
