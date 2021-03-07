using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    private static SoundManager instance = null;

    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<SoundManager>();

                if (instance == null)
                {

                    GameObject soundManager = new GameObject("SoundManager");
                    instance = soundManager.AddComponent<SoundManager>();
                }
            }
            return instance;
        }
    }

    private AudioSource _audioSource;

    [SerializeField] AudioClip btnTap;

    private void Awake()
    {
        if (instance == null) instance = this;

        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayBtnSound()
    {
        _audioSource.PlayOneShot(btnTap);
    }
}
