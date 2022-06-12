using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBase : MonoBehaviour
{
    [SerializeField] private int BaseHealth;
    private void OnTriggerEnter(Collider other)
    {
      if(other.TryGetComponent<EnemyController>(out EnemyController enemyController))
        {
            BaseHealth -= enemyController.EnemiesStats.DamageToBase;
            if (BaseHealth <= 0)
            {
                Debug.Log("GameOVer");
            }
        }
    }
}
