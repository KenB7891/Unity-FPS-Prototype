using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;
    public int enemiesAlive;
    private Vector3 spawnPosition;
    
    public void SpawnEnemy()
    {
        spawnPosition.x = Random.Range(25, 60);
        spawnPosition.y = 0.5f;
        spawnPosition.z = Random.Range(25, 40);

        Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPosition, Quaternion.identity);
        enemiesAlive++;
    }
}
