﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class persistantVariables : MonoBehaviour {

    public int totalMoney;
    private int totalFame;
    public string name;
    public bool hoverOver;
    public GameObject pointerText;
    public TextMeshProUGUI pointerGuiText;

    public Vector3 textOffset;
    public Canvas myCanvas;

    public ParticleSystem pSyst;

	// Use this for initialization
	void Start () {
        pointerText = GameObject.Find("toolTip");
        pointerGuiText = pointerText.GetComponent<TextMeshProUGUI>();
        pointerText.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(hoverOver)
        {
            pointerText.SetActive(true);
            pointerText.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition + textOffset).x, Camera.main.ScreenToWorldPoint(Input.mousePosition + textOffset).y, 1);
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
