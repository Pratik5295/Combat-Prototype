using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {

    // Use this for initialization

    public GameObject Player;
    private int playerhealth;
    public Text playerhealthtext;
 

	void Start () {

      
	}
	
	// Update is called once per frame
	void Update () {


        //keep on updating the value of health
        playerhealth = Player.GetComponent<Health>().getHealth();
        Player_Health();
	}


    void Player_Health()
    {
        //Debug.Log(playerhealth);
        playerhealthtext.text = "Health: " + playerhealth ;
    }


}
