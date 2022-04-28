using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFoward : MonoBehaviour
{
    //Declare Variables
    [SerializeField] private float speed = 30.0f;

    // Update is called once per frame
    void Update()
    {
        //Move the object foward
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
}
