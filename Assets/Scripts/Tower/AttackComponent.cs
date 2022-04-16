using System;
using UnityEngine;

public class AttackComponent : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private ParticleSystem partical;

    public Action OnMakingAttack { get; set; }
    public float Damage { get => damage; }

    public void Init(float damage)
    {
        this.damage = damage;
    }
    public void ApplyDamage(HealthComponent healthComponent)
    {
        if(partical) partical.Play();
        healthComponent.TakeDamage(this);
        OnMakingAttack?.Invoke();
    }


}

