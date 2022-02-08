using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ProjectileTrigger : MonoBehaviour
{
    public GameObject bullet;
    public AudioSource basicBullet;

    public Transform bulletSpawn;

    public bool isInfiniteAmmoActive; 
    
    private bool fireReady = true;

    // Start is called before the first frame update
    void Start()
    {
        isInfiniteAmmoActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && fireReady == true && Player.ammo > 0)
        {
            GetComponent<AudioSource>().time = GetComponent<AudioSource>().clip.length * 0.15f; 
            basicBullet.Play();
            Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);

            Player.shotsFired++;
            fireReady = false;
            if (!isInfiniteAmmoActive)
            {
                Player.ammo--;
            }
            
            float shotDelay = 1 / GetComponent<Player>().fireRate;
            StartCoroutine(GunCooldown(shotDelay));
        }
    }    

    IEnumerator GunCooldown(float delay)
    {
        yield return new WaitForSeconds(delay);
        fireReady = true;
    }
}
