using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public UniversalScriptableObject TowerScriptableObject;
    private Transform target;

    private float fireRate;
    private float fireCoundown;
    private LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        fireRate = TowerScriptableObject.DamagePerSecondTower;
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= TowerScriptableObject.RangeTower)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    private void Update()
    {
        if(target == null)
        {
            return;
        }

        if (fireCoundown <= 0)
        {
            Shoot();
            fireCoundown = 1.0f / fireRate;
        }

        fireCoundown -= Time.deltaTime;
    }

    void Shoot()
    {
        float distanceToEnemy = Vector3.Distance(transform.position, target.transform.position);
        if(distanceToEnemy <= TowerScriptableObject.RangeTower)
        {
            StartCoroutine(CreateLineRender());
            target.GetComponent<Enemy>().ApplyDamage(TowerScriptableObject.DamageTower);
        }
    }

    IEnumerator CreateLineRender()
    {
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, transform.GetChild(0).transform.GetChild(0).position);
        lineRenderer.SetPosition(1, target.GetChild(0).transform.GetChild(0).position);
        lineRenderer.startWidth = 0.2f;
        lineRenderer.endWidth = 0.1f;
        yield return new WaitForSeconds(0.1f);
        lineRenderer.positionCount = 0;
    }
}
