using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public BoardManager boardScript;
    public int player;
    public GameObject playerOne;
    public GameObject playerTwo;
    public int health1 = 100;
    public int health2 = 100;

    private int level = 3;

	// Use this for initialization
	void Awake () {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        boardScript = GetComponent<BoardManager>();
        InitGame();
        playerOne = GameObject.Find("tankGreen");
        playerTwo = GameObject.Find("tankRed");


    }
	
	// Update is called once per frame
	void Update () {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
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

    void InitGame()
    {
        //boardScript.SetupScene(level);
    }
}
