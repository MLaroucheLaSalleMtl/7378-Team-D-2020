using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invantory : MonoBehaviour
{
    
    public GameObject slot;
    public GameObject Button;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
           
            Destroy(gameObject);
            
            Button.SetActive(true);
            slot.SetActive(true);

        }
        else
        {
            slot.SetActive(false);
            Button.SetActive(false);
        }
    }

}
