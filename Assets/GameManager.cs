using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject humanPrefab;
    [SerializeField] private int humanAmount;

    [HideInInspector]
    public List<Transform> waypoints = new List<Transform>();

    private void Start()
    {
        waypoints = WayPointsManager.Instance.waypointsRight;
        for (int i = 0; i < humanAmount; i++)
        {
            Vector3 pos = waypoints[Random.Range(0, waypoints.Count)].position;
            Instantiate(humanPrefab, pos, Quaternion.identity);
        }
    }
}
