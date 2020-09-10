using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyNavigation : MonoBehaviour
{
    public UniversalScriptableObject EnemyScriptableObject;
    private Transform targetEnemy;
    private int wavepointIndex;
    private float speed;

    private void Start()
    {
        wavepointIndex = 0;
        targetEnemy = Waypoints.WayPoint[wavepointIndex];
        speed = EnemyScriptableObject.ObjSpeed;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetEnemy.position, speed * Time.deltaTime);
        
        if(Vector3.Distance(transform.position, targetEnemy.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.WayPoint.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        wavepointIndex++;
        targetEnemy = Waypoints.WayPoint[wavepointIndex];
    }
}
