using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour {

    public void PlayGame()
    {
        SceneManager.LoadScene("tanks");
    }

    public void QuitGame()
    {
        Application.Quit();
        print("QUIT");
    }
}
