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
    public int DamagePerSecondTower;
    [SerializeField]
    public int WaveCount;
    [SerializeField]
    public int PauseBetweenWaves;

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
    public float g_DamageToGreatTower
    {
        get
        {
            return g_DamageToGreatTower;
        }
    }
    public float g_UpgraideCost
    {
        get
        {
            return g_UpgraideCost;
        }
    }   
    public float g_AllGold
    {
        get
        {
            return g_AllGold;
        }
    }   
    public float g_GoldPerKillEnemy
    {
        get
        {
            return g_GoldPerKillEnemy;
        }
    }   
    public float g_DamageTower
    {
        get
        {
            return g_DamageTower;
        }
    }    
    public float g_DamagePerSecondTower
    {
        get
        {
            return g_DamagePerSecondTower;
        }
    }
    public float g_WaveCount
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
}
