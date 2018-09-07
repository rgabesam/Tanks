using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MapChooseScript : MonoBehaviour {

    public void PlayGame(string s)
    {
        SceneManager.LoadScene(s);
    }


}
