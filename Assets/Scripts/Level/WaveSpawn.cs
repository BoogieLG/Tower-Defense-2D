using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawn : MonoBehaviour
{
    [SerializeField] private GameObject enemyToSpawn;
    [SerializeField] private Transform enemiesPanel;
    [SerializeField] private Waypoints wayPath;
    [SerializeField] private float timeBetweenEnemies;
    [SerializeField] private float timeBetweenWaves;
    [SerializeField] private Text timeCountWave;
    [SerializeField] private Text wavesCount;

    [SerializeField] private List<Wave> waves;
    private int currentWave = 0;

    private void FixedUpdate()
    {
        if (currentWave == waves.Count)
        {
            checkForLastEnemy();
            return;
        }
        if (timeBetweenWaves > 0)
        {
            timeBetweenWaves -= Time.fixedDeltaTime;
            return;
        }
        spawnEnemy(waves[currentWave]);
    }

    private void checkForLastEnemy()
    {
        if (enemiesPanel.childCount == 0) win();
    }
    private void spawnEnemy(Wave wave)
    {
        if (timeBetweenEnemies > 0)
        {
            timeBetweenEnemies -= Time.fixedDeltaTime;
            return;
        }
        GameObject tempEnemy = ObjectPooler.instance.SpawnFromPool("Enemy", transform.position);
        tempEnemy.GetComponent<EnemyController>().Init(wave.enemies, wayPath);
        tempEnemy.transform.SetParent(enemiesPanel);
        wave.Count -= 1;
        timeBetweenEnemies = wave.timeBetweenSpawn;
        if (wave.Count == 0)
        {
            timeBetweenWaves = wave.timeToNextWave;
            currentWave++;
        }
    }
    private void win()
    {
        Debug.Log("Win");
    }
}

[Serializable]
public class Wave
{
    public float Count;
    public Enemies enemies;
    public float timeBetweenSpawn = 0.5f;
    public float timeToNextWave = 10f;
    public float multiplierOfLevel;
}
