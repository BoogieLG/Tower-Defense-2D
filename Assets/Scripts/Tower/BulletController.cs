using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private HealthComponent target;
    private AttackComponent attackComponent;
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (!target) 
        {
            gameObject.SetActive(false);
            return;
        }
        if (Vector2.Distance(transform.position, target.transform.position) < 0.1f)
        {
            target.TakeDamage(attackComponent);
            gameObject.SetActive(false);
        }
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, attackComponent.BulletSpeed);
    }
    public void SetTarget(HealthComponent newTarget, AttackComponent attack)
    {
        target = newTarget;
        attackComponent = attack;
    }
}
