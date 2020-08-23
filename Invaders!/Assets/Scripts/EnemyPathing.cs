using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] private WaveConfig _waveConfig;
    private List<Transform> _waypoints;
    [SerializeField] private float moveSpeed = 2f;
    private int waypointIndex;


    private void Start()
    {
        _waypoints = _waveConfig.GetWaypoints();
        transform.position = _waypoints[waypointIndex].position;
    }


    void Update()
    {
        Move();
    }


    private void Move()
    {
        if (waypointIndex < _waypoints.Count)
        {
            var targetPosition = _waypoints[waypointIndex].transform.position;
            var movementThisFrame = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}