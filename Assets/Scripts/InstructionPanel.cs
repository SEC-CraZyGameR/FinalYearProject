using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using TextSpeech;
using UnityEngine.Serialization;
using DG.Tweening;

public class InstructionPanel : MonoBehaviour
{
    [Header("LevelData Scriptable object")]
    [SerializeField]
    private LevelData_SO levelDataSo;
    [SerializeField]
    private TextMeshProUGUI txtInstruction;
    [Space(10)]
    [SerializeField] Image imgRoadSign;

    private string _signDescription;
    private string _signApplication;
    private string _signLocation;
    private LevelInfo _levelInfo;

    private readonly WaitForSeconds _threeSeconds = new WaitForSeconds(3.0f);
    private readonly WaitForSeconds _oneSeconds = new WaitForSeconds(1.0f);

    public void Start()
    {
        _levelInfo = levelDataSo.GetLevelInfo("0");
        AssignValues();
        SetSignInformation();

        StartCoroutine(StartSpeech());
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private IEnumerator StartSpeech()
    {
        txtInstruction.SetText(_signDescription);
        VoiceController.Instance.StartSpeak(_signDescription,OnDescriptionDone);

        yield return _oneSeconds;
    }

    private void OnDescriptionDone()
    {
        txtInstruction.SetText(_signApplication);
        VoiceController.Instance.StartSpeak(_signApplication,OnApplicationDone);
    }

    private void OnApplicationDone()
    {
        txtInstruction.SetText(_signLocation);
        VoiceController.Instance.StartSpeak(_signLocation);
    }

    private void SetSignInformation()
    {
        _signDescription = _levelInfo.signInfo.signDescription;
        _signApplication = _levelInfo.signInfo.signApplication;
        _signLocation = _levelInfo.signInfo.signLocation;
    }

    private void AssignValues()
    {
        imgRoadSign.sprite = _levelInfo.levelSprite;
    }
}