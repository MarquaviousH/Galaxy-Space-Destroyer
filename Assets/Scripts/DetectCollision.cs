using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
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
