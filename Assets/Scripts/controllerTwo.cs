using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controllerTwo : MonoBehaviour
{  
    float horizontal;
    float vertical;
    public bool fired = false;
    public const int player = -1;
    public Transform shotPower;     //ukazatel sily strelby - je nabindovany v IDE
    public Slider powerFill;
    public float power = 300;
    private bool rising = true;
    private float powerPerSec = 150;


    // Use this for initialization
    void Start()
    {
        gameObject.GetComponentInChildren<canon_move>().player = -1;
    }

    // Update is called once per frame
    void Update()
    {
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
      
        gameObject.GetComponent<tank_move>().Movement(horizontal);
        gameObject.GetComponentInChildren<canon_move>().vertical = vertical;

        //strelba
        if (Input.GetKey(KeyCode.RightControl) && !fired)   //cim dyl drzi tim vetsi silu da strele
        {
            if(rising)
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

        if (Input.GetKeyUp(KeyCode.RightControl) && !fired)
        {
            fired = true;
            gameObject.GetComponentInChildren<fire>().Fire(player, power);
            power = 300;  //zpet na 300 coz je vychozi
        }
        SetShotSlider();
    }

    void SetShotSlider()
    {
        powerFill.value = power;
    }
}