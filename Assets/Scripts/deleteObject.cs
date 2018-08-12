using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteObject : MonoBehaviour {


	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    void destroyItself()
    {
        //print("EVENT");
        Destroy(gameObject);
    }

}
