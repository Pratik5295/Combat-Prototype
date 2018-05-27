using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stat : MonoBehaviour {
    private Image content;
    public float lerpSpeed;
    public float lerpSpeed1;
    private float currentFill;
    private float maxFill = 2.0f;
    private float currentValue;

    public float MyMaxValue { get; set; }

    public float MyCurrentValue
    {
        get
        {
            return currentValue;
        }
        set
        {
            if(value > MyMaxValue)
            {
                currentValue = MyMaxValue;
            }
            else if (value < 0)
            {
                currentValue = 0;
            }
            else
            {
                currentValue = value;
            }

            currentFill = currentValue / MyMaxValue;
        }
    }

	// Use this for initialization
	void Start () {
        MyMaxValue = 100;
        content = GetComponent<Image>();
        
	}
	
	// Update is called once per frame
	void Update () {
        if (currentFill != content.fillAmount)
        {
            content.fillAmount = Mathf.Lerp(content.fillAmount, currentFill, Time.deltaTime * lerpSpeed);
        }
        //content.fillAmount = currentFill;
	}
    public void Initialize(float currentValue, float maxValue)
    {
        MyMaxValue = maxValue;
        MyCurrentValue = currentValue;
       
    }
    public void manaRegeneration()
    { 
        content.fillAmount = Mathf.Lerp(content.fillAmount,maxFill , Time.deltaTime * lerpSpeed1);
    }
}
