using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    private GameObject player;


    [SerializeField]public int damage = 10;
    // Start is called before the first frame update
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

       if (other.tag == "Player")        
           //Debug.Log("hit");
           player.GetComponent<PlayerStats>().TakeDamage(damage);
        
    }
}
