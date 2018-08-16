using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour {

    public GameObject gameManager;

	// Use this for initialization
	void Awake () {
        if (GameManager.instance == null)
            Instantiate(gameManager);
        //GameManager.instance.playerOne = GameObject.Find("tankGreen");
        //GameManager.instance.playerTwo = GameObject.Find("tankRed");

    }
	
	public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        GameManager.instance.inGame = false;
    }
}
