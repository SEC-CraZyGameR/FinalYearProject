using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollisionChecker : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("PathIndicator"))
        {
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PathIndicator"))
        {
            Destroy(other.gameObject);
        }
    }
}
