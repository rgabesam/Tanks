using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canon_move : MonoBehaviour {

    public float vertical;
    private float tiltAngle = 60.0f;
    private float smooth = 8f;
    private float tiltAroundZ = 0;
    public int player;


    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update () {

        if(player == 1)
        {
            if (tiltAroundZ == 60)
                tiltAroundZ--;
            if (tiltAroundZ == -20)
                tiltAroundZ++;
            if ((vertical == 1 || vertical == -1) && (tiltAroundZ < 60 && tiltAroundZ > -20))
            {
                tiltAroundZ = tiltAroundZ + (vertical);
                Quaternion canon = Quaternion.Euler(0, 0, tiltAroundZ);
                transform.rotation = Quaternion.Slerp(transform.rotation, canon, Time.deltaTime * smooth);

            }
        }
        else if(player == -1)
        {
            if (tiltAroundZ == -60)
                tiltAroundZ++;
            if (tiltAroundZ == 20)
                tiltAroundZ--;
            if ((vertical == 1 || vertical == -1) && (tiltAroundZ > -60 && tiltAroundZ < 20))
            {
                tiltAroundZ = tiltAroundZ + (vertical * -1);
                Quaternion canon = Quaternion.Euler(0, 0, tiltAroundZ);
                transform.rotation = Quaternion.Slerp(transform.rotation, canon, Time.deltaTime * smooth);

            }
        }

        
        
    }
   
}
