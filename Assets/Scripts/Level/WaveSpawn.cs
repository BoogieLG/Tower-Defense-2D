using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

public class WaveSpawn : MonoBehaviour
{
    [SerializeField] private GameObject enemyToSpawn;
    [SerializeField] private Transform enemiesPanel;
    [SerializeField] private Waypoints wayPath;
    [SerializeField] private float countdown;
    [SerializeField] private float timeBetweenWaves;
    [SerializeField] private Text timeCountWave;
    [SerializeField] private Text wavesCount;

    [SerializeField] private List<Wave> waves;
    private int currentWave;
    private bool nextWave;


    private void Start()
    {
        currentWave = 0;
        nextWave = true;
    }

    void Update()
    {
        if (currentWave == waves.Count)
        {
            timeCountWave.text = "Last wave!";
            return;
        }
        if (countdown <= 0f)
        {
            if (!nextWave) return;
            spawnNextWave();
            nextWave = false;
            countdown = timeBetweenWaves;
        }
        timeCountWave.text = "Next Wave in " + Mathf.Round(countdown).ToString();
        countdown -= Time.deltaTime;
    }

    private void spawnNextWave()
    {
        if (currentWave <= waves.Count-1)
        {
            StartCoroutine(spawnNextEnemy(waves[currentWave]));
        }
        currentWave++;
        changeInfo();

    }

    IEnumerator spawnNextEnemy(Wave wave)
    { 

        foreach(Enemies enemy in wave.enemies)
        {
            GameObject tempEnemy = Instantiate(enemyToSpawn);
            tempEnemy.GetComponent<EnemyController>().Init(enemy,wayPath);
            tempEnemy.transform.SetParent(enemiesPanel);
            changeInfo();
            yield return new WaitForSeconds(wave.TimeBetweenSpawn);

        }
        nextWave = true;
        StopCoroutine("spawnNextEnemy");
    }

    private void changeInfo()
    {
        wavesCount.text = $"{currentWave} / {waves.Count}";
    }
}

[Serializable]
public class Wave
{
    public float TimeBetweenSpawn;
    public List<Enemies> enemies;
}
