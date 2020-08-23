using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject pathPrefab;
    [SerializeField] private float timeBetweenSpawns = .5f;
    [SerializeField] private float spawnRandomFactor = .3f;
    [SerializeField] private int numberOfEnemies = 5;
    [SerializeField] private float moveSpeed = 2f;

    public GameObject EnemyPrefab => enemyPrefab;

    public float TimeBetweenSpawns => timeBetweenSpawns;

    public float SpawnRandomFactor => spawnRandomFactor;

    public int NumberOfEnemies => numberOfEnemies;

    public float MoveSpeed => moveSpeed;


    public List<Transform> GetWaypoints()
    {
        var waveWaypoints = new List<Transform>();
        foreach (Transform waypoint in pathPrefab.transform)
        {
            waveWaypoints.Add(waypoint);
        }

        return waveWaypoints;
    }
}