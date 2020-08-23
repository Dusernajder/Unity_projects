using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<WaveConfig> waveConfigs;
    private int _startingWave = 0;


    // Start is called before the first frame update
    void Start()
    {
        WaveConfig currentWave = waveConfigs[_startingWave];
        StartCoroutine(SpawnAllEnemiesInWave(currentWave));
    }


    private IEnumerator SpawnAllEnemiesInWave(WaveConfig currentWave)
    {
        Instantiate(currentWave.EnemyPrefab,
            currentWave.GetWaypoints()[0].transform.position,
            Quaternion.identity
        );
        yield return new WaitForSeconds(currentWave.TimeBetweenSpawns);
    }
}