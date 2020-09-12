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
    }
    public bool IsAlive => healthGreatTower > 0;

    public void ApplyDamage(float damage)
    {
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

    private void Update()
    {
        if (!IsAlive)
        {
            Time.timeScale = 0f;
        }
    }
}
