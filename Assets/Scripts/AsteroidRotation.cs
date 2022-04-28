using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidRotation : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Rotate( -17.0f * Time.deltaTime, 0.0f, 0.0f);
    }
}
