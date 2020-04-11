using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faaling : MonoBehaviour
{
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("stuff");
        }
    }
}
