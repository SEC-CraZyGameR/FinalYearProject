using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaCollider : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.CompareTag("Car"))
        {
            Debug.Log("Denger Area Inter");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            Debug.Log("Denger Area Inter");
        }
    }
}
