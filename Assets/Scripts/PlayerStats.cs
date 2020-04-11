using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private GameObject player;

    public static bool death = false;
    public static bool retry = false;
    //health
    [Header("Health")]
    public static float maxHealth = 100;
    public static float currHealth;
    public static float playerStartLives = 3;
    public static float playerlives = 3;

    [Header ("Stamina")]
    public static float currStamina;
    public static int maxStamina = 60;
    bool low = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerlives = playerStartLives;
        currHealth = maxHealth;
        currStamina = maxStamina;
        FindObjectOfType<AudioManager>().Play("Music");
    }
    private void resetStats()
    {
        if (retry == true)
        {
            death = false;
            currHealth = maxHealth;
            currStamina = maxStamina;
            playerlives = playerStartLives;
            retry = false;
        }
    }

    void Update()
    {
        resetStats();
        regenStamina();
       //// if (Input.GetKeyDown(KeyCode.D))
       // {
       //     TakeDamage(50);
       //     UseStamina(15);
       // }
    }
   public void TakeDamage(float damage)
    {
       if (playerlives != 0)
        {
            if (currHealth >= 0)
            {
                currHealth -= damage;
                if (currHealth == 0)
                {
                    currHealth = maxHealth;
                    playerlives--;

                    //respawnplayer
                }
            }
        }
        else
        {
            currHealth = 0;
            death = true;
            player.GetComponent<PlayerControl>().Death();
        }
    }
    public void UseStamina(int use)
    {
        
        if (currStamina > 0)
        {
            currStamina -= use;
            if (currStamina < maxStamina)
            {
                low = true;
            }
            else
            {
                low = false;
            }
        }

    }
    public void regenStamina()
    {
    
            if (low == true)
            {
            if (currStamina < 0)
            {
                currStamina = 0;
            }
               // Debug.Log(currStamina);
                currStamina += 5 * Time.deltaTime;
            }
    
       
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.tag == "Death")
        {
            TakeDamage(20);

        }
    }
}
