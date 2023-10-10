using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    private GameController gameController;
    public int score;

    void Start()
    {
        GameObject controller = GameObject.FindWithTag("GameController");
        if(controller != null)
        {
            gameController = controller.GetComponent<GameController>();
        }
        if(gameController == null)
        {
            Debug.Log("Game controller find not found");
        }
    }

    void OnTriggerEnter( Collider other)
    {
        if (other.tag == "Boundary")
            return;
        Instantiate(explosion, transform.position, transform.rotation);
        if(other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }
            
        gameController.addScore(score);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
