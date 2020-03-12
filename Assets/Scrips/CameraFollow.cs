﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform cameraFollow;
    // Start is called before the first frame update
    void Start()
    {
        cameraFollow = GameObject.FindGameObjectWithTag("CameraFollow").transform;  
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (cameraFollow == isActiveAndEnabled)
        {
            Vector3 temp = transform.position;

            temp.x = cameraFollow.position.x;
            temp.y = cameraFollow.position.y;


            transform.position = temp;
        }
        else
        {
           // Debug.Log("DeathScreen");
        }
    }
}
