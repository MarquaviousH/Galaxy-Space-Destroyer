using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    private PlayerController playerObject;
    private GameManager gameManager;
    public bool isHit;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }


    // When object collides with other, destroy both
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("player") && !other.gameObject.CompareTag("play container"))
        {

            Destroy(gameObject);
            Destroy(other.gameObject);

        }
    }
}
