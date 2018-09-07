using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public BoardManager boardScript;
    public int player;
    public GameObject playerOne;
    public GameObject playerTwo;
    //public int health1 = 100;
    //public int health2 = 100;
    public bool inGame = false;
    public GameObject explosionOfTank;
    public Text winText;



    private int level = 3;

	// Use this for initialization
	void Awake () {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        boardScript = GetComponent<BoardManager>();
        playerOne = GameObject.FindGameObjectWithTag("player1");
        playerTwo = GameObject.FindGameObjectWithTag("player2");
        InitGame();
        


    }

    

    // Update is called once per frame
    void Update () {
        
        
    }

    

    public void InitGame()
    {
        //playerOne = GameObject.FindGameObjectWithTag("player1");
        //playerTwo = GameObject.FindGameObjectWithTag("player2");
        //boardScript.SetupScene(level);
    }
}
