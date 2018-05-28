using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour {
    [SerializeField] RawImage manaBar;
    [SerializeField] float maxManaPoints = 100f;
    [SerializeField] float pointsperUse = 10f;
    [SerializeField] float currentManaPoints;
    [SerializeField] float manaPointsPerSecond = 0.5f;

	// Use this for initialization
	void Start () {

        currentManaPoints = maxManaPoints;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.M))
        {
            float newManaPoints = currentManaPoints - pointsperUse;
            currentManaPoints = Mathf.Clamp(newManaPoints, 0, maxManaPoints);
            updateManaBar();
        }
        if (currentManaPoints < maxManaPoints)
        {
            refillManaBar();
            updateManaBar();
        }
    }
    public void refillManaBar()
    {
        var manatoAdd = manaPointsPerSecond * Time.deltaTime;
        currentManaPoints = Mathf.Clamp(currentManaPoints + manatoAdd, 0, maxManaPoints);
    }
    public void updateManaBar()
    {
        //float xValue = - (manaasPercentage() / 2f) - 0.5f;
        //manaBar.uvRect = new Rect(xValue, 0f, 0.5f, 1f);
        manaBar.rectTransform.localScale = new Vector3(manaasPercentage(), 2, 1);

    }
    public float manaasPercentage()
    {
      
       return currentManaPoints / maxManaPoints;
             
    }
}
