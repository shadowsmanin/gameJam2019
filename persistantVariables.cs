using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class persistantVariables : MonoBehaviour {

    private int totalMoney;
    private int totalFame;
    public string name;
    public bool hoverOver;
    public GameObject pointerText;

    public Vector3 textOffset;
    public Canvas myCanvas;

	// Use this for initialization
	void Start () {
        pointerText = GameObject.Find("toolTip");
        pointerText.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(hoverOver)
        {
            pointerText.SetActive(true);
            pointerText.transform.position = Input.mousePosition + textOffset;
        }
	}

    public int getMoney()
    {
        return totalMoney;
    }

    public int getFame()
    {
        return totalFame;
    }

    public void addFame(int x)
    {
        totalFame += x;
    }

    public void addMoney(int x)
    {
        totalMoney += x;
    }
}
