using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : BulletController
{
    private float colliderRadius;
    public List<HealthComponent> enemies;
    public LayerMask layerMask;
    private void Start()
    {
        layerMask = LayerMask.GetMask("Enemy");
        colliderRadius = gameObject.GetComponent<CircleCollider2D>().radius;
    }
    public override void MakeDamage()
    {
        int i = 0;
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(gameObject.transform.position, colliderRadius, layerMask);
        while (i < hitColliders.Length)
        {
            hitColliders[i].gameObject.GetComponent<HealthComponent>().TakeDamage(attackComponent);
            Debug.Log(hitColliders[i].name);
            i++;
        }
        target.TakeDamage(attackComponent);
        gameObject.SetActive(false);
    }
}
