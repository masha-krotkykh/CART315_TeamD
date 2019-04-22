using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MolotovLauncher : MonoBehaviour
{

    public float throwForce = 20f;
    public GameObject molotovPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("m")) 
        {
            ThrowMolotov();
        }
    }

    void ThrowMolotov() 
    {
        GameObject molotov = Instantiate(molotovPrefab, transform.position, transform.rotation);
        Rigidbody bottle = molotov.GetComponent<Rigidbody>();

            bottle.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);

    }
}
