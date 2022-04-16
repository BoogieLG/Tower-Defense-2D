using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawn : MonoBehaviour
{
    [SerializeField] private GameObject enemyToSpawn;
    [SerializeField] private Waypoints waypoints;
    [SerializeField] private float countdown;
    [SerializeField] private float timeBetweenWaves;
    [SerializeField] private float timeBettwenSpawnEnemies;
    [SerializeField] private int maxWawes;
    [SerializeField] private Text timeCountWave;
    [SerializeField] private List<Enemies> enemies;
    [SerializeField] private List<Enemies> enemiesToSpawn;

    private int currentWave;


    private void Start()
    {
        currentWave = 0;
    }

    void Update()
    {
        if (currentWave == maxWawes)
        {
            timeCountWave.text = "Last wave!";
            return;
        }
        if (countdown <= 0f)
        {
            spawnNextWave();
            countdown = timeBetweenWaves;
        }
        timeCountWave.text ="Next Wave in " + Mathf.Round(countdown).ToString();
        countdown -= Time.deltaTime;
    }

    private void spawnNextWave()
    {

        if (currentWave <= maxWawes-1)
        {
            currentWave++;
            StartCoroutine(spawnNextEnemy());
            Debug.Log($"Wave #{currentWave}");
        }

    }

    IEnumerator spawnNextEnemy()
    { 
        foreach(Enemies enemy in enemiesToSpawn)
        {
            GameObject tempEnemy = Instantiate(enemyToSpawn);
            tempEnemy.GetComponent<EnemyStatsComponent>().Init(enemy,waypoints);
            yield return new WaitForSeconds(timeBettwenSpawnEnemies);

        }
        addNewEnemiesToWave(currentWave);
        StopCoroutine("spawnNextEnemy");
    }

    private void addNewEnemiesToWave(int currentWave)
    {
        switch (currentWave)
        {
            case 1:
                enemiesToSpawn.Add(enemies[0]);
                break;
            case 2:
                enemiesToSpawn.Add(enemies[0]);
                enemiesToSpawn.Add(enemies[0]);
                break;
            default:
                enemiesToSpawn.Add(enemies[0]);
                break;
        }
    }
}
