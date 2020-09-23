using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GVRButton : MonoBehaviour
{
    public ButtonID buttonID;
    private Image imageCircle;
    private float totalTime = 2f;
    private bool gvrStatus;
    private float gvrTimer;

    private void Start()
    {
        buttonID = ButtonID.btnPlay;
        imageCircle = UIManager.Instance.imgCircle;
    }

    private void Update()
    {
        if (gvrStatus)
        {
            gvrTimer += Time.deltaTime;
            imageCircle.fillAmount = gvrTimer / totalTime;
        }

        if (gvrTimer > totalTime)
        {
            UIManager.Instance.ButtonClickResponse((int)buttonID);
            gvrStatus = false;
            gvrTimer = 0;
        }
    }

    public void GvrOn()
    {
        gvrStatus = true;
    }

    public void GvrOff()
    {
        gvrStatus = false;
        gvrTimer = 0;
        imageCircle.fillAmount = 0;
    }
}
