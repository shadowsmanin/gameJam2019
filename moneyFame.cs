using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class moneyFame : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler {

    public int money;
    public int fame;
    public int cost;
    public int moneyMultiplier;
    public persistantVariables pers;

	// Use this for initialization
	void Start () {

        pers = GameObject.Find("persistant").GetComponent<persistantVariables>();
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
	}


    public void OnPointerClick(PointerEventData eventData)
    {
        pers.addFame(fame);
        pers.addMoney(money);
        money = pers.getMoney();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        pers.hoverOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        pers.hoverOver = false;
        pers.pointerText.SetActive(false);
    }
}
