﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovement : MonoBehaviour {

    public float speed;
    public float slow;
    public float hitRadius;
    public float hitStrength;
    public int player;
    public float biasUp;
    public float biasOver;

    Rigidbody2D rb;
    Animator anim;
    KeyCode[] keys;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        if(player == 1)
        {
            keys = new KeyCode[] {KeyCode.A,KeyCode.D,KeyCode.W,KeyCode.S,KeyCode.LeftShift};
        }
        else
        {
            keys = new KeyCode[] {KeyCode.LeftArrow,KeyCode.RightArrow,KeyCode.UpArrow,KeyCode.DownArrow,KeyCode.Keypad0};
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(keys[0]))
        {
            rb.velocity += speed * Vector2.left;
        }
        if (Input.GetKey(keys[1]))
        {
            rb.velocity += speed * Vector2.right;
        }
        if (Input.GetKey(keys[2]))
        {
            rb.velocity += speed * Vector2.up;
        }
        if (Input.GetKey(keys[3]))
        {
            rb.velocity += speed * Vector2.down;
        }
        if (Input.GetKeyDown(keys[4]))
        {
            if(player == 1)
            {
                anim.Play(stateName: "Open");
            }
            else
            {
                anim.Play(stateName: "Open Left");    
            }
            LayerMask ballMask = LayerMask.GetMask("Ball");
            Collider2D[] balls = Physics2D.OverlapCircleAll(transform.position, hitRadius, ballMask);
            foreach(Collider2D ball in balls)
            {
                ball.GetComponent<Rigidbody2D>().AddForce((ball.gameObject.transform.position - transform.position).normalized * hitStrength + Vector3.up*biasUp + Vector3.right*biasOver);
            }
        }
        if (Input.GetKeyUp(keys[4]))
        {
            if(player == 1)
            {
                anim.Play(stateName: "Close");
            }
            else
            {
                anim.Play(stateName: "Close Left");    
            }
        }
        rb.velocity = rb.velocity.normalized * slow * Mathf.Clamp(rb.velocity.magnitude, 0, speed);
    }
}
