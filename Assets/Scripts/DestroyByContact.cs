using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gameController;
    EnemyMover blockSpeed;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }

        blockSpeed = GetComponentInParent<EnemyMover>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boundary" || other.tag == "Enemy" || other.tag == "Bonus")
        {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        if(other.gameObject.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            if (other.GetComponent<PlayerController>().lives > 1)
            {
                other.GetComponent<PlayerController>().respawn();
                gameController.reset();

            }
            else
                gameController.GameOver();
        }
        if(tag != "Bonus")
        {
            blockSpeed.speedMult += 0.1f;
        }
        gameController.AddScore(scoreValue);
        
        Destroy(other.gameObject);

        if(!other.gameObject.CompareTag("Player"))
        {
            gameController.numEnemies--;
            Destroy(gameObject);
        }
            
    }
}
