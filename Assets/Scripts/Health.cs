using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    // Use this for initialization

    public int health;

	void Start () {
		

       
	}
	
	// Update is called once per frame
	void Update () {

        if (health <= 0)
        {
            Death();
        }
       
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            //reduce health
            Debug.Log(this.gameObject.name + " is hit by bullet.");
            health -= 10;

        }
    }

    void Death()
    {
        Destroy(this.gameObject);
    }

    public int getHealth()
    {
        return health;
    }
}
