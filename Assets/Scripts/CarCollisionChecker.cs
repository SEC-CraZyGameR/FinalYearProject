using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarCollisionChecker : MonoBehaviour
{
    [SerializeField] LevelData_SO levelData;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("PathIndicator"))
        {
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        switch (other.tag)
        {
            case "PathIndicator":
                Destroy(other.gameObject);
                break;
            case "Destination":
                DestinationReached();
                //CarCanvas.Instance.ShowDialogue("You Have Reached Your Destination.Thank You");
                break;
            default:
                break;
        }
    }

    public void DestinationReached()
    {
        GameManager.Instance.isReadyForMove = false;
        //Voice Command
        string strReached = "You have reached your destination.Next level loading,please wait";
        VoiceController.Instance.StartSpeak(strReached);
        StartCoroutine(GoToNext());
    }

    IEnumerator GoToNext()
    {
        yield return new WaitForSeconds(1.5f);
        LevelInfo nextlevelInfo = levelData.GetNextLevelInfo(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(nextlevelInfo.sceneName);
    }
}
