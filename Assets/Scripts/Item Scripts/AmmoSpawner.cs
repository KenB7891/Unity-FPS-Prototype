using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSpawner : ItemSpawner
{
    public GameObject[] ammoList;

    // Start is called before the first frame update
    void Start()
    {
        spawnReady = true;
        spawnDelay = 12f;
    }

    // Update is called once per frame
    void Update()
    {
        if (SpawnReady())
        {
            StartCoroutine(AmmoSpawn(spawnDelay));
        }
    }

    IEnumerator AmmoSpawn(float delay)
    {
        yield return new WaitForSeconds(delay);
        GameObject ammo = ammoList[Random.Range(0, ammoList.Length)];
        Spawn(ammo);
    }
}
