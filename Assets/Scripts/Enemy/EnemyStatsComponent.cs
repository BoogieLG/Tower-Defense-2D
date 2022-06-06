using UnityEngine;

public class EnemyStatsComponent : MonoBehaviour
{
    [SerializeField] HealthComponent healthComponent;
    [SerializeField] MovementComponent movementComponent;
    [SerializeField] AttackComponent attackComponent;

    private Enemies enemiesStats;
    public Enemies EnemiesStats => enemiesStats;

    public void Init(Enemies enemy, Waypoints waypoints)
    {
        enemiesStats = enemy;

        healthComponent.Init(enemy.Health);
        movementComponent.Init(enemy.MovementSpeed, waypoints);
        //attackComponent.Init(damage);
    }

    public void EarnMoney()
    {
        ResourceManagment.instance.EarnReward(this);
    }
    private void OnDestroy()
    {
        
    }
}
