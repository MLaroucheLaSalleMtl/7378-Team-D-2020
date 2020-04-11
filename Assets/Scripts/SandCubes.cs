using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandCubes : MonoBehaviour
{
    private GameObject player;
    //private BoxCollider boxcollider;
    private Rigidbody rigidSand;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //boxcollider = gameObject.GetComponent<BoxCollider>();
        rigidSand = gameObject.GetComponent<Rigidbody>();
        rigidSand.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
           // boxcollider.enabled = false;
            rigidSand.isKinematic = false;

        }
        if (other.gameObject.tag == "DeathByLava" )
        {
            Destroy(gameObject);
        }

    }
}
