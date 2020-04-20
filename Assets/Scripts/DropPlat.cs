using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPlat : MonoBehaviour
{
    public GameObject player;
    private Rigidbody rigid;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rigid = GetComponent<Rigidbody>();
        rigid.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(drop());
        }
    }
    
    IEnumerator drop()
    {
        yield return new WaitForSeconds(1);
        rigid.isKinematic = false;
    }
}
