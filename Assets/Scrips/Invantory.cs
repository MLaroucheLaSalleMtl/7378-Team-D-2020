using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invantory : MonoBehaviour
{
    
    public GameObject slot;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Got Treasure");
            Destroy(gameObject);
            slot.SetActive(true);

        }
        else
        {
            slot.SetActive(false);
        }
    }

}
