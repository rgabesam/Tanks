﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllerTwo : MonoBehaviour
{  
    float horizontal;
    float vertical;
    public bool fired = false;
    public const int player = -1;
    
    
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
        if (Input.GetKeyDown(KeyCode.RightControl) && !fired)
        {
            fired = true;
            gameObject.GetComponentInChildren<fire>().Fire(player);
        }

    }
}