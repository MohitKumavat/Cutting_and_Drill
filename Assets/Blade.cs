using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Wood")
        {
            Cut(collision.transform, transform.position);
        }

    }

    public static bool Cut(Transform wood, Vector3 _pos)
    {
        Vector3 pos = new Vector3(_pos.x, wood.position.y, wood.position.z);   //  x is position of blade
        //Debug.Log(pos);
        Vector3 victimScale = wood.localScale;        //take localScale of Wood

        float distance = Vector3.Distance(wood.position, pos);        //wood position - pos

        if (distance >= victimScale.x / 2) return false;

        Vector3 leftPoint = wood.position - Vector3.right * victimScale.x / 2;
        //Debug.Log(leftPoint);
        Vector3 rightPoint = wood.position + Vector3.right * victimScale.x / 2;
        //Debug.Log(rightPoint);
        Material mat = wood.GetComponent<MeshRenderer>().material;    //store wood material
        Destroy(wood.gameObject);  //destroy wood original

        GameObject rightSideObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        rightSideObj.transform.position = (rightPoint + pos) / 2;
        float rightWidth = Vector3.Distance(pos, rightPoint);
        rightSideObj.transform.localScale = new Vector3(rightWidth, victimScale.y, victimScale.z);
        rightSideObj.AddComponent<Rigidbody>().mass = 100f;
        rightSideObj.GetComponent<MeshRenderer>().material = mat;

        GameObject leftSideObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        leftSideObj.transform.position = (leftPoint + pos) / 2;
        float leftWidth = Vector3.Distance(pos, leftPoint);
        leftSideObj.transform.localScale = new Vector3(leftWidth, victimScale.y, victimScale.z);
        leftSideObj.AddComponent<Rigidbody>().mass = 100f;
        leftSideObj.GetComponent<MeshRenderer>().material = mat;

        return true;
    }
}
