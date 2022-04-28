using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCounter : MonoBehaviour
{

    private GameManager gameManager;
    private int lifeCount = 3;
    private ReturnToMenu returnToMenu;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        returnToMenu = GameObject.Find("GameObject").GetComponent<ReturnToMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
