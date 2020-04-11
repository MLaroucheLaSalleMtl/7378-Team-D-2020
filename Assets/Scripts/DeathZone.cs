using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("Death");
            player.GetComponent<PlayerControl>().Death();
              PlayerStats.death = true;
           
        }
        if (other.gameObject.tag == "enemy")
        {
            Destroy(other);
        }

    }
}
