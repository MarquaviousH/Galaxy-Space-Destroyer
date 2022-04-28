using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    //Declare variables
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        //Get the components of the gameManager
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    //When laser collides with the asteroid or enemy ship, update the score
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("asteroid"))
        {
            gameManager.UpdateScore(20);

        }
        else if (other.gameObject.CompareTag("enemy ship"))
        {
            gameManager.UpdateScore(50);
        }

    }
}
