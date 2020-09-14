using System;
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
    private GameObject go_restart;
    private float killenemy;
    

    private void Start()
    {
        go_restart = GameObject.FindGameObjectWithTag("GameController");
        healthEnemy = EnemyScriptableObject.HealthEnemy + EnemyUpgradeScriptableObject.HealthEnemy;
        goldPerKill = EnemyScriptableObject.GoldPerKillEnemy + EnemyUpgradeScriptableObject.GoldPerKillEnemy;
        damageToGreatTower = EnemyScriptableObject.DamageToGreatTower + EnemyUpgradeScriptableObject.DamageToGreatTower;
        player = GameObject.FindGameObjectWithTag("GreatTower");
    }

    public bool IsAlive => healthEnemy > 0;

    public void ApplyDamage(float damage)
    {
        if (damage < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(damage));
        }

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
            go_restart.GetComponent<GameInit>().killEnemy++;
            player.GetComponent<GreatTower>().Gold(goldPerKill);
            Destroy(this.gameObject);
        }
    }
}
