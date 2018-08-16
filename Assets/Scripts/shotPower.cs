using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shotPower : MonoBehaviour {

    public Slider slider;
    public Image sliderImage;
    public int power;

    // Use this for initialization
    void Start () {
        //sliderImage = slider.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnValueChanged()
    {
        //slider.GetComponentInChildren<Image>().color = Color.Lerp(Color.red, Color.green, slider.value / 20);
    }
}
