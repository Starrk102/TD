using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewUniversalScriptableObject", menuName = "UniversalScriptableObject", order = 51)]
public class UniversalScriptableObject : ScriptableObject
{

    [SerializeField]
    public GameObject Obj;
    [SerializeField]
    public float ObjSpeed;
    [SerializeField]
    public float HealthEnemy;
    [SerializeField]
    public float HealthGreatTower;
    [SerializeField]
    public int DamageToGreatTower;
    [SerializeField]
    public int UpgraideCost;
    [SerializeField]
    public int AllGold;
    [SerializeField]
    public int GoldPerKillEnemy;
    [SerializeField]
    public int DamageTower;
    [SerializeField]
    public float DamagePerSecondTower;
    [SerializeField]
    public float RangeTower;
    [SerializeField]
    public int WaveCount;
    [SerializeField]
    public float PauseBetweenWaves;
    [SerializeField]
    public int MaxWave;

    //по такому же принципу добавить доп. свойства объекту

    public GameObject g_Obj
    {
        get
        {
            return g_Obj;
        }
    }
    public float g_ObjSpeed
    {
        get
        {
            return g_ObjSpeed;
        }
    }
    public float g_HealthEnemy
    {
        get
        {
            return g_HealthEnemy;
        }
    }
    public float g_HealthGreatTower
    {
        get
        {
            return g_HealthGreatTower;
        }
    }
    public int g_DamageToGreatTower
    {
        get
        {
            return g_DamageToGreatTower;
        }
    }
    public int g_UpgraideCost
    {
        get
        {
            return g_UpgraideCost;
        }
    }   
    public int g_AllGold
    {
        get
        {
            return g_AllGold;
        }
    }   
    public int g_GoldPerKillEnemy
    {
        get
        {
            return g_GoldPerKillEnemy;
        }
    }   
    public int g_DamageTower
    {
        get
        {
            return g_DamageTower;
        }
    }    
    public int g_DamagePerSecondTower
    {
        get
        {
            return g_DamagePerSecondTower;
        }
    }
    public int g_WaveCount
    {
        get
        {
            return g_WaveCount;
        }
    }    
    public float g_PauseBetweenWaves
    {
        get
        {
            return g_PauseBetweenWaves;
        }
    }
    public int g_MaxWave
    {
        get
        {
            return g_MaxWave;
        }
    }
}
