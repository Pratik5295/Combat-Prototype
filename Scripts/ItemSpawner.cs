using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {

    // Use this for initialization
    public GameObject spawnpoint1;  //value 1
    public GameObject spawnpoint2;  //value 2
    public GameObject spawnpoint3;  //value 3

    //weapon prefabs
    public GameObject weapon1;

    //temporary object 
    public GameObject tester;


    //for the random value generated
    private int choice;

    private float counter;
    private float test;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        counter += Time.deltaTime;

        if (counter >= 5)
        {

            //after the point is selected, spawn the weapon
            if (tester != null)
            {
                Destroy(tester);
            }
            GenerateWeapon();
            counter = 0;
        }
	}

    //select a random value from 1 to 3 for the tile to spawn the weapon/item


  

    void GenerateWeapon()
    {
       choice = (int)Random.Range(1f, 9f);
      
     

       if(1<=choice && choice <=3)
        {
           tester = Instantiate(weapon1, spawnpoint1.transform.position, Quaternion.identity);
        }
        if (3<choice && choice <=6)
        {
           tester =  Instantiate(weapon1, spawnpoint2.transform.position, Quaternion.identity);
        }
        if (6<choice && choice <= 9)
        {
           tester = Instantiate(weapon1, spawnpoint3.transform.position, Quaternion.identity);
        }
    }

}
