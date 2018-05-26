using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWeapon : MonoBehaviour {

    // Use this for initialization
    public GameObject Weapon_Prefab;
    private GameObject Player;
    private GameObject gunpoint;
    

	void Start () {

        Player = GameObject.FindGameObjectWithTag("Player");
        gunpoint = GameObject.FindGameObjectWithTag("GunPoint");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Death();
        }
    }

    void Death()
    {
        Destroy(this.gameObject);

        //after destroying attach it to the player

        (Instantiate(Weapon_Prefab, gunpoint.transform.position, Quaternion.identity) as GameObject).transform.parent = Player.transform;
    }
}
