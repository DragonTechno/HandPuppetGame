using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckDrift : MonoBehaviour {

    public float driftStrength;
    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector2 randomVector;
        randomVector = new Vector2(Random.Range(-1f,1f),Random.Range(-1f,1f));
        print(randomVector);
        rb.AddForce(randomVector.normalized*driftStrength);
	}
}
