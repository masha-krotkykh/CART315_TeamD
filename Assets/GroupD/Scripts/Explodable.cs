// CREDITS //
// Tutorial from which I learned this code: https://www.youtube.com/watch?v=EgNV0PWVaS8
// Assets by Doug Allen downloaded from here: http://devassets.com/assets/western-props-pack/


// CODE SUMMARY: This is a test code to work with explosion script
// There are two versions of each model (one broken, one unbroken). 
// The unbroken one is replaced by the broken one at the moment of the explosion

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explodable : MonoBehaviour
{
    // Variable to refer to the destroyed version of the object
    public GameObject destroyedVersion;


    public void Destroy()
    {
        // Spawn the broken version if it exists with "instantiate", give it the same position and rotation as the original.
        if (destroyedVersion != null) {
            Instantiate(destroyedVersion, transform.position, transform.rotation);
        }


        // Destroy the unbroken version, lowercase gameObject refers to the current object.
        Destroy(gameObject);

    }
}


// FURTHER INSTRUCTIONS:
// the public variable GameObject --> destroyedVersion will appear in the inspector
// drag the broken version into the destroyedVersion field.