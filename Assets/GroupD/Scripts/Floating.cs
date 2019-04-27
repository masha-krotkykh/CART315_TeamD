using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour
{
    public GameObject water;

    public int force;


    void Update()
    {
        if (transform.position.y > water.transform.position.y)
        {
            GetComponent<Rigidbody>().AddForce(-transform.forward * force * 10);
        }

        if (transform.position.y < water.transform.position.y)
        {
            GetComponent<Rigidbody>().AddForce(transform.forward * force * 5);
        }
    }

}
