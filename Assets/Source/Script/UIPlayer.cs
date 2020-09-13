using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayer : MonoBehaviour
{
    public UniversalScriptableObject GreatTowerScriptableObject;
    private GameObject go;
    private GameObject greatTower;
    private GameObject RestartUI;
    private Text t_gold;
    private Text t_health;
    private float gold;
    private float health;

    private void Start()
    {
        go = gameObject;
        t_gold = go.GetComponent<Transform>().GetChild(1).transform.GetChild(0).transform.GetComponent<Text>();
        t_health = go.GetComponent<Transform>().GetChild(0).transform.GetChild(0).transform.GetComponent<Text>();
        greatTower = GameObject.FindGameObjectWithTag("GreatTower");
        RestartUI = GameObject.FindGameObjectWithTag("Respawn");
        RestartUI.SetActive(false);
        t_gold.text = gold.ToString();
        health = greatTower.GetComponent<GreatTower>()._healthGreatTower();
        t_health.text = health.ToString();
    }


    private void Update()
    {
        t_gold.text = greatTower.GetComponent<GreatTower>().AllGold().ToString();
        health = greatTower.GetComponent<GreatTower>()._healthGreatTower();
        t_health.text = health.ToString();

        if(!greatTower.GetComponent<GreatTower>().IsAlive)
        {
            RestartUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
