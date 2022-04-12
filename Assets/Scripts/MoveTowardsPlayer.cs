using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    //Declare Variables
    private float speed = 95.0f;
    private Rigidbody objectsRb;


    // Start is called before the first frame update
    void Start()
    {
        // Get the components of the object
        objectsRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Add force to the object to move towards the player
        objectsRb.AddForce(Vector3.forward * Time.deltaTime * -speed);
    }
}
