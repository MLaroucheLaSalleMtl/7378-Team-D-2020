using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pullit : MonoBehaviour
{
     Transform Player;
    public Transform playcam;
    public float throwff = 10;
        bool hasplay = false;
    bool beingcar = false;
    public int deg;
    private bool touched = false;
    // Start is called before the first frame update
    void Start()
    {
        Player = PlayerManager.instance.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(gameObject.transform.position, Player.position);
            if(dist <= 2.5f)
        {
            hasplay = true;

        }
            else
        {
            hasplay = false;
        }
        if (hasplay && Input.GetButtonDown("use"))
        {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.parent = playcam;
            beingcar = true;
        }
        if(beingcar)
        {
            if(touched)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingcar = false;
                // GetComponent<Rigidbody>().AddForce(playcam.forward * throwff);
                touched = false;
            }
            if(Input.GetMouseButtonDown(0))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingcar = false;
                 GetComponent<Rigidbody>().AddForce(playcam.forward * throwff);
                
            }
            else if(Input.GetMouseButtonDown(1))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingcar = false;
            }
        }
        
    }
    private void OnTriggerEnter()
    {
        if(beingcar)
        {
            touched = true;
        }
    }
}
