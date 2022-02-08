using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : ItemSpawner
{
    float rotation;
    private bool coinCounted;

    // Start is called before the first frame update
    void Awake()
    {
        rotation = 0.4f;
        coinCounted = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotation);
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {            
            Destroy(gameObject);
            if (!coinCounted)
            {
                Player.coins += coinValue;
                coinCounted = true;
            }        
        }
    }
}
