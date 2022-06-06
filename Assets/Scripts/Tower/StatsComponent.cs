using UnityEngine;

public class StatsComponent : MonoBehaviour
{
    private string towerName;
    public string TowerName => towerName;

    private string levelOfTower;
    public string LevelOfTower => levelOfTower;

    private int cost;
    public int Cost => cost;

    private float damage;
    public float Damage => damage;

    private float fireRate;
    public float FireRate => fireRate;

    private float bulletSpeed;
    public float BulletSpeed => bulletSpeed;


    private float colliderRadius;
    public float ColliderRadius => colliderRadius;

    private Towers towerToUpgrade;
    public Towers TowerToUpgrade => towerToUpgrade;

    public void Initiation(Towers towers)
    {
        towerName = towers.towerName;
        levelOfTower = towers.levelOfTower;
        cost = towers.towerCost;
        damage = towers.damage;
        fireRate = towers.fireRate;
        bulletSpeed = towers.bulletSpeed;
        colliderRadius = towers.colliderRadius;
        towerToUpgrade = towers.nextTowerForUpgrade;

    }


}
