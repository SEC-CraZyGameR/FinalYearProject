using System.Collections;
using System.Collections.Generic;
using TextSpeech;
using UnityEngine;
using UnityEngine.Android;

public class VoiceController : MonoBehaviour
{
    private const string bd_locale = "en_US";
    [SerializeField] float pitch = 1.0f;
    [SerializeField] float rate = 1.0f;

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
        if (Instance != null) return;
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
        Setting(bd_locale);
        CheckAndoidPermission();
    }

    public void CheckAndoidPermission()
    {
#if UNITY_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }
#endif
    }
    public void Setting(string _code) => TextToSpeech.instance.Setting(_code, pitch, rate);
    public void StartSpeak(string _data) => TextToSpeech.instance.StartSpeak(_data);
    public void StopSpeak() => TextToSpeech.instance.StopSpeak();
}
