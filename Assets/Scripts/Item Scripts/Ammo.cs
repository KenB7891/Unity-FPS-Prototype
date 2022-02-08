using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public int ammoAmount = 10;

    float randomXRotation;
    float randomYRotation;
    float randomZRotation;

    public void Awake()
    {
        randomXRotation = Random.Range(-2, 3) * 0.1f;
        randomYRotation = Random.Range(-2, 3) * 0.1f;
        randomZRotation = Random.Range(-2, 3) * 0.1f;
    }

    // Update is called once per frame
    void Update()
    {        
        transform.Rotate(randomXRotation, randomYRotation, randomZRotation);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Bullet"))
        {
            Player.ammo += ammoAmount;
            Destroy(gameObject);            
        }
    }
}
