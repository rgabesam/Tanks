using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerStats : MonoBehaviour {

    public Transform healthBar;
    public Slider healthFill;

    public int currentHealth;
    public int maxHealth;



	void Start () {
		
	}
	
	void Update () {
		
	}

    public void ChangeHealth (int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        healthFill.value = currentHealth;
    }
}
