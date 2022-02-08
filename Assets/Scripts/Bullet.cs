using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 2500.0f;
    public int bulletDamage;
    public float bulletLifespan = 1f;

    private Rigidbody m_Rigidbody;

    private GameObject player;
    //private GameObject gun;

    void Awake()
    {
        player = RefManager.Instance.playerObject;
        // gun = RefManager.Instance.gun;
        m_Rigidbody = GetComponent<Rigidbody>();
        bulletDamage = player.GetComponent<Player>().damage; // + gun.GetComponent<Gun>().damage
    }

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody.AddForce(m_Rigidbody.transform.forward * bulletSpeed);
        Destroy(gameObject, bulletLifespan);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Powerup") || other.gameObject.CompareTag("Ammo"))
        {
            Player.shotsHit++;
        }

        if (!other.gameObject.CompareTag("Player") && !other.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
               
    }   
}
