using UnityEngine;

[CreateAssetMenu(fileName = "Tower", menuName = "ScriptableObjects/Towers", order = 1)]
public class Towers : ScriptableObject
{
    public string towerName;
    public string levelOfTower;
    public int towerCost;
    public float damage;
    public float fireRate;
    public float bulletSpeed;
    public float colliderRadius;
    public GameObject towerToSpawn;
    public Sprite sprite;
    public Towers nextTowerForUpgrade;
}
