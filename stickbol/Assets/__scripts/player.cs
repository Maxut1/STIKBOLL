using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    public float speed;
    Rigidbody2D rb;

    public Joystick joystick;

    private Vector2 dondon;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        Vector2 moveInput = new Vector2(joystick.Horizontal, joystick.Vertical);
        dondon = moveInput.normalized * speed;
    }

    private void FixedUpdate() 
    {
        rb.MovePosition(rb.position + dondon * Time.deltaTime);
    }

    




}
