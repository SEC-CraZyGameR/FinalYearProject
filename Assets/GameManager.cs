using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    public bool isReadyForMove = false;

    public GameObject humanPrefab;
    [SerializeField] private int humanAmount;

    [HideInInspector]
    public List<Transform> waypoints = new List<Transform>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }


}
