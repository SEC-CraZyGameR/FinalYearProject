using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Human : MonoBehaviour
{
    public NavMeshAgent agent;
    public List<Transform> waypoints = new List<Transform>();
    private void Start()
    {
        waypoints = WayPointsManager.Instance.waypointsRight;
        HideWaypoints();
        Vector3 pos = waypoints[Random.Range(0, waypoints.Count)].position;
        agent.SetDestination(pos);
    }

    private void Update()
    {
        if (agent.remainingDistance < 3)
        {
            Vector3 newPos = waypoints[Random.Range(0, waypoints.Count)].position;
            agent.SetDestination(newPos);
        }
    }

    private void HideWaypoints()
    {
        for (int i = 0; i < waypoints.Count; i++)
        {
            waypoints[i].GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
