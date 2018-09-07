using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tank_move : MonoBehaviour {

    private Rigidbody2D myRigidbody;
    public Collider2D tankCollider;
    //public GameObject tank;
    public GameObject pivotTank;
    float normalX;
    float normalY;

	// Use this for initialization
	void Start ()
    {
        //myRigidbody = GetComponent<Rigidbody2D>();
        /*if(GameManager.instance.player == 1)
        {
            tank = GameObject.Find("playerOne");
            pivotTank = GameObject.Find("tankGreenPivot");
        }
        else
        {
            tank = GameObject.Find("playeTwo");
            pivotTank = GameObject.Find("tankRedPivot");
        }
        */
        myRigidbody = gameObject.GetComponent<Rigidbody2D>();
        tankCollider = gameObject.GetComponent<CircleCollider2D>();
       
        

    }

    // Update is called once per frame
    void Update () {
        if (gameObject.GetComponent<Transform>().position.y < -5) //kontroluju jestli tank nespadl na nektere z map do propasti
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<endOfGame>().EndOfGame(gameObject.name);
            Destroy(gameObject);
            
        }
        
    }

    public void Movement(float horizontal)
    {
        
        RaycastHit2D[] results = new RaycastHit2D[1];
        tankCollider.Raycast(Vector2.down, results);
        normalX = results[0].normal.x;
        normalY = results[0].normal.y;
        float angle = (Mathf.Atan( normalY / normalX) * 180 / Mathf.PI) ;
        if (angle < 0)
            angle = angle + 180; //tohle aby se tank naklanel podle terenu, ne podle normaly terenu
        
        pivotTank.transform.rotation = Quaternion.Euler(0, 0, angle -90);      //nastaveni uhlu obrazku tanku
        myRigidbody.velocity = new Vector2(horizontal * 1.5f, myRigidbody.velocity.y);   //pohyb vpred a vzad

    }
    
}
