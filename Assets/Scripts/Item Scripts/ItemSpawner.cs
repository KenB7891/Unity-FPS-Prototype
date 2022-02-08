using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    private Vector3 spawnPosition;

    public float spawnDelay;
    public bool spawnReady;
    public int coinValue;

    public bool SpawnReady()
    {
        if (!RefManager.Instance.gameManager.GetComponent<GameManager>().isLevelComplete && spawnReady == true)
        {
            spawnReady = false;
            return true;
        }
        else
        {
            return false;
        }
    }   

    public void Spawn(GameObject spawnObject)
    {
        spawnPosition.x = Random.Range(25, 55);
        spawnPosition.y = 1f;
        spawnPosition.z = Random.Range(23, 38);

        GameObject item = Instantiate(spawnObject, spawnPosition, Quaternion.identity) as GameObject;
        item.transform.rotation = Quaternion.AngleAxis(45, Vector3.forward);
        item.transform.rotation = Quaternion.AngleAxis(45, Vector3.right);

        spawnReady = true;
    }
}
