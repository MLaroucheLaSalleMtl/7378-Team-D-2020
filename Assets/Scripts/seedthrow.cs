using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seedthrow : MonoBehaviour
{
    private float Speed = 3.5f;
    public GameObject Target;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Target != null)
        {
            float step = Random.Range(1, 5) * Time.deltaTime;
            this.transform.position = Vector3.MoveTowards(this.transform.position,
                Target.transform.position + new Vector3(0, 0.5f, 0), step);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        PlayerStats playerComponent = other.GetComponent<PlayerStats>();
        //if (playerComponent != null)
        //{
        //    int newHealth = playerComponent - 1;
        //    if (newHealth == 0)
        //    {
        //        Time.timeScale = 0;
        //    }
        //    else
        //        playerComponent.Health = newHealth;
            GameObject.Destroy(this.gameObject);
        }
    }

