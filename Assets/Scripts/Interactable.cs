using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {
    [System.Serializable]
    public class Action
    {
        public Color color;
        public Sprite sprite;
        public string title;

    }

    public Action[] options;
	// Use this for initialization

    void OnMouseDown()
    {
        // tell canvas to spawn a menu
        RadialMenuSpawner.ins.SpawnMenu(this);
    }

    void Update()
    {
        //Input.GetButton("Tab")
        //
        

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            RadialMenuSpawner.ins.SpawnMenu(this);
            Debug.Log("Tab was pressed");
        }
        //else if(Input.GetKeyUp(KeyCode.Tab))
        //{
        //    Destroy(RadialMenuSpawner.ins);
        //    Debug.Log("Tab was released");
        //}
    }
}
