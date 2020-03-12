using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Transform spawnPoint;
    //private void Start()
    //{
    //    target = PlayerManager.instance.player.transform;
    //}
    private void Start()
    {
        target = GetComponent<Transform>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            Debug.Log("colliding");
            target.transform.position = new Vector3(434, 248, 895);
        }
    }

    ////
    //    {
    //        //if (other.gameObject.tag == "Player")
    //        //   target.transform.position = spawnPoint.transform.position;
    //        if (other.gameObject.tag == "Player")
    //        {
    //            Debug.Log("colliding");

    //            //target.transform.position = new Vector3(434, 248, 895);
    //        }
    //            //other.transform.position =  new Vector3(434, 248, 895);

    //    }
}
