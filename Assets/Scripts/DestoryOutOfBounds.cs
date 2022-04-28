using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryOutOfBounds : MonoBehaviour
{
    // Declare Variables
    private float frontBound = 30.0f;
    private float backBound = -15.0f;

    // Update is called once per frame
    void Update()
    {
        // Destroy objects that go out of bounds
        if(transform.position.z > frontBound)
        {
            Destroy(gameObject);
        } 
        else if(transform.position.z < backBound)
        {
            Destroy(gameObject);
        }
        
    }
}
