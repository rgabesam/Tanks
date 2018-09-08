using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageControll : MonoBehaviour {

    public int damage;
    public GameObject explosion;
    public GameObject player;    //je prirazeno rucne v Unity IDE



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "bullet")
        {
            Quaternion rot = other.gameObject.transform.rotation;
            Vector3 pos = other.gameObject.transform.position;
            //print("KOLIZE");
            damage = other.gameObject.GetComponent<behaviourBullet>().damage;     //zjisti jakou damage dava tahle konkretni munice
            player.GetComponent<playerStats>().ChangeHealth(damage);          //ubere zivoty, podle typu munice
            other.gameObject.GetComponent<behaviourBullet>().allowFire();
            Destroy(other.gameObject);          //znici naboj
            Instantiate(explosion, pos, rot);     //vytvori explozi
            
        }
    }
}
