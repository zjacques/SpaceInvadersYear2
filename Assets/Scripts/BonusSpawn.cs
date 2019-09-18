using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawn : MonoBehaviour {

    public GameObject bonus;

	void Update () {
        if (Random.Range(1, 1000) == 1)
            Instantiate(bonus, transform.position, transform.rotation);
	}
}
