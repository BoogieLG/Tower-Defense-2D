using System;
using UnityEngine;

public class AttackComponent : MonoBehaviour
{
    public float BulletSpeed => tower.bulletSpeed;
    public float Damage { get => tower.damage; }

    private Towers tower;
    private float timer;

    public void Init(Towers tower)
    {
        this.tower = tower;
        timer = 0f;
    }

    private void Update()
    {
        if(timer >= 0f)
        {
            timer -= Time.deltaTime;
        }
    }
    public void ApplyDamage(HealthComponent healthComponent)
    {
        if (timer > 0) return;
        if (tower.fireEffect) tower.fireEffect.Play();
        ObjectPooler.instance.SpawnFromPool(tower.bulletType, transform.position, healthComponent, this);
        timer = 60/tower.fireRate;
        if (AudioSingletone.instance) AudioSingletone.instance.PlaySound(tower.audioMakeFire);
    }


}

