using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour {


    public GameObject bullet;
    public GameObject canon;
    public bool fired;
    //public Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        fired = false;
	}
	
	// Update is called once per frame
	void Update () {
        /*
        if (Input.GetKeyDown("space"))
		{
            if (!fired)
            {
                //print("fired");
               
                //rb = g.GetComponent<Rigidbody2D>();
                //rb.velocity = new Vector3(10f,0f,0f);
            }
            
            
		}
        */
	}

    public void Fire()
    {
        if (!fired)
        {
            fired = true;
            GameObject g;
            g = Instantiate(bullet, canon.transform.position, canon.transform.rotation);
        }
        
    }
}
