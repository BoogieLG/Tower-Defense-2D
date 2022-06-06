using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManagment : MonoBehaviour
{
    public static ResourceManagment instance;
    [SerializeField] private int money;
    [SerializeField] Text text;
    public int Money { get => money; }

    private void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        UpdateInfo();
    }

    public void EarnReward(EnemyStatsComponent enemyStatsComponent)
    {
        money += enemyStatsComponent.EnemiesStats.Reward;
        UpdateInfo();
    }

    public void UseMoney(StatsComponent statsComponent)
    {
        if (money >= statsComponent.Cost) money -= statsComponent.Cost;
        UpdateInfo();
    } 

    public void SellTower(StatsComponent statsComponent)
    {
        money += statsComponent.Cost;
        UpdateInfo();
    }
    private void UpdateInfo()
    {
        text.text = money.ToString();
    }

}
