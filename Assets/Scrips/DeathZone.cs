using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public PlayerControl player;


    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
              player.GetComponent<PlayerControl>().Death();
            player.Death();
           // Destroy(gameObject);
        }

    }
}
