using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePuck : MonoBehaviour {

	public GameObject puck;
    public float shotDelay;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(GameObject.FindGameObjectWithTag("Puck") == null)
        {
            StartCoroutine("Fire");
        }
	}

    IEnumerator Fire()
    {
        yield return new WaitForSeconds(shotDelay);
        GameObject newPuck = Instantiate(puck, transform.position, Quaternion.identity);
        newPuck.GetComponent<Rigidbody2D>().velocity = Vector2.down * 5;
    }
}
