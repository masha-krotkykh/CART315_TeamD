﻿// Combustion on mouse click -- change event if needed
// Fire effect used from Cosyio at www.youtube.com/watch?v=JTGv_maOyHk

// INSTRUCTIONS:
// - Drop script onto combustible object 
// - Drop "Combustion" prefab in "Particles" section of the script

// This script inherits behaviour from Break script and all Break functions and variables (except private) are visible to it 


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combust : MonoBehaviour
{

    public float temperature;
    public ParticleSystem particles; // Reference to particle system

    // Variable to refer to the destroyed version of the object
    public GameObject destroyedVersion;

    // burn function describes basic behaviour of a burning object
    public void burn()
    {
        // Where the flame particle system will be displayed
        Vector3 combustionPos = transform.position;

        GameObject particle = Instantiate(particles.gameObject);
        particle.transform.position = transform.position;

        Destroy(particle, 6);

        Invoke("Destroy", 5);

        //temperature += 10;

        //When the temperature gets above 5, the object receives tag "Burning"
        if(temperature > 5) 
        {
            gameObject.tag = "Burning";
        }
       
 
    }

    //// Combustible object gets on fire on collision with a burning object
    //public void OnCollisionEnter(Collision other)
    //{
    //    if(other.gameObject.CompareTag("Burning")) 
    //    {

    //        this.temperature += 10;
    //        burn();
    //    }
    //}

    // Combustible object gets on fire staying in contact with a burning object
    //public void OnTriggerStay(Collider other)
    //{
    //        if (Vector3.Distance(other.transform.position, this.transform.position) < 50 && (other.gameObject.layer!= LayerMask.NameToLayer("Water")))
    //        {
    //            burn();
    //        }

    //}

    public void Destroy()
    {
        // Spawn the broken version with "instantiate", give it the same position and rotation as the original.
        GameObject debris = Instantiate(destroyedVersion.gameObject, transform.position, transform.rotation);

        // Destroy the unbroken version, lowercase gameObject refers to the current object.
        Destroy(gameObject);

        Destroy(debris, 6);

    }

    // FOR TESTING PURPOSES
    //Sets a combustible object on fire when its temperature gets abpve 5
    // temperature increases by 1 on each mouse click
    private void OnMouseDown()
    {
        print("clicked");
        temperature += 1;
        if (temperature > 5)
        {
            burn();
        }
    }

}
