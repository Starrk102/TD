using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    private Text killedEnemys;
    private Text waveNumber;
    private GameObject RestartCanvas;
    private GameObject goGI;

    public void RestarScene()
    {
        SceneManager.LoadScene(0);
    }

    private void Start() 
    {
        RestartCanvas = gameObject;
        goGI = GameObject.FindGameObjectWithTag("GameController");
    }

    private void Update() 
    {
        killedEnemys = RestartCanvas.transform.GetChild(0).transform.GetChild(2).transform.GetChild(0).GetComponent<Text>();
        killedEnemys.text = goGI.GetComponent<GameInit>().g_killEnemy().ToString();
        waveNumber = RestartCanvas.transform.GetChild(0).transform.GetChild(3).transform.GetChild(0).GetComponent<Text>();
        waveNumber.text = goGI.GetComponent<GameInit>().g_waveNumber().ToString();
    }
}
