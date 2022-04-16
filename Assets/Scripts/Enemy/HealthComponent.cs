using System;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] EnemyStatsComponent enemyStatsComponent;
    [SerializeField] private float currentHealth;
    public float CurrentHealth => currentHealth;

    [SerializeField] private float maxHealth;
    public float MaxHealth => maxHealth;

    public Action<HealthComponent> OnDeath { get; set; }
    public Action<float, float> OnChangeHealth { get; set; }

    public void Init(float health)
    {
        maxHealth = health;
        currentHealth = maxHealth;
    }

    public void TakeDamage(AttackComponent attackComponent)
    {
        currentHealth -= attackComponent.Damage;
        OnChangeHealth?.Invoke(maxHealth, currentHealth);
        deathCheck();
    }

    private void deathCheck()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        OnDeath?.Invoke(this);
        enemyStatsComponent.EarnMoney();
    }
}
