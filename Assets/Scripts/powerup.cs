using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup : MonoBehaviour
{
    public GameObject pickupeffect;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            pickup();
        }

    }
    void pickup()
    {
        // Debug.Log("picked up");
        Instantiate(pickupeffect, transform.position, transform.rotation);



        Destroy(gameObject);
    }
}
