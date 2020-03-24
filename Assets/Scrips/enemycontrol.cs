using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemycontrol : MonoBehaviour
{
    public Transform player;
    NavMeshAgent mynev;
    public float checkrate = 0.01f;
    float nextcheck;


     void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player").activeInHierarchy)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            mynev = gameObject.GetComponent<NavMeshAgent>();

        }
    }
     void Update()
    {
        if(Time.time > nextcheck)
        {
            nextcheck = Time.time * checkrate;
            followplayer();
        }
        
    }
    void followplayer()
    {
        mynev.transform.LookAt(player);
        mynev.destination = player.transform.position;
    }
}
