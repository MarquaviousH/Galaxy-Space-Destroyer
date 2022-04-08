using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    private float speed = 85.0f;
    private Rigidbody objectsRb;
    private float zDestory = 15.0f;


    // Start is called before the first frame update
    void Start()
    {
        objectsRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        objectsRb.AddForce(Vector3.forward * Time.deltaTime * -speed);
        if (transform.position.z < -zDestory)
        {
            Destroy(gameObject);
        }
    }
}
