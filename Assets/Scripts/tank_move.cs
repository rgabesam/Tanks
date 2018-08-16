using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tank_move : MonoBehaviour {

    private Rigidbody2D myRigidbody;
    public Text winText;

	// Use this for initialization
	void Start ()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update () {
        if (gameObject.GetComponent<Transform>().position.y < -5)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<endOfGame>().EndOfGame(gameObject.name);
            Destroy(gameObject);
            
            
        }
        //float horizontal = Input.GetAxis("Horizontal");
        // Movement(horizontal);
		
	}

    public void Movement(float horizontal)
    {
        myRigidbody.velocity = new Vector2(horizontal, myRigidbody.velocity.y);
        //myRigidbody.canon.Transform = (myRigidbody.canon.Transform.x, myRigidbody.canon.Transform.y, myRigidbody.canon.Transform.z +vertical);

    }
    
}
