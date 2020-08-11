using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointsManager : MonoBehaviour
{
    public static WayPointsManager Instance;

    public List<Transform> waypointsRight = new List<Transform>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
}
