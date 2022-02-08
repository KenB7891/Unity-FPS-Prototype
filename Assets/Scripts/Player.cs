using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : CharacterBase
{
    static public int ammo;
    static public int score;
    static public int coins;
    static public int shotsFired;
    static public int shotsHit;
    static public float shotAccuracy;
    static public int totalShotsFired;
    static public int totalShotsHit;
    static public float totalShotAccuracy;

    public bool isPlayerInvincible;

    public Text ammoDisplay;
    public Text healthDisplay;
    public Text scoreDisplay;
    public Text timeDisplay;

    // Start is called before the first frame update
    void Start()
    {
        health = 10;
        damage = 2;
        speed = 13.0f;
        fireRate = 2.0f; // Bullets per second
        ammo = 50;
        score = 0;
        isPlayerInvincible = false;
    }

    // Update is called once per frame
    void Update()
    {
        healthDisplay.text = "Health: " + health.ToString();
        ammoDisplay.text = "Ammo: " + ammo.ToString();
        scoreDisplay.text = "Score: " + score.ToString();
        if (!RefManager.Instance.gameManager.GetComponent<GameManager>().isLevelComplete)
        {
            int minutes = (int)Math.Floor(Time.timeSinceLevelLoad / 60);
            int seconds = (int)Time.timeSinceLevelLoad % 60;
            double hundreths = (Time.timeSinceLevelLoad * 100) - (minutes * 60 * 100) - (seconds * 100);
            timeDisplay.text = "Time: " + string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, hundreths);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            int damage = other.gameObject.GetComponent<Enemy>().damage;
            if (!isPlayerInvincible)
            {
                health = TakeDamage(health, damage);
            }

        }
    }

    int TakeDamage(int playerHealth, int damage)
    {
        playerHealth -= damage;
        if (playerHealth <= 0)
        {
            SceneManager.LoadScene("Menu 2");
            return 0;
        }
        else
        {
            return playerHealth;
        }
    }
}