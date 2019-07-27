using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class moneyFame : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler {

    public int money;
    public int fame;
    public int cost;
    public int moneyMultiplier;
    public float coolDown;
    public float coolTimer;
    public persistantVariables pers;

    public string myText;

    public Image myImage;

	// Use this for initialization
	void Start () {

        pers = GameObject.Find("persistant").GetComponent<persistantVariables>();
        myImage = gameObject.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(coolTimer < coolDown)
        {
            coolTimer += Time.deltaTime;
            myImage.fillAmount = coolTimer / coolDown;
        }
		
	}


    public void OnPointerClick(PointerEventData eventData)
    {
        if (coolTimer >= coolDown)
        {
            coolTimer = 0;
            pers.addFame(fame);
            pers.addMoney(money);
            money = pers.getMoney();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        pers.hoverOver = true;
        pers.pointerGuiText.text = myText;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        pers.hoverOver = false;
        pers.pointerText.SetActive(false);
        pers.pointerGuiText.text = "";
    }
}
