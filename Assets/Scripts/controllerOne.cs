using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controllerOne : MonoBehaviour {

    float horizontal;
    float vertical;
    public bool fired = false;
    public const int player = 1;
    public Transform shotPower;     //ukazatel sily strelby - je nabindovany v IDE
    public Slider powerFill;
    public float power;
    private bool rising;
    private float powerPerSec = 150;


    // Use this for initialization
    void Start ()
    {
        gameObject.GetComponentInChildren<canon_move>().player = 1;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.A))
        {
            horizontal = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontal = 1;
        }
        else
        {
            horizontal = 0;
        }

        if (Input.GetKey(KeyCode.W))
        {
            vertical = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            vertical = -1;
        }
        else
        {
            vertical = 0;
        }

        gameObject.GetComponent<tank_move>().Movement(horizontal);
        gameObject.GetComponentInChildren<canon_move>().vertical = vertical;

        //strelba
        if (Input.GetKey(KeyCode.Space) && !fired)
        {
            if (rising)
            {
                power = power + (powerPerSec * Time.deltaTime);
                if (power >= 600)
                {
                    rising = false;
                    power = 600;
                }
            }
            else if (!rising)
            {
                power = power - (powerPerSec * Time.deltaTime);
                if (power <= 300)
                {
                    rising = true;
                    power = 300;
                }
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) && !fired)
        {
            fired = true;
            gameObject.GetComponentInChildren<fire>().Fire(player, power);
            power = 300;
        }
        SetShotSlider();
    }

    void SetShotSlider()
    {
        powerFill.value = power;
    }
}
