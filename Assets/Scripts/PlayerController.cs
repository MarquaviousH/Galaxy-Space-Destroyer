using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Declare Variables 
    private float horizontalInput;
    private float verticalInput;
    [SerializeField] private float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Call move player method
        movePlayer();
    }

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
}
