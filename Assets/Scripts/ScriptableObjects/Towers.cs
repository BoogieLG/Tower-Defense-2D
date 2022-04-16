using UnityEngine;

[CreateAssetMenu(fileName = "Tower", menuName = "ScriptableObjects/Towers", order = 1)]
public class Towers : ScriptableObject
{
    public string towerName;
    public string shortDiscription;
    public int towerCost;
    public int towerSellingCost;
    public float damage;
    public float fireRate;
    public float colliderRadius;
    public GameObject towerToSpawn;
    public Towers nextTowerForUpgrade;
}
