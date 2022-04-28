using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCounter : MonoBehaviour
{
    //Declare Variables
    private GameManager gameManager;
    private int lifeCount = 3;
    private ActiviateReturnButton returnToMenu;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        returnToMenu = GameObject.Find("GameObject").GetComponent<ActiviateReturnButton>();
    }

    //When player gets hit, decrease extra life count. If player gets hit after zero, destroy the player.
    private void OnTriggerEnter(Collider other)
    {
        if(lifeCount != 0)
        {
            if (other.gameObject.CompareTag("asteroid") || other.gameObject.CompareTag("enemy ship"))
            {
                lifeCount--;
                gameManager.UpdateExtraLifeCounter(lifeCount);
            }
        }
        else
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            gameManager.SaveHighScore();
            returnToMenu.SetButtonActive();
        }
    }
}
