﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    // Use this for initialization
    public float speedX = 2.0f;
    public float speedY = 2.0f;


    //add prefab for the bullet
    public GameObject BulletPrefab;
    private GameObject barrel;
    private Transform BulletSpawnPoint;


    void Start () {

        GetComponent<Rigidbody>().freezeRotation = true;
	}
	
	// Update is called once per frame
	void LateUpdate () {

        float translationX = Input.GetAxis("Horizontal") * speedX;
        float translationY = Input.GetAxis("Vertical") * speedY;

        translationX = translationX * Time.deltaTime;
        translationY = translationY * Time.deltaTime;

        transform.Translate(translationX, 0, 0);
        transform.Translate(0, 0, translationY);

  
       

        if (Input.GetKeyDown(KeyCode.Space))
        {

            BulletSpawnPoint = this.gameObject.transform.GetChild(0).GetChild(0).gameObject.transform;
            
            Fire(BulletSpawnPoint);
        }

        
	}

    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.tag == "Tile")
        {
              
            int tilenumber;
            string tiletype;
            tilenumber = collision.gameObject.GetComponent<TileType>().number;
            tiletype = collision.gameObject.GetComponent<TileType>().type;
           // Debug.Log("Tile Number: "+tilenumber+ " TileType: "+tiletype);
        }
    }


    

    //Fire Bullet Code
    public void Fire(Transform BulletSpawnPoint)
    {

        var bullet = (GameObject)Instantiate(BulletPrefab, BulletSpawnPoint.transform.position , BulletSpawnPoint.transform.rotation);

        bullet.GetComponent<Rigidbody>().velocity = new Vector3(5, 0, 0);
    }    
}
