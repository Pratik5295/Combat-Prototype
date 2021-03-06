﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialMenu : MonoBehaviour {
    public RadialButton buttonPrefab;
    public RadialButton selectedButton;

	// Use this for initialization
	public void SpawnButtons (Interactable obj) {
        for (int i = 0; i < obj.options.Length; i++)
        {
            RadialButton newButton = Instantiate(buttonPrefab) as RadialButton;
            newButton.transform.SetParent(transform, false);
            float theta = (2 * Mathf.PI / obj.options.Length) * i;
            float xPos = Mathf.Sin(theta);
            float yPos = Mathf.Cos(theta);
            newButton.transform.localPosition = new Vector3(xPos, yPos, 0f) * 100f;
            newButton.Circle.color = obj.options[i].color;
            newButton.Icon.sprite = obj.options[i].sprite;
            newButton.title = obj.options[i].title;
            newButton.myMenu = this;
           // newButton.transform.localPosition = new Vector3(0f, 100f, 0f);
        }
        
	}
	
	// Update is called once per frame
    void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (selectedButton)
            {
                Debug.Log(selectedButton.title + " was selected");
            }
        }
        //if (Input.GetMouseButtonUp(0))
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            
          Destroy(gameObject);
        }
    }
}
