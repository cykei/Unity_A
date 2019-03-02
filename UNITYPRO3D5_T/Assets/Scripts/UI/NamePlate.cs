using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class NamePlate : MonoBehaviour {

    public Text textName;
    public GameObject owner = null;

    public Image hpBar;

    // Use this for initialization
    void Start () {
        hpBar = transform.GetChild(1).GetChild(2).GetChild(0).GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        try
        {
            if (owner == null)
            {
                
                return;
            }
            Vector3 ownerPos = owner.transform.position;
            //textName.text = owner.name;
            Vector3 pos = Camera.main.WorldToScreenPoint(ownerPos);
            pos.z = 0;
            transform.position = pos;


   
            float maxHp = owner.GetComponent<Enemy>().bv.maxHp;
            float hp = owner.GetComponent<Enemy>().bv.hp;
            float perHp = hp / maxHp;
            Vector2 size = hpBar.rectTransform.sizeDelta;
            size.x = perHp * 95;
            hpBar.rectTransform.sizeDelta = size;
            
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
        }
    }
}
