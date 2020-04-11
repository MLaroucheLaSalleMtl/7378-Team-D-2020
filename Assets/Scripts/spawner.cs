using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform spawnpoint;
     void OnTriggerEnter(Collider other)
    {
        player.transform.position =spawnpoint.transform.position;
        Debug.Log("working");
    }
}
