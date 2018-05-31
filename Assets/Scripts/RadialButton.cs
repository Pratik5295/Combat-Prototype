using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class RadialButton : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler {
    public Image Circle;
    public Image Icon;
    public string title;
    public RadialMenu myMenu;
    Color defaultColor;
    public void OnPointerEnter(PointerEventData eventData)
    {
        myMenu.selectedButton = this;
        defaultColor = Circle.color;
        Circle.color = Color.white;

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        myMenu.selectedButton = null;
        Circle.color = defaultColor;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
