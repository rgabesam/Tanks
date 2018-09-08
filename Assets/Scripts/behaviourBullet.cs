using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class behaviourBullet : MonoBehaviour {

    private float time;
    public ConstantForce2D constForce;
    public GameObject explosion;
    private GameObject tank;
    public int damage;
    public int player;
    public float forceLength;

    // Use this for initialization
    void Start () {
        float forceX;
        float forceY;
        Vector3 axis = Vector3.zero;
        float angle = 0.0f;
        if (player == 1)
        {
            tank = GameObject.Find("tankGreen");
        }
        else if (player == -1)
        {
            tank = GameObject.Find("tankRed");
        }
        tank.transform.GetChild(0).GetComponent<Transform>().rotation.ToAngleAxis(out angle, out axis);
        forceY = player * forceLength * Mathf.Sin(angle * Mathf.PI / 180) * Mathf.Sign(tank.transform.GetChild(0).GetComponent<Transform>().rotation.z);
        forceX = Mathf.Sqrt(forceLength * forceLength - forceY * forceY) * player;
        time = 0;
        constForce = gameObject.GetComponent<ConstantForce2D>();
        constForce.force = new Vector2(forceX, forceY);
	}
    
    // Update is called once per frame
    void Update() {
        if (gameObject.GetComponent<Transform>().position.y < -5)     //kontroluju jestli tank nespadl na nektere z map do propasti
        {
            allowFire();
            Destroy(gameObject);
        }
            

    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        ContactPoint2D contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;
        allowFire();
        Destroy(gameObject);
        Instantiate(explosion, pos, rot);
        
    }

    public void allowFire() //odblokuje strelbu danemu hraci
    {
        if(player == 1)
        {
            GameObject.Find("playerOne").GetComponent<controllerOne>().fired = false;
        }
        else
        {
            GameObject.Find("playerTwo").GetComponent<controllerTwo>().fired = false;
        }
    }

    private void FixedUpdate()
    {
        constForce.force = new Vector2(0, 0);

    }
}
