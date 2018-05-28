using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField]
    private Stat Mana;
    // Use this for initialization
    public float speedX = 2.0f;
    public float speedY = 2.0f;
    private float timer;

    //add prefab for the bullet
    public GameObject BulletPrefab;
    private GameObject barrel;
    private Transform BulletSpawnPoint;


    void Start () {
        Mana.Initialize(100f, 100f);
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

        

        //FOR DEBUGGING ONLY
        if(Input.GetKeyDown(KeyCode.M))
        {
            Mana.MyCurrentValue -= 10;
            timer = 3f;
        }
        timer -= Time.deltaTime;
        Debug.Log("Current value" + Mana.MyCurrentValue);
        Debug.Log("Max Value: " + Mana.MyMaxValue);
        if(timer <=0f)
        {
            //do
            //{
            //    Mana.manaRegeneration();
            //} while (Mana.MyCurrentValue != Mana.MyMaxValue);
            Mana.manaRegeneration();

        }
        //do
        //{
        //    InvokeRepeating("manaRegeneration", 5.0f, 0.5f);
        //} while (Mana.MyCurrentValue != Mana.MyMaxValue);
        //InvokeRepeating("manaRegeneration", 5.0f, 0.1f);
        //if (Input.GetKeyDown(KeyCode.N))
        //{
        //    Mana.MyCurrentValue += 10;
        //}

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


    public void manaRegeneration()
    {
        Mana.manaRegeneration();
    }

    //Fire Bullet Code
    public void Fire(Transform BulletSpawnPoint)
    {

        var bullet = (GameObject)Instantiate(BulletPrefab, BulletSpawnPoint.transform.position , BulletSpawnPoint.transform.rotation);

        bullet.GetComponent<Rigidbody>().velocity = new Vector3(5, 0, 0);
    }    
    

}
