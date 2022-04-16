using UnityEngine;

public class EnemyStatsComponent : MonoBehaviour
{
    [SerializeField] HealthComponent healthComponent;
    [SerializeField] MovementComponent movementComponent;
    [SerializeField] AttackComponent attackComponent;


    private string enemyName;
    public string EnemyName { get => enemyName; }

    private string description;
    public string Description { get => description; }

    private int damage;
    public int Damage { get => damage; }

    private int reward;
    public int Reward { get => reward; }

    private float health;
    public float Health { get => health; }

    private float movementSpeed;
    public float MovementSpeed { get => movementSpeed; }

    private Waypoints _wayPoints;
    public Waypoints waypoints { get => _wayPoints; }

    public void Init(Enemies enemy, Waypoints waypoints)
    {
        enemyName = enemy.EnemyName;
        description = enemy.Description;
        damage = enemy.Damage;
        health = enemy.Health;
        movementSpeed = enemy.MovementSpeed;
        reward = enemy.Reward;

        healthComponent.Init(health);
        movementComponent.Init(MovementSpeed, waypoints);
        attackComponent.Init(damage);
    }

    public void EarnMoney()
    {
        ResourceManagment.instance.EarnReward(this);
    }
    private void OnDestroy()
    {
        
    }
}
