﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance = null;
    public GameObject mainCanvas;


    [Header("<=============UIComponents============>")]
    [Space(10)]
    [Header("Menu Panels")]
    public GameObject home;
    public GameObject about;
    public GameObject credits;
    public GameObject levelSelection;

    private void Start()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        home.SetActive(true);
    }
    private void LevelSelectionCallBack()
    {
        levelSelection.SetActive(true);
        home.SetActive(false);
        about.SetActive(false);
        credits.SetActive(false);
    }
    private void PlayCallBack()
    {
        levelSelection.SetActive(false);
        home.SetActive(false);
        about.SetActive(false);
        credits.SetActive(false);
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
        levelSelection.SetActive(false);
    }

    public void ButtonClickResponse(int buttonId, int selectedLevel = 0)
    {
        switch (buttonId)
        {
            case (int)ButtonID.btnStart:
                LevelSelectionCallBack();
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
            case (int)ButtonID.levelSelection:
                
                break;
            default:
                break;
        }
    }
}
