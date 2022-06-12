using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameResourceManagment : MonoBehaviour
{
    public static InGameResourceManagment instance;
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

    public void EarnReward(EnemyController enemyStatsComponent)
    {
        money += enemyStatsComponent.EnemiesStats.Reward;
        UpdateInfo();
    }

    public void UseMoney(ControllerComponent controllerComponent)
    {
        if (money >= controllerComponent.Tower.towerCost) money -= controllerComponent.Tower.towerCost;
        UpdateInfo();
    } 

    public void SellTower(ControllerComponent controllerComponent)
    {
        money += controllerComponent.Tower.towerCost;
        UpdateInfo();
    }
    private void UpdateInfo()
    {
        text.text = money.ToString();
    }

}
