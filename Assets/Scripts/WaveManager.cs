using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public bool waveSpawnComplete = false;
    
    public void SpawnWave(int waveNumber, float spawnStartDelay, float spawnRate)
    {
        waveSpawnComplete = false;
        StartCoroutine(SpawnDelay(waveNumber, spawnStartDelay, spawnRate));           
    }

    IEnumerator SpawnDelay(int waveNumber, float delay, float spawnrate)
    {
        yield return new WaitForSeconds(delay);
        StartCoroutine(SpawnRate(spawnrate, waveNumber + 1));       
    }

    IEnumerator SpawnRate(float delay, int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            RefManager.Instance.enemySpawner.GetComponent<EnemySpawner>().SpawnEnemy();
            yield return new WaitForSeconds(delay);
        }

        waveSpawnComplete = true;
    }
}
