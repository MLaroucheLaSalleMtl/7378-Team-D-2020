using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunishZone : MonoBehaviour
{
    [SerializeField] public Transform player;
    public  Transform punishpoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            player.transform.position = punishpoint.transform.position;
            FindObjectOfType<AudioManager>().Play("Respawn");
            Debug.Log("Punished");
        }
    }
}
