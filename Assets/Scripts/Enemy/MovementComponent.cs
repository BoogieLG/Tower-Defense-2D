using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    
    [SerializeField] private float speed;

    private Transform[] waypoints;
    private Transform target;
    private int waypointIndex = 0;

    public void Init(float speed, Waypoints EnemyRoad)
    {
        this.speed = speed;
        waypoints = EnemyRoad.Init();
        target = waypoints[0];

    }

    public void ChangeSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        if(Vector2.Distance(transform.position,target.position) < 0.01f)
        {
            NextWayPoint();
        }
    }

    private void NextWayPoint()
    {
        if (waypointIndex >= waypoints.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        waypointIndex++;
        target = waypoints[waypointIndex];
    }
}
