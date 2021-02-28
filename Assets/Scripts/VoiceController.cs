using System;
using System.Collections;
using System.Collections.Generic;
using TextSpeech;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.Events;
using System.Speech.Synthesis;

public class VoiceController : MonoBehaviour
{
    private const string bd_locale = "en_US";
    [SerializeField] float pitch = 1.0f;
    [SerializeField] float rate = 1.0f;

    private UnityAction _onSpeechDone;

    #region Singleton
    static VoiceController _instance;
    public static VoiceController Instance
    {
        get
        {
            if (_instance == null)
            {
                Init();
            }
            return _instance;
        }
    }
    public static void Init()
    {
        if (_instance != null) return;
        GameObject obj = new GameObject
        {
            name = "VoiceController"
        };
        _instance = obj.AddComponent<VoiceController>();
    }
    void Awake()
    {
        _instance = this;
    }

    #endregion

    public void Start()
    {
        TextToSpeech.instance.onDoneCallback += OnSpeechDone;

        Setting(bd_locale);
        CheckAndoidPermission();
    }

    private void OnSpeechDone()
    {
        if (_onSpeechDone != null)
        {
            _onSpeechDone.Invoke();
        }
    }

    private void CheckAndoidPermission()
    {
#if UNITY_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }
#endif
    }
    public void Setting(string _code)
    {
        TextToSpeech.instance.Setting(_code, pitch, rate);
    }

    public void StartSpeak(string _data,UnityAction onSpeechDone = null)
    {
        _onSpeechDone = onSpeechDone;
        TextToSpeech.instance.StartSpeak(_data);
        TextToSpeech.instance.onDoneCallback();
    }

    public void StopSpeak() => TextToSpeech.instance.StopSpeak();
}
