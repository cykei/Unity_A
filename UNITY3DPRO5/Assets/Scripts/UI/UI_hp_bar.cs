﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UI_hp_bar : MonoBehaviour {

    public GameObject owner;
    public Text textHp;
    public Image hpBar;
    public float hpSize;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        try
        {
            float maxHp = owner.GetComponent<Avatar>().bv.maxHp;
            float hp = owner.GetComponent<Avatar>().bv.hp;
            float perHp = hp / maxHp;
            Vector2 size = hpBar.rectTransform.sizeDelta;
            size.x = perHp * hpSize;
            hpBar.rectTransform.sizeDelta = size;
            textHp.text = hp + " / " + maxHp;
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
        }
    }
}