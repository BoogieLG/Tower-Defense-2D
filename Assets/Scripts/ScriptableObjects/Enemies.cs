using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Enemies", order = 1)]
public class Enemies : ScriptableObject
{
    public string EnemyName;
    public string Description;
    public int Damage;
    public int Reward;
    public float Health;
    public float MovementSpeed;
    public EnemyType enemyType;
    public Image image;
}
public enum EnemyType { simple, heavy };
