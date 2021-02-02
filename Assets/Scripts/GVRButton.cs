using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GVRButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public ButtonID buttonID;
    public int value;//
    private Image imageCircle;
    private float totalTime = 2f;
    private bool gvrStatus;
    private float gvrTimer;

    private void Start()
    {
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
            if (buttonID == ButtonID.playGame)
            {
                UIManager.Instance.ButtonClickResponse((int)buttonID, value);
            }
            else
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        GvrOn();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GvrOff();
    }
}
