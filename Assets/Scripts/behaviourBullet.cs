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
    public Slider slider;

    // Use this for initialization
    void Start () {
        slider = GameObject.Find("navigationPanel").GetComponentInChildren<Slider>();

        float forceLength = slider.value;
        float forceX;
        float forceY;
        Vector3 axis = Vector3.zero;
        float angle = 0.0f;
        if (GameManager.instance.player == 1)
        {
            tank = GameObject.Find("tankGreen");
        }
        else if (GameManager.instance.player == -1)
        {
            tank = GameObject.Find("tankRed");
        }
        tank.transform.GetChild(0).GetComponent<Transform>().rotation.ToAngleAxis(out angle, out axis);
        //print(canon.GetComponent<Transform>().rotation.z);
        forceY = GameManager.instance.player * forceLength * Mathf.Sin(angle * Mathf.PI / 180) * Mathf.Sign(tank.transform.GetChild(0).GetComponent<Transform>().rotation.z);
        forceX = Mathf.Sqrt(forceLength * forceLength - forceY * forceY) * GameManager.instance.player;
        //print(angle);
        //print(forceY);
        //print(forceX);
        time = 0;
        //bool fired = true;
        constForce = gameObject.GetComponent<ConstantForce2D>();
        constForce.force = new Vector2(forceX, forceY);
	}
    
    // Update is called once per frame
    void Update() {

        
       
	}
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        ContactPoint2D contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;
        Destroy(gameObject);
        Instantiate(explosion, pos, rot);
        if (GameManager.instance.player == 1)
        {
            GameObject.Find("tankGreen").GetComponentInChildren<fire>().fired = false;
        }
        else if (GameManager.instance.player == -1)
        {
            GameObject.Find("tankRed").GetComponentInChildren<fire>().fired = false;
        }
        GameManager.instance.player = GameManager.instance.player * -1;

    }

    private void FixedUpdate()
    {
        constForce.force = new Vector2(0, 0);

    }
}
