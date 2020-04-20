using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject enemy;
    public Transform enemypos;
    private float repeatrate = 12.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            InvokeRepeating("enemyspawner", 0.5f, repeatrate);
            Destroy(gameObject, 11);
            gameObject.GetComponent<BoxCollider>().enabled = false;

        }
    }
    void enemyspawner()
    {
        Instantiate(enemy, enemypos.position, enemypos.rotation);
    }
}
