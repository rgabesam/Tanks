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
        //InitGame();
        //playerOne = GameObject.Find("tankGreen");
        //playerTwo = GameObject.Find("tankRed");


    }
	
	// Update is called once per frame
	void Update () {
        if (inGame)
        {
            if (playerOne != null || playerTwo != null)
            {
                float horizontal;//= Input.GetAxis("Horizontal");
                float vertical;// = Input.GetAxis("Vertical");
                //print(horizontal);
                //print(vertical);
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    horizontal = -1;
                }
                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    horizontal = 1;
                }
                else
                {
                    horizontal = 0;
                }

                if (Input.GetKey(KeyCode.UpArrow))
                {
                    vertical = 1;
                }
                else if (Input.GetKey(KeyCode.DownArrow))
                {
                    vertical = -1;
                }
                else
                {
                    vertical = 0;
                }

                if (player == 1)
                {
                    playerOne.GetComponent<tank_move>().Movement(horizontal); 
                    playerOne.GetComponentInChildren<canon_move>().vertical = vertical;
                    if (Input.GetKeyDown("space"))
                    {
                        playerOne.GetComponentInChildren<fire>().Fire();
                    }
                }
                else if (player == -1)
                {
                    playerTwo.GetComponent<tank_move>().Movement(horizontal);
                    playerTwo.GetComponentInChildren<canon_move>().vertical = vertical;
                    if (Input.GetKeyDown("space"))
                    {
                        playerTwo.GetComponentInChildren<fire>().Fire();
                    }
                }
                
            }
            else
            {
                playerOne = GameObject.FindGameObjectWithTag("player1");
                playerTwo = GameObject.FindGameObjectWithTag("player2");
            }
            
        }

        
    }

    

    void InitGame()
    {
        //boardScript.SetupScene(level);
    }
}
