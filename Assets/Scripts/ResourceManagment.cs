using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManagment : MonoBehaviour
{
    public static ResourceManagment instance;
    [SerializeField] private int money;
    public int Money { get => money; }

    private void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    
    public void EarnReward(EnemyStatsComponent enemyStatsComponent)
    {
        money += enemyStatsComponent.Reward;
    }

    public void UseMoney(StatsComponent statsComponent)
    {
        if (money >= statsComponent.Cost) money -= statsComponent.Cost;
    } 

    public void SellTower(StatsComponent statsComponent)
    {
        money += statsComponent.SellingCost;
    }

}
