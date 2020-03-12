using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectible : MonoBehaviour
{
    //public AudioSource collectscound;
    public Transform collected;
   
    void OnTriggerEnter(Collider other)
    {
    //   collectscound.Play();
       scoringtext.thescore += 50;
        Instantiate(collected, transform.position, transform.rotation);
        Debug.Log("destroy");
        Destroy(gameObject); 
    }
}
