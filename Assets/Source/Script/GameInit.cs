using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameInit : MonoBehaviour
{
    [SerializeField]
    private Transform SpawnPoint;

    public UniversalScriptableObject EnemyScriptableObject;
    public UniversalScriptableObject EnemyUpgradeScriptableObject;
    private float countdown;
    private int waveNumber = 1;

    private bool NoSpawnEnemy;

    private void Start()
    {
        EnemyUpgradeScriptableObject.HealthEnemy = 0;
        EnemyUpgradeScriptableObject.GoldPerKillEnemy = 0;
        EnemyUpgradeScriptableObject.DamageToGreatTower = 0;
        countdown = 1.0f;
        InvokeRepeating("CheckEnemy", 0, 1f);
    }

    private void Update()
    {
        if (countdown <= 0.0f && NoSpawnEnemy == true)
        {
            StartCoroutine(SpawnWave());
            countdown = EnemyScriptableObject.PauseBetweenWaves;
        }

        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        if (waveNumber % 3 == 0)
        {
            UpdateEnemyToWave();
        }

        var MaxCountEnemy = waveNumber + 3;
        var RandomMaxCountWave = Random.Range(waveNumber, MaxCountEnemy);

        for (int i = 0; i < RandomMaxCountWave; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        waveNumber++;

    }

    void UpdateEnemyToWave()
    {
        EnemyUpgradeScriptableObject.HealthEnemy += 1;
        EnemyUpgradeScriptableObject.GoldPerKillEnemy += 5;
        EnemyUpgradeScriptableObject.DamageToGreatTower += 1;
    }

    void SpawnEnemy()
    {
        Instantiate(EnemyScriptableObject.Obj, SpawnPoint.position, SpawnPoint.rotation);
    }

    bool CheckEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        
        if (enemies.Length == 0)
        {
            return NoSpawnEnemy = true;
        }
        else
        {
            return NoSpawnEnemy = false;
        }
    }

    public int g_waveNumber()
    {
        return waveNumber;
    }
}
