using UnityEngine;

public class StatsComponent : MonoBehaviour
{
    private string towerName;
    public string TowerName => towerName;
    private string shortDiscription;
    public string ShortDiscription => shortDiscription;
    private int cost;
    public int Cost => cost;
    private int sellingCost;
    public int SellingCost => sellingCost; 
    private float damage;
    public float Damage => damage;
    private float fireRate;
    public float FireRate => fireRate;
    private float colliderRadius;
    public float ColliderRadius => colliderRadius;
    private Towers towerToUpgrade;
    public Towers TowerToUpgrade => towerToUpgrade;

    public void Initiation(Towers towers)
    {
        towerName = towers.towerName;
        shortDiscription = towers.shortDiscription;
        cost = towers.towerCost;
        sellingCost = towers.towerSellingCost;
        damage = towers.damage;
        fireRate = towers.fireRate;
        colliderRadius = towers.colliderRadius;
        towerToUpgrade = towers.nextTowerForUpgrade;

    }


}
