using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCounter : MonoBehaviour
{

    private bool isHit = false;
    private float flashTime = 5.0f;
    private Color originalColor;
    private MeshRenderer meshRenderer;
    
    private GameManager gameManager;
    private int lifeCount = 3;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        originalColor = meshRenderer.material.color;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
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
                isHit = true;
                StartCoroutine(flash());
            }
        }
        else
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }

    IEnumerator flash()
    {
        while (isHit == true)
        {
            meshRenderer.material.color = Color.white;
            yield return new WaitForSeconds(flashTime);
            meshRenderer.material.color = originalColor;
            isHit = false;
        }
    }
}
