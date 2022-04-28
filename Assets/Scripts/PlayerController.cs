using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Declare Variables 
    private float horizontalInput;
    private float verticalInput;
    [SerializeField] private float speed = 5.0f;
    private float xBound = 5.5f;
    private float yBound = 5.5f;

    public GameObject projectilePrefab;

    // Update is called once per frame
    void Update()
    {
        //Call move player method
        movePlayer();

        //Constrain Players position
        constrainPlayerPosition();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Launch projectile from the player 
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }

    }

    //Player movement
    void movePlayer()
    {
        //Player Input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //Move player up
        transform.Translate(Vector3.up * Time.deltaTime * speed * verticalInput);

        //Move player left or right 
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
    }

    //Player Bounderies
    void constrainPlayerPosition()
    {
        //Left bound for player
        if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }

        //Right bound for player
        if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }

        //Upper bound for player
        if (transform.position.y > yBound)
        {
            transform.position = new Vector3(transform.position.x, yBound, transform.position.z);
        }

        //Lower bound for player
        if (transform.position.y < 1)
        {
            transform.position = new Vector3(transform.position.x, 1, transform.position.z);
        }
    }

}

