using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointsManager : MonoBehaviour
{
    public static WayPointsManager Instance;

    public List<Transform> waypointsRight = new List<Transform>();

    public bool isReadyForMove = false;

    public GameObject humanPrefab;
    [SerializeField] private int humanAmount;

    [HideInInspector]
    public List<Transform> waypoints = new List<Transform>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        waypoints = waypointsRight;
        for (int i = 0; i < humanAmount; i++)
        {
            Vector3 pos = waypoints[Random.Range(0, waypoints.Count)].position;
            Instantiate(humanPrefab, pos, Quaternion.identity);
        }
    }
}
