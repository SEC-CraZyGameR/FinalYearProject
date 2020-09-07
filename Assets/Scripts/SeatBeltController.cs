using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine;
using DG.Tweening;

public class SeatBeltController : MonoBehaviour
{
    public GameObject beforeUseSeatBelt;
    public GameObject afterUseSeatBelt;


    public TextMeshProUGUI txtSeatBeltInput;
    private void Start()
    {
        beforeUseSeatBelt.SetActive(true);
        afterUseSeatBelt.SetActive(false);

        MSVehicleControllerFree.Instance.theEngineIsRunning = false;

        AnimateAlert();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            beforeUseSeatBelt.SetActive(false);
            afterUseSeatBelt.SetActive(true);

            GameManager.Instance.isReadyForMove = true;
            MSVehicleControllerFree.Instance.theEngineIsRunning = true;
            Destroy(this.gameObject, 2.0f);
        }
    }

    public void AnimateAlert()
    {
        if (txtSeatBeltInput.gameObject != null)
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(txtSeatBeltInput.transform.DOScale(new Vector3(.8f, .8f, .8f), .5f)).
                Append(txtSeatBeltInput.transform.DOScale(Vector3.one, 1.0f)).SetLoops(-1);
        }
    }
}
