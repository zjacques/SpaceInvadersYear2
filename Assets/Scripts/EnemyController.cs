using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    EnemyMover block;

    public GameObject shot;
    public Transform shotSpawn;
    public float edge;

    private void Start()
    {
        block = GetComponentInParent<EnemyMover>();
    }

    // Update is called once per frame
    void Update () {
		if (transform.position.x >= edge)
        {
            block.speed = 1;
            block.edgeMet = true;
        }
        if(transform.position.x <= -edge)
        {
            block.speed = -1;
            block.edgeMet = true;
        }

        if(Random.Range(1, 1000) == 1)
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
    }
}
