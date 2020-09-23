using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance = null;
    public Image imgCircle;
    public GameObject canvasCamera;

    private void Start()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Update()
    {

    }

    public void ButtonClickResponse(int buttonId)
    {
        Debug.Log(buttonId);
    }
}
