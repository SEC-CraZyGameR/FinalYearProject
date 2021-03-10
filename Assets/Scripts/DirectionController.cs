using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IdirectionController
{
    void GiveDirection();
}

public class DirectionController : MonoBehaviour, IdirectionController
{
    [Multiline]
    [SerializeField] string _direction;


    private void Start()
    {
        GetComponent<Collider>().isTrigger = true;
        Destroy(GetComponent<Renderer>());
    }

    public void GiveDirection()
    {
#if UNITY_EDITOR
        Debug.Log(_direction);
#endif
        Destroy(GetComponent<Collider>());
        VoiceController.Instance.StartSpeak(_direction, OnComplete);
    }

    private void OnComplete()
    {
        Destroy(this.gameObject);
    }
}
