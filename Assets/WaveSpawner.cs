using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Waves[] waves;

    public Waves currentWave;

    [SerializeField]
    private Transform[] spawnPoints;

    private float spawnTime;
    private int i = 0;

    private bool stopSpawns = false;

    private void Awake()
    {
        currentWave = waves[i];
        spawnTime = currentWave.TimeBeforeThisWave;
    }//end Awake

    private void Update()
    {
        if (stopSpawns)
        {
            return;
        }
        if (Time.time >= spawnTime)
        {
            SpawnWave();
            IncWave();

            spawnTime = Time.time + currentWave.TimeBeforeThisWave;
        }

    }//end Update

    private void SpawnWave()
    {

        for (int i = 0; i < currentWave.EnemiesInQue; i++)
        {
            int ranNum1 = Random.Range(0, currentWave.EnemiesAlive.Length);
            int ranNum2 = Random.Range(0, spawnPoints.Length);

            Instantiate(currentWave.EnemiesAlive[ranNum1], spawnPoints[ranNum2].position, spawnPoints[ranNum2].rotation);
        }
    }//end SpawnWave

    private void IncWave()
    {
        if (i + 1 < waves.Length)
        {

            i++;
            currentWave = waves[i];

        }
        else
        {
            stopSpawns = true;
        }
    }

}
