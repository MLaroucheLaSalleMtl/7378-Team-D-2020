using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSwitch : MonoBehaviour
{
    public GameObject SnowFlake;
    public GameObject fire;
   

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            SnowFlake.SetActive(true);
            fire.SetActive(false);
           
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SnowFlake.SetActive(false);
            fire.SetActive(true);
          
        }
       
    }
}
