using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startGame : MonoBehaviour {

	
	void Start () {
        GameManager.instance.playerOne = GameObject.FindGameObjectWithTag("player1");
        GameManager.instance.playerTwo = GameObject.FindGameObjectWithTag("player2");
        GameManager.instance.inGame = true;
    }
	
	void Update () {
		
	}
}
