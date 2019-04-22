using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MolotovLauncher : MonoBehaviour
{

    public float throwForce = 20f;
    public GameObject molotovPrefab;

    public RigidBodyController bodyScript;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("m")) 
        {
            if(bodyScript.molotovs > 0)
            {
                ThrowMolotov();
                bodyScript.molotovs -= 1;
            }
            else
            {
                Debug.Log("No Molotovs to launch");
            }
        }
    }

    void ThrowMolotov() 
    {
        GameObject molotov = Instantiate(molotovPrefab, transform.position, transform.rotation);
        Rigidbody bottle = molotov.GetComponent<Rigidbody>();

            bottle.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);

    }
}
