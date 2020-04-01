using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    // public Transform firehot;
    public Camera fps;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            shoot();
        }
        ////  Debug.DrawRay(transform.position, Vector3.forward * 5, Color.red);

        //  RaycastHit hit;
        //  int layer_mask = LayerMask.GetMask("Default");

        //  if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, Mathf.Infinity, layer_mask))
        //  {
        //      Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * hit.distance, Color.yellow);
        //      Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.yellow);
        //      Debug.Log("Did Hit");
        //  }
        //  else
        //  {
        //      Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
        //      Debug.Log("Did not Hit");
    }
    void shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fps.transform.position, fps.transform.forward, out hit))
          { 
            Debug.Log(hit.transform.name);
        }
    }
}




        //Ray ray = new Ray(transform.position, Vector3.left);
       
        //if(Physics.Raycast(ray,out hit, Mathf.Infinity, layer_mask, QueryTriggerInteraction.Ignore))
        //{
        //    print(hit.transform.name + "hited");
        //    print("distance is " + hit.distance);
        //    firehot.transform.position = hit.point;
        //}


    

   

