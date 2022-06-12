using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] HealthComponent healthComponent;
    [SerializeField] MovementComponent movementComponent;
    [SerializeField] AttackComponent attackComponent;

    private Enemies enemiesStats;
    public Enemies EnemiesStats => enemiesStats;

    private void Start()
    {
        healthComponent.OnDeath += EarnMoney;
    }
    public void Init(Enemies enemy, Waypoints waypoints)
    {
        enemiesStats = enemy;

        healthComponent.Init(enemy.Health);
        movementComponent.Init(enemy.MovementSpeed, waypoints);
        //attackComponent.Init(damage);
    }

    public void EarnMoney(HealthComponent health)
    {
        InGameResourceManagment.instance.EarnReward(this);
    }
    private void OnDestroy()
    {
        healthComponent.OnDeath -= EarnMoney;
    }
}
