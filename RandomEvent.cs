using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEvent : MonoBehaviour {

    public Dictionary<GameObject, string> eventNames = new Dictionary<GameObject, string>();
    public Dictionary<GameObject, GameObject> eventImage = new Dictionary<GameObject, GameObject>();
    public SpriteRenderer baseObj;
    public float timer;

    public int numBuildings = 1;
    
    public GameObject[] buildings;
    public GameObject[] images;

	// Use this for initialization
	void Start () {
        //eventNames = new string[] { "meteor strike", "meatier strike", "school fire", "building fire", "bridge collapse", "charity ball", "free puppy day", "the opportunity to pop a large baloon full of glitter over a highly populated area" };
        baseObj = GameObject.Find("templateSprite").GetComponent<SpriteRenderer>();
        for(int x = 0; x <= numBuildings; x++)
        {
            eventNames.Add(buildings[x], "There is a fire!");
            eventImage.Add(buildings[x], images[x]);
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
	}

    void spawnObject()
    {
        int myNum = Random.Range(0, numBuildings);
        myNum = 0;
        GameObject key1 = buildings[myNum];
        baseObj.GetComponent<SpriteRenderer>().sprite = eventImage[buildings[myNum]].GetComponent<SpriteRenderer>().sprite;

        baseObj.transform.position = key1.transform.position;

    }
}
