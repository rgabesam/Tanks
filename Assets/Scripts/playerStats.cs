using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerStats : MonoBehaviour {

    public Transform healthBar;
    public Slider healthFill;


    public int currentHealth;
    public int maxHealth;
    public Text winText;




    void Start () {
		
	}
	
	void Update () {
		if (currentHealth <= 0)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<endOfGame>().EndOfGame(gameObject.name);
            Destroy(gameObject);
            
        }
	}

    public void ChangeHealth (int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        healthFill.value = currentHealth;
    }
}
