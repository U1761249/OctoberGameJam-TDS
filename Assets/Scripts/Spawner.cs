using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public int wave = 0;
    public Text waveDisplay;
    public int bossCount = 0;
    public GameObject enemy;
    public GameObject boss;
    public Transform[] spawnSpots;
    public float startTimeBtwSpawns;

    
    public int spawnCount = 0;
    public float timeBtwSpawns = 0.0f;


    void nextWave()
    {
        wave++;
        waveDisplay.text = "Wave: " + wave;
        timeBtwSpawns = 5 - (wave % 5);
        spawnCount = (wave * 2) + 10;
        if ((wave % 5) == 0)
        { bossCount = 1; }
        }

    private void Start()
    {
        nextWave();
    }

    private void Update()
    {
        if ((wave % 5) == 0 && bossCount > 0) {
            int randPos = UnityEngine.Random.Range(0, spawnSpots.Length);
            Instantiate(boss, spawnSpots[randPos].position, Quaternion.identity);
            bossCount--;
        }

        if (spawnCount <= 0 && !enemiesRemain()) {
            nextWave();
        }

        if (timeBtwSpawns <= 0 && spawnCount > 0)
        {
            
            spawn();
            timeBtwSpawns = startTimeBtwSpawns;
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }

    private void spawn()
    {
        int randPos = UnityEngine.Random.Range(0, spawnSpots.Length);
        Instantiate(enemy, spawnSpots[randPos].position, Quaternion.identity);
        spawnCount--;

    }

    private Boolean enemiesRemain() {
        if (GameObject.Find("Enemy") != null)
        {
            return true;
        }
        else {
            return false;
        }
    }

   
}
