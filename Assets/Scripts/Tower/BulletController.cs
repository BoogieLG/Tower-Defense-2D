using UnityEngine;

public class BulletController : MonoBehaviour
{
    protected HealthComponent target;
    protected AttackComponent attackComponent;

    private void Update()
    {
        if (!target) 
        {
            gameObject.SetActive(false);
            return;
        }
        if (Vector2.Distance(transform.position, target.transform.position) < 0.1f)
        {
            MakeDamage();
        }
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, attackComponent.BulletSpeed);
    }

    public virtual void MakeDamage()
    {
        target.TakeDamage(attackComponent);
        gameObject.SetActive(false);
    }

    public void SetTarget(HealthComponent newTarget, AttackComponent attack)
    {
        target = newTarget;
        attackComponent = attack;
    }
    
}
