using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CarCanvas : MonoBehaviour
{
    public static CarCanvas Instance = null;

    public TextMeshProUGUI txtDialogue;

    private void Start()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void ShowDialogue(string dialogue)
    {
        txtDialogue.text = dialogue;
    }
}
