using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TowerUpgrade : MonoBehaviour
{
    private GameObject gO;
    private Text nameTower;
    private GameObject buttonDamage;
    private GameObject buttonDPS;
    private GameObject buttonClose;

    private void Start()
    {
        gO = GameObject.FindGameObjectWithTag("UI");
        nameTower = gO.transform.GetChild(1).transform.GetComponent<Text>();
        buttonDamage = gO.transform.GetChild(0).transform.GetChild(0).gameObject;
        buttonDPS = gO.transform.GetChild(0).transform.GetChild(1).gameObject;
        buttonClose = gO.transform.GetChild(0).transform.GetChild(2).gameObject;
        gO.SetActive(false);
    }

    private void Update()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray raycastTouch = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;

            if(Physics.Raycast(raycastTouch, out raycastHit))
            {
                if(raycastHit.collider.CompareTag("Tower"))
                {
                    var go = raycastHit.collider.gameObject;
                    Tower(go);
                }
            }   
        }

        if(Input.GetMouseButtonDown(0))
        { 
            Ray raycastMouse = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;

            if (Physics.Raycast(raycastMouse, out raycastHit))
            {
                if (raycastHit.collider.CompareTag("Tower"))
                {
                    var go = raycastHit.collider.gameObject;
                    
                    if (gO.activeSelf == false)
                    {
                        Tower(go);
                    }
                }
            }
        }

        if(gO.activeSelf == false)
        {
            Destroy(buttonDamage.GetComponent<EventTrigger>());
            Destroy(buttonDPS.GetComponent<EventTrigger>());
            Destroy(buttonClose.GetComponent<EventTrigger>());
        }
    }

    public void Tower(GameObject gameObject)    
    {
        gO.SetActive(true);
        nameTower.text = gameObject.name;
        DamageUpgrade(gameObject);
        DPSUpgrade(gameObject);
        CloseUI(gameObject);
    }

    public void DamageUpgrade(GameObject gameObject)
    {
        EventTrigger trigger = buttonDamage.gameObject.AddComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener((eventData) => { gameObject.GetComponent<Tower>().DamageUpgrade(); });
        trigger.triggers.Add(entry);
    }

    public void DPSUpgrade(GameObject gameObject)
    {
        EventTrigger trigger = buttonDPS.gameObject.AddComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener((eventData) => { gameObject.GetComponent<Tower>().DPSUpgrade(); });
        trigger.triggers.Add(entry);
    }

    public void CloseUI(GameObject gameObject)
    {
        gameObject = gO;
        EventTrigger trigger = buttonClose.gameObject.AddComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener((eventData) => { Close(); });
        trigger.triggers.Add(entry);
    }

    public void Close()
    {
        gO.SetActive(false);
    }
}
