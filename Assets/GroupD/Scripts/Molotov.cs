// To use the Molotov Cocktail, define the objects that will be affected by giving them Rigidbody component
// Adjust explosion delay, blast radius, and explosion force to your liking

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Molotov : MonoBehaviour
{
    public float delay = 2f; // Timer before the explosion
    public float blastRadius = 5f; // Area of damage
    public float force = 700; // Explosion force

    public GameObject explosionEffect;

    float countdown;
    bool hasExploded = false;

    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
    }

    //// Update is called once per frame
    //void Update()
    //{
    //    countdown -= Time.deltaTime;
    //    if (countdown <= 0f && hasExploded == false) 
    //    {
    //        Explode();
    //        hasExploded = true;
    //    }

    //}

    public void OnCollisionEnter(Collision other)
    {
        if (hasExploded == false) 
        {
           Explode();
           hasExploded = true;
        }
    }


        void Explode() {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        //hasExploded = true;
        Collider[] collidersToDestroy = Physics.OverlapSphere(transform.position, blastRadius);

        foreach (Collider nearbyObject in collidersToDestroy)
        {
            Explodable exp = nearbyObject.GetComponent<Explodable>();
            if (exp != null) 
            {
                exp.Destroy();
            }
  
        }

        Collider[] collidersToMove = Physics.OverlapSphere(transform.position, blastRadius);

        foreach (Collider nearbyObject in collidersToMove)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, blastRadius);
            }
        }

        Destroy(gameObject);
        Debug.Log(hasExploded);

    }
}
