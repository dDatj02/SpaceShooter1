using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public float xMinMax;
    public float zMin;
    public int count;
    public float startWait;
    public float cloneWait;
    public GameObject rock;

    private int score;
    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    private bool restart;
    private bool gameOver;

    void Start()
    {
        StartCoroutine(Waves());
        score = 0;
        scoreText.text = "Score: 0";
        restartText.text = "";
        gameOverText.text = "";
        restart = gameOver = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && restart)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }


    IEnumerator Waves()
    {
        while (true)
        {
            yield return new WaitForSeconds(startWait);
            for(int i = 0; i < count;  i++) { 
                Instantiate(rock, new Vector3(Random.Range(-xMinMax, xMinMax), 0, zMin), Quaternion.identity);
                yield return new WaitForSeconds(cloneWait);
            }
            yield return new WaitForSeconds(4);
            if (gameOver)
            {
                restart = true;
                restartText.text = "Press 'R' to restart game";
                break;
            }
        }
    }

    public void addScore(int sc)
    {
        score += sc;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverText.text = "GAME OVER";
    }
}
