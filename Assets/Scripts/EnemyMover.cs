using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour {

    Rigidbody2D rb;
    public bool edgeMet;

    public float speed;
    public float speedMult;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        speedMult = 1.0f;
        edgeMet = false;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
        rb.velocity = transform.right * speed * speedMult;

        if(edgeMet)
        {
            moveDown();
            edgeMet = false;
        }

    }

    void moveDown()
    {
        transform.Translate(0, 0.5f, 0);
    }
}
