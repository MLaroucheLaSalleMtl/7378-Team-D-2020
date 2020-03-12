using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int maxHealth = 100;
    public int currHealth;

    public Health healthbar;
   
    void Start()
    {
        currHealth = maxHealth;
        healthbar.Setmaxhealth(maxHealth);
    }

    void Update()
    {
        healthbar.GetComponent<Health>();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }
    void TakeDamage(int damage)
    {
        currHealth -= damage;
        healthbar.SetHealth(currHealth);
    }
}
