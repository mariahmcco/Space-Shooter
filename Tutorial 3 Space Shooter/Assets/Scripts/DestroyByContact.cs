using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gameController;

    void Start ()
    {
        GameObject gameControllerObect = GameObject.FindWithTag ("GameController");
        if (gameControllerObect != null)
        {
            gameController = gameControllerObect.GetComponent <GameController>();
        }
        if (gameController == null)
        {
            Debug.Log ("Cannot find 'GameController' script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }

        Instantiate (explosion, transform.position, transform.rotation);

        if(other.tag == "Player")
        {
        Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
        gameController.GameOver ();
        }
        gameController.AddScore (scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
