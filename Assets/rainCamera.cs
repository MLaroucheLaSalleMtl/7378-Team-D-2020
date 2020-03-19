using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ask Fabian Condori if Any Question
public class rainCamera : MonoBehaviour
{
    public Transform follow;
    // Start is called before the first frame update
    void Start()
    {
        follow = GameObject.FindGameObjectWithTag("CameraFollow").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (follow == isActiveAndEnabled)
        {
            Vector3 temp = transform.position;

            temp.x = follow.position.x;
            temp.y = follow.position.y;


            transform.position = temp;
        }
        else
        {
            // Debug.Log("DeathScreen");
        }
    }
}
