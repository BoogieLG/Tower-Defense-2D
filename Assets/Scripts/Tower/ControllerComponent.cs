using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerComponent : MonoBehaviour
{
    [SerializeField] private Towers tower;
    public Towers Tower => tower;

    [SerializeField] private AttackComponent attackComponent;
    [SerializeField] private HealthComponent currentTarget;
    [SerializeField] private ColliderComponent colliders;
    [SerializeField] private CircleCollider2D circleCollider;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private void Start()
    {
        colliders.OnRemovedFromList += checkTarget;
        colliders.OnChangedList += checkList;

    }
    private void OnDestroy()
    {
        colliders.OnRemovedFromList -= checkTarget;
        colliders.OnChangedList -= checkList;
    }

    public void Init(Towers tower)
    {
        this.tower = tower;
        attackComponent.Init(tower);
        circleCollider.radius = tower.colliderRadius;
        spriteRenderer.sprite = tower.sprite;
    }
    private void Update()
    {
        if (colliders.CollidersInRadius.Count == 0) return;
        else if (currentTarget == null)
        {
            makeNewTarget();
        }
        if (currentTarget != null)
        {
            attackComponent.ApplyDamage(currentTarget);
        }
    }


    private  void makeNewTarget()
    {
        currentTarget = null;
        if (colliders.CollidersInRadius.Count == 0) return;
        if (tower.bulletType == BulletType.Sniper)
        {
            int index = makeSniperTarget();
            if (index == -1) currentTarget = colliders.CollidersInRadius[0];
            else currentTarget = colliders.CollidersInRadius[index];
        }
        else
        {
            currentTarget = colliders.CollidersInRadius[0];
        }

    }
    private int makeSniperTarget()
    {
        int index = colliders.CollidersInRadius.FindIndex(t => t.enemyType == EnemyType.heavy);
        return index;
    }
    private void enemyDeath(HealthComponent temp)
    {
        colliders.RemoveFromList(temp);
    }

    private void checkTarget(HealthComponent temp)
    {
        if (currentTarget == temp) makeNewTarget();
    }
    private void checkList(HealthComponent temp, ColliderComponent.listChanged listChanged)
    {
        if (ColliderComponent.listChanged.Added == listChanged) temp.OnDeath += enemyDeath;
        if (ColliderComponent.listChanged.Removed == listChanged) temp.OnDeath -= enemyDeath;
    }

}
