using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RandomEvent : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    public Dictionary<GameObject, string> eventNames = new Dictionary<GameObject, string>();
    public Dictionary<GameObject, GameObject> eventImage = new Dictionary<GameObject, GameObject>();
    public Dictionary<GameObject, Vector2Int> eventBonus = new Dictionary<GameObject, Vector2Int>();
    public Image baseObj;
    public float timer;

    public persistantVariables pers;

    public int numBuildings = 1;
    
    public GameObject[] buildings;
    public GameObject[] images;

    public string myText;

    public float dissapearTimer;

    public bool spawnedIn = false;

    public int myNum; //used for random building decision

	// Use this for initialization
	void Start () {
        pers = GameObject.Find("persistant").GetComponent<persistantVariables>();
        //eventNames = new string[] { "meteor strike", "meatier strike", "school fire", "building fire", "bridge collapse", "charity ball", "free puppy day", "the opportunity to pop a large baloon full of glitter over a highly populated area" };
        baseObj = GameObject.Find("templateSprite").GetComponent<Image>();
        for(int x = 0; x <= numBuildings; x++)
        {
            eventNames.Add(buildings[x], "There is a fire!");
            eventImage.Add(buildings[x], images[x]);
            eventBonus.Add(buildings[x], buildings[x].GetComponent<buildingScript>().myBonus);
        }
        
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        timer += Time.deltaTime;
		if(timer > 45)
        {
            timer = 0;
            spawnObject();
        }

        if(spawnedIn)
        {
            dissapearTimer += Time.deltaTime;
            baseObj.fillAmount = 1 - dissapearTimer / 6;
            if(dissapearTimer >= 6)
            {
                transform.position = new Vector3(0, 10000000, 0);
                dissapearTimer = 0;
                spawnedIn = false;
            }
        }
	}

    void spawnObject()
    {
        myNum = Random.Range(0, numBuildings);
        //myNum = 0;
        GameObject key1 = buildings[myNum];
        baseObj.sprite = eventImage[buildings[myNum]].GetComponent<Image>().sprite;
        baseObj.gameObject.transform.localScale = eventImage[buildings[myNum]].transform.localScale;
        myText = eventNames[buildings[myNum]];
        baseObj.transform.position = key1.transform.position;

        spawnedIn = true;

    }


    public void OnPointerClick(PointerEventData eventData)
    {
        transform.position = new Vector3(0, 10000000, 0);
        pers.addFame(eventBonus[buildings[myNum]].y);
        pers.addMoney(eventBonus[buildings[myNum]].x);
        dissapearTimer = 0;
        spawnedIn = false;
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
    }
}
