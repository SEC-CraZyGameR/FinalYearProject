using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampPostController : MonoBehaviour
{
    public GameObject redLight;
    public GameObject yellowLight;
    public GameObject greenLight;

    public bool isSafe = false;
    public bool startSignalRoutine = false;

    private void Start()
    {
        StartCoroutine(ActivateRedLight(true));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            StartCoroutine(ActivateRedLight(false));
        }
    }

    public IEnumerator ActivateRedLight(bool isFirstTime)
    {
        DeactiveAllLight();
        redLight.SetActive(true);
        if (!isFirstTime)
        {
            yield return new WaitForSeconds(5.0f);
            StartCoroutine(ActivateYellowLight());
        }
    }

    private IEnumerator ActivateYellowLight()
    {
        DeactiveAllLight();
        yellowLight.SetActive(true);
        yield return new WaitForSeconds(5.0f);
        StartCoroutine(ActivateGreenLight());
    }

    private IEnumerator ActivateGreenLight()
    {
        DeactiveAllLight();
        greenLight.SetActive(true);
        isSafe = true;
        yield return new WaitForSeconds(15.0f);
        isSafe = false;
        StartCoroutine(ActivateRedLight(false));
    }

    private void DeactiveAllLight()
    {
        redLight.SetActive(false);
        greenLight.SetActive(false);
        yellowLight.SetActive(false);
    }
}