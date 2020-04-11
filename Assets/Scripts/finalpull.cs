using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalpull : MonoBehaviour
{
    public float speed = 20f;
    public float radius = 2f;
    public float add = 0.2f;

    public Transform target; // player


    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnDrawGizmosSelected() //for visible radius 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }



    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position); // checking the player position


        if (Input.GetKey(KeyCode.F))
        {
            if (distance <= radius) // if it is under the radius
            {
                float step = speed * Time.deltaTime; // calculate distance to move
                transform.position = Vector3.MoveTowards(transform.position, target.position, step); // going with the player
                transform.position = new Vector3(transform.position.x + add, transform.position.y, transform.position.z); //to stop just outside of the player 
                //target.position *= -1.0f;
            }

        }

    }
   
}