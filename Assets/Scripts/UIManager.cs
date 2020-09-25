using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance = null;
    public Image imgCircle;
    public GameObject mainCanvas;


    [Header("<=============UIComponents============>")]
    public GameObject home;
    public GameObject about;
    public GameObject credits;

    private void Start()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        home.SetActive(true);
    }
    private void BtnPlayCallBack()
    {
        mainCanvas.SetActive(false);
        GameManager.Instance.LoadGame();
    }
    private void BtnAboutCallBack()
    {
        home.SetActive(false);
        about.SetActive(true);
        credits.SetActive(false);
    }

    private void BtnCreditsCallBack()
    {
        home.SetActive(false);
        about.SetActive(false);
        credits.SetActive(true);
    }

    public void BtnBackToHomeCallBack()
    {
        home.SetActive(true);
        about.SetActive(false);
        credits.SetActive(false);
    }

    public void ButtonClickResponse(int buttonId)
    {
        switch (buttonId)
        {
            case (int)ButtonID.btnPlay:
                BtnPlayCallBack();
                break;
            case (int)ButtonID.btnAbout:
                BtnAboutCallBack();
                break;
            case (int)ButtonID.btnCredits:
                BtnCreditsCallBack();
                break;
            case (int)ButtonID.backToHome:
                BtnBackToHomeCallBack();
                break;
            default:
                break;
        }
    }


}
