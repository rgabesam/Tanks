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
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        GameManager.instance.inGame = false;
    }
}
