using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    MolotovLauncher launcherScript;

    public int molotovs;


    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "ActivePlayer")
        {
            molotovs += 1;
            Destroy(gameObject);
            Debug.Log(molotovs);
        }
    }
}