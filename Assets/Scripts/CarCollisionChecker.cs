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

        switch(other.tag)
        {
            case "PathIndicator":
                Destroy(other.gameObject);
                break;
            case "Destination":
                CarCanvas.Instance.ShowDialogue("You Have Reached Your Destination.Thank You");
                break;
            default:
                break;
        }

        //if (other.CompareTag("PathIndicator"))
        //{
        //    Destroy(other.gameObject);
        //}
    }
}
