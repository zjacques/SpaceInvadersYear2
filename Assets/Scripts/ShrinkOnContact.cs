using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkOnContact : MonoBehaviour {

    float scale;
    public GameObject explosion;

    private void Start()
    {
        scale = 2;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.gameObject.CompareTag("Boundary"))
        {
            scale -= 0.2f;
            transform.localScale -= new Vector3(0.2f, 0.2f, 0);
            Instantiate(explosion, transform);
            Destroy(other.gameObject);
            if (scale <= 0)
                Destroy(gameObject);
        }

    }
}
