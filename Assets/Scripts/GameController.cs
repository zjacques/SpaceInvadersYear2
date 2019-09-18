using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public float startWait;

    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    public Transform blockSpawn;
    public GameObject currentBlock;

    public int numEnemies;
    private int score;
    private bool gameOver;
    private bool restart;

    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        UpdateScore();
    }

    void Update()
    {
        if(restart)
        {
            restartText.text = "Press 'R' for Restart";
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if (numEnemies == 0)
        {
            numEnemies = 33;
            reset();
        }

    }



    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        restart = true;
    }

    public void reset()
    {
        Destroy(currentBlock);
        currentBlock = Instantiate(hazard, blockSpawn.position, blockSpawn.rotation);
    }
}
