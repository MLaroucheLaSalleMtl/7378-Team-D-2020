﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float endam = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "enemy")
        {
           // GetComponent<enemycontrolNew>().Endamage();
            other.transform.SendMessage("Endamage", endam);
            
        }
    }
}