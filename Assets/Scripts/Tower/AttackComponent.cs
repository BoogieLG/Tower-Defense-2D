using System;
using UnityEngine;

public class AttackComponent : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float bulletSpeed;
    public float BulletSpeed => bulletSpeed;
    [SerializeField] private float fireRate;
    public float FireRate => fireRate;
    [SerializeField] private ParticleSystem partical;

    public Action OnMakingAttack { get; set; }
    public float Damage { get => damage; }

    private float timer;
    private void Update()
    {
        if(timer >= 0f)
        {
            timer -= Time.deltaTime;
        }
    }
    public void Init(float damage, float bulletSpeed, float fireRate)
    {
        this.damage = damage;
        this.bulletSpeed = bulletSpeed;
        this.fireRate = fireRate;
        timer = 0f;
    }
    public void ApplyDamage(HealthComponent healthComponent)
    {
        if (timer > 0) return;
        if(partical) partical.Play();
        OnMakingAttack?.Invoke();
        ObjectPooler.instance.SpawnFromPool("Fast", transform.position, healthComponent, this);
        timer = fireRate;
    }


}

