using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{    
    public int waveNumber = 1;
    public int totalWaves = 10;
    public bool isWaveComplete;
    public bool isLevelComplete = false;

    private GameObject waveManager;
    private GameObject enemySpawner;

    public Text waveNumberText;

    void Awake()
    {
        waveManager = RefManager.Instance.waveManager;
        enemySpawner = RefManager.Instance.enemySpawner;
    }

    // Start is called before the first frame update
    void Start()
    {
        waveNumberText.text = "Get ready for Wave " + waveNumber + "!";
        StartCoroutine(DisplayWaveText(2f));
        waveManager.GetComponent<WaveManager>().SpawnWave(waveNumber, 4f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (waveManager.GetComponent<WaveManager>().waveSpawnComplete == true && enemySpawner.GetComponent<EnemySpawner>().enemiesAlive == 0)
        {            
            if (waveNumber < totalWaves)
            {                
                waveNumber++;
                waveNumberText.text = "Get ready for Wave " + waveNumber + "!";
                StartCoroutine(DisplayWaveText(2f));
                
                waveManager.GetComponent<WaveManager>().SpawnWave(waveNumber + 1, 3f, 2f);                
            }
            else
            {
                isLevelComplete = true;
            }
        }
    }

    IEnumerator DisplayWaveText(float delay)
    {
        yield return new WaitForSeconds(delay);
        waveNumberText.text = "";
    }
}
