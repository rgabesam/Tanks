using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class endOfGame : MonoBehaviour {

    public GameObject playerOne;
    public GameObject playerTwo;
    public GameObject explosionOfTank;
    public Text winText;


    void Start()
    {
        playerOne = GameObject.Find("playerOne");
        playerTwo = GameObject.Find("playerTwo");

    }

    public void EndOfGame(string name)
    {

        if (name == "playerOne")
        {
            Instantiate(explosionOfTank, playerOne.transform.position, playerOne.transform.rotation);
            winText.text = "PLAYER 2 WINS";
        }
        else if (name == "playerTwo")
        {
            Instantiate(explosionOfTank, playerTwo.transform.position, playerTwo.transform.rotation);
            winText.text = "PLAYER 1 WINS";
        }
        GameManager.instance.inGame = false;
    }
}
