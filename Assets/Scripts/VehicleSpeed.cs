using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class VehicleSpeed : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textVehicleSpeed;

    private void Update()
    {
        textVehicleSpeed.text = MSSceneControllerFree.Instance.GetSpeed();
    }
}
