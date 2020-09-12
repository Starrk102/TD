using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public UniversalScriptableObject EnemyScriptableObject;
    public UniversalScriptableObject EnemyUpgradeScriptableObject;
    private GameObject player;
    private float healthEnemy;
    private float goldPerKill;
    private float damageToGreatTower;

    private void Start()
    {
        healthEnemy = EnemyScriptableObject.HealthEnemy + EnemyUpgradeScriptableObject.HealthEnemy;
        goldPerKill = EnemyScriptableObject.GoldPerKillEnemy + EnemyUpgradeScriptableObject.GoldPerKillEnemy;
        damageToGreatTower = EnemyScriptableObject.DamageToGreatTower + EnemyUpgradeScriptableObject.DamageToGreatTower;
        player = GameObject.FindGameObjectWithTag("GreatTower");
    }

    public bool IsAlive => healthEnemy > 0;

    public void ApplyDamage(float damage)
    {
        healthEnemy -= damage;
    }

    public float DamageToGreatTower()
    {
        return damageToGreatTower;
    }

    public float GoldPerKill()
    {
        return goldPerKill;
    }

    private void Update()
    {
        if(!IsAlive)
        {
            player.GetComponent<GreatTower>().Gold(goldPerKill);
            Destroy(this.gameObject);
        }
    }
}
