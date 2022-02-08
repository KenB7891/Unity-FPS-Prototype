using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : ItemSpawner
{
    public GameObject[] powerupList;

    void Start()
    {
        spawnReady = true;
        spawnDelay = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        if (SpawnReady())
        {
            StartCoroutine(PowerupSpawn(spawnDelay));
        }
    }

    IEnumerator PowerupSpawn(float delay)
    {
        yield return new WaitForSeconds(delay);
        GameObject powerup = powerupList[UnityEngine.Random.Range(0, powerupList.Length)];
        Spawn(powerup);
    }
}
