using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreatTower : MonoBehaviour
{
    public UniversalScriptableObject GreatTowerScriptableObject;
    private float healthGreatTower;
    private float gold;
    private void Start()
    {
        healthGreatTower = GreatTowerScriptableObject.HealthGreatTower;
        gold = GreatTowerScriptableObject.AllGold;
    }
    public bool IsAlive => healthGreatTower > 0;

    public void ApplyDamage(float damage)
    {
        if(damage < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(damage));
        }

        healthGreatTower -= damage;
    }

    public float Gold(float value)
    {
        return gold += value;
    }

    public float AllGold()
    {
        return gold;
    }

    public float _healthGreatTower()
    {
        return healthGreatTower;
    }
}
