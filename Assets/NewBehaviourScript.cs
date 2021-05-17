using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float cubeSize;
    float x = 0.2f;
    float y = 1.2f;
    float z = 0;
    public int n;
    public int slices;
    public Material tex;
    GameObject gameObj;

    // Start is called before the first frame update
    void Start()
    {
        createCubeArray(n);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   void createCubeArray(int num)
    {
        for(int i=0; i<num; i++)        //x
        {  
            for(int j = 0; j<30; j++)  //y
            {
                for(int k = 0; k<slices; k++)  //z   slices
                {
                   
                    
                    gameObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    gameObj.transform.position = new Vector3(x,y,z);
                    gameObj.transform.localScale = new Vector3(cubeSize,cubeSize,cubeSize);
                    //Destroy(gameObj.GetComponent<BoxCollider>());
                    gameObj.GetComponent<Renderer>().material = tex;
                    gameObj.AddComponent<CubeDestroy>();

                    z += cubeSize;
                }
                z = 0;
                y += cubeSize;
            }
            y = 1.2f;
            x += cubeSize;
        }

        
    }

  

}
