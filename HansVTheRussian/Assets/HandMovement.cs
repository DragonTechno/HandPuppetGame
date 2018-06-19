using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovement : MonoBehaviour {

    public float speed;
    public float slow;
    public float hitRadius;
    public float hitStrength;
    public int player;

    Rigidbody2D rb;
    Animator anim;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (player == 1)
        {
            if (Input.GetKey(KeyCode.A))
            {
                rb.velocity += speed * Vector2.left;
            }
            if (Input.GetKey(KeyCode.D))
            {
                rb.velocity += speed * Vector2.right;
            }
            if (Input.GetKey(KeyCode.W))
            {
                rb.velocity += speed * Vector2.up;
            }
            if (Input.GetKey(KeyCode.S))
            {
                rb.velocity += speed * Vector2.down;
            }
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                anim.Play(stateName: "Open");
                LayerMask ballMask = LayerMask.GetMask("Ball");
                Collider2D[] balls = Physics2D.OverlapCircleAll(transform.position, hitRadius, ballMask);
                foreach(Collider2D ball in balls)
                {
                    ball.GetComponent<Rigidbody2D>().AddForce((ball.gameObject.transform.position - transform.position).normalized * hitStrength);
                }
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                anim.Play(stateName: "Close");
            }
        }
        else if(player == 2)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rb.velocity += speed * Vector2.left;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rb.velocity += speed * Vector2.right;
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb.velocity += speed * Vector2.up;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                rb.velocity += speed * Vector2.down;
            }
            if(Input.GetKeyDown(KeyCode.Space))
            {
                anim.Play(stateName: "Open Left");
                LayerMask ballMask = LayerMask.GetMask("Ball");
                Collider2D[] balls = Physics2D.OverlapCircleAll(transform.position, hitRadius, ballMask);
                foreach (Collider2D ball in balls)
                {
                    print(ball.gameObject.name);
                    ball.GetComponent<Rigidbody2D>().AddForce((ball.gameObject.transform.position - transform.position).normalized * hitStrength);
                }
            }
            if(Input.GetKeyUp(KeyCode.Space))
            {
                anim.Play(stateName: "Close Left");
            }
        }
        rb.velocity = rb.velocity.normalized * slow * Mathf.Clamp(rb.velocity.magnitude, 0, speed);
    }
}
