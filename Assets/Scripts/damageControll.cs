using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageControll : MonoBehaviour {

    public int damage;
    public GameObject explosion;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "bullet")
        {
            Quaternion rot = other.gameObject.transform.rotation;
            Vector3 pos = other.gameObject.transform.position;
            //print("KOLIZE");
            damage = other.gameObject.GetComponent<behaviourBullet>().damage;     //zjisti jakou damage dava tahle konkretni munice
            gameObject.GetComponent<playerStats>().ChangeHealth(damage);          //ubere zivoty, podle typu munice

            Destroy(other.gameObject);          //znici naboj
            Instantiate(explosion, pos, rot);     //vytvori explozi
            GameManager.instance.player = GameManager.instance.player * -1;    //prehodi hrace
            gameObject.GetComponentInChildren<fire>().fired = false;     //nastavi v tu chvili, ze az bude zase na tahu muze vystrelit
            

        }
    }
}
