using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invantory : MonoBehaviour
{
    public Component doorcollider;
    public GameObject slot;
    public GameObject key;
   

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            doorcollider.GetComponent<BoxCollider>().enabled = true;
            slot.SetActive(true);
            key.SetActive(false);
            
        }

    }
}

  




    



