using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperBulletController : BulletController
{
    public override void MakeDamage()
    {
        Enemies enemy = target.gameObject.GetComponent<EnemyController>().EnemiesStats;
        if (enemy.enemyType == EnemyType.heavy)
        {
            target.TakeDamage(attackComponent.Damage*3);
        }
        else
        {
            target.TakeDamage(attackComponent);
        }

        gameObject.SetActive(false);
    }
}
