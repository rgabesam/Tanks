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
       
	}

    public void Fire(int player, float power)
    {
        fired = true;
        GameObject g;
        g = Instantiate(bullet, canon.transform.position, canon.transform.rotation);
        g.GetComponent<behaviourBullet>().player = player;
        g.GetComponent<behaviourBullet>().forceLength = power;

    }
}
