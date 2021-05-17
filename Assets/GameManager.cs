using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    RaycastHit hit;
    bool status = false;   //to check blade is down to up,   false-up, true-down 
    bool s = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 90))
                if (hit.transform.gameObject.name == "electricSaw")             //for Saw
                {
                   
                    GameObject Pname = hit.transform.gameObject;
            
                    var hinge = Pname.GetComponentInChildren<HingeJoint>();
                    if(status == false)  //if up, make it down
                    {
                        hinge.useMotor = false; //
                        var motor = hinge.motor;
                        motor.force = 1000;
                        motor.targetVelocity = 100;
                        motor.freeSpin = false;
                        hinge.motor = motor;
                        hinge.useMotor = true;

                        status = true;
                    }
                    else
                    {
                        hinge.useMotor = false; 
                        var motor = hinge.motor;
                        motor.force = 1000;
                        motor.targetVelocity = -100;
                        motor.freeSpin = false;
                        hinge.motor = motor;
                        hinge.useMotor = true;

                        status = false;
                    }
                   
                    
                }

                if(hit.transform.gameObject.name == "Drill")
                {
              
                GameObject gameobj = hit.transform.gameObject;
                Vector3 posa = gameobj.transform.position;
                Vector3 posb = new Vector3(posa.x - 0.33f, posa.y, posa.z);
                Vector3 posc = new Vector3(posa.x + 0.33f, posa.y, posa.z);

                if (s == false)
                {
                    gameobj.transform.position = posb;

                    s = true;
                }
                else
                {
                    gameobj.transform.position = posc;

                    s = false;
                }
               
                 
                }

        }
    }

   public void CloseButton()
    {
        Application.Quit();
    }

}
