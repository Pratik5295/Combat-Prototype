using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    // Use this for initialization
    
    private float accuracy = 1f;
    private int pointcounter = 0;
    private float difference;

   

    //bullet
    public GameObject BulletPrefab;
    private Transform BulletSpawnPoint;


    //AI movement
    public NavMeshAgent navi;
    public GameObject[] waypoints;

    //target
    public GameObject player;
    private Vector3 playerangle;

    //speed for difficulty
    public float counter;

    void Start () {

        counter = 0;
       // playerangle.Set(0, 180, 0);
       navi =  GetComponent<NavMeshAgent>();
        navi.updateRotation = false;
	}
	
	// Update is called once per frame
	void Update () {


        //after every 5 secs give out a debug log
        counter += Time.deltaTime;
        //this.transform.LookAt(playerangle);
        BulletSpawnPoint = this.gameObject.transform.GetChild(0).GetChild(0).gameObject.transform;
        
       

        if (counter >= 3)
        {
          

            //movement
            movement();

            //Fire
            Fire(BulletSpawnPoint);


            counter = 0;
        }
	}

    public void Fire(Transform BulletSpawnPoint)
    {
        var bullet = (GameObject)Instantiate(BulletPrefab, BulletSpawnPoint.transform.position, BulletSpawnPoint.transform.rotation);

        bullet.GetComponent<Rigidbody>().velocity = new Vector3(-5, 0, 0);
    }

    public void movement()
    {

        //take in all the waypoints

        difference =  Vector3.Distance(this.gameObject.transform.position, waypoints[pointcounter].transform.position);
      
        if (difference < accuracy)
        {
            pointcounter++;
            if(pointcounter == waypoints.Length)
            {
                pointcounter = 0;
            }
        }
        navi.SetDestination(waypoints[pointcounter].transform.position);
       
       
        
    }
}
