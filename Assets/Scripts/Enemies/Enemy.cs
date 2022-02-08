using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : CharacterBase
{
    GameObject[] dropList;

    private Vector3 itemSpawnPosition;
    private bool dropItem;

    // Start is called before the first frame update
    void Start()
    {
        health = 4;
        damage = 2;
        speed = 6.0f;        
    }
        
    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {            
            int damage = other.gameObject.GetComponent<Bullet>().bulletDamage;
            health = TakeDamage(health, damage);
        }
    }

    int TakeDamage(int health, int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            ItemDrop();
            Player.score++;
            RefManager.Instance.enemySpawner.GetComponent<EnemySpawner>().enemiesAlive--;
            Destroy(gameObject);
            return 0;
        }
        else
        {
            return health;
        }
    }

    void ItemDrop()
    {        
        dropItem = Random.Range(0, 2) == 1 ? true : false;

        if (dropItem)
        {            
            itemSpawnPosition.x = transform.position.x;
            itemSpawnPosition.y = 1f;
            itemSpawnPosition.z = transform.position.z;

            dropList = RefManager.Instance.dropSpawner.GetComponent<DropSpawner>().dropList;            
            GameObject item = Instantiate(dropList[Random.Range(0, dropList.Length)], itemSpawnPosition, Quaternion.identity) as GameObject;
            item.transform.rotation = Quaternion.AngleAxis(90, Vector3.right);
        }
    }
}
