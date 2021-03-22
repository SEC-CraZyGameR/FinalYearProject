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
        LampPostController lampPostController;
        switch (other.tag)
        {
            case "PathIndicator":
                Destroy(other.gameObject);
                break;
            case "Destination":
                MSVehicleControllerFree.Instance.StopCar();
                DestinationReached();
                //CarCanvas.Instance.ShowDialogue("You Have Reached Your Destination.Thank You");
                break;
            case "SignalChecker":
                other.GetComponent<Collider>().enabled = false;
                lampPostController = other.transform.root.GetComponent<LampPostController>();
                if (lampPostController != null)
                {
                    if (lampPostController.isSafe)
                    {
                        Debug.Log("Thank you");
                        VoiceController.Instance.StartSpeak("Thank you for following the signal");
                    }
                    else
                    {
                        Debug.Log("Fine");
                        VoiceController.Instance.StartSpeak("You violated the signal");
                    }
                }
                break;
            case "SignalActivator":
                other.GetComponent<Collider>().enabled = false;
                lampPostController = other.transform.root.GetComponent<LampPostController>();
                if (lampPostController != null)
                {
                    StartCoroutine(lampPostController.ActivateRedLight(false));
                }

                break;
            default:
                break;
        }


        IdirectionController directionController = other.GetComponent<IdirectionController>();
        if (directionController != null) directionController.GiveDirection();
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
        yield return new WaitForSeconds(5.5f);
        LevelInfo nextlevelInfo = levelData.GetNextLevelInfo(SceneManager.GetActiveScene().name);
        nextlevelInfo.isUnlocked = true;
        SceneManager.LoadScene(nextlevelInfo.sceneName);
    }
}