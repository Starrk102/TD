using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayer : MonoBehaviour
{
    public UniversalScriptableObject GreatTowerScriptableObject;
    private GameObject GO;
    private GameObject GreatTower;
    private Text t_gold;
    private Text t_health;
    private float gold;
    private float health;

    private void Start()
    {
        GO = gameObject;
        t_gold = GO.GetComponent<Transform>().GetChild(1).transform.GetChild(0).transform.GetComponent<Text>();
        t_health = GO.GetComponent<Transform>().GetChild(0).transform.GetChild(0).transform.GetComponent<Text>();
        GreatTower = GameObject.FindGameObjectWithTag("GreatTower");
    }
    private void Update()
    {
        gold = GreatTowerScriptableObject.AllGold + GreatTower.GetComponent<GreatTower>().AllGold();
        t_gold.text = gold.ToString();
    }
}
