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
    private int waveNumber;
    public int killEnemy;
    private bool NoSpawnEnemy;
    public List<GameObject> enemies;
    private GameObject enemy;

    private void Awake()
    {
        Screen.autorotateToLandscapeRight = false;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.autorotateToPortrait = false;
        Screen.autorotateToLandscapeLeft = false;

        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
    private void Start()
    {
        Time.timeScale = 1;
        EnemyUpgradeScriptableObject.HealthEnemy = 0;
        EnemyUpgradeScriptableObject.GoldPerKillEnemy = 0;
        EnemyUpgradeScriptableObject.DamageToGreatTower = 0;
        countdown = 1.0f;
        waveNumber = 1;
    }

    private void Update()
    {
        Debug.Log(enemies.Count);
        CheckEnemy(enemies);

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
            enemies.Add(enemy);
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
        enemy = Instantiate(EnemyScriptableObject.Obj, SpawnPoint.position, SpawnPoint.rotation);
    }

    bool CheckEnemy(List<GameObject> gameObjects)
    {
        if (gameObjects.Count == 0)
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

    public int g_killEnemy()
    {
        return killEnemy;
    }
}
