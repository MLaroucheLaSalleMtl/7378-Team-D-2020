using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ask FC 
public class PlayerStats : MonoBehaviour
{
    private GameObject player;

    public static bool death = false;
    public static bool retry = false;
    //health
    [Header("Health")]
    public static int maxHealth = 100;
    public static int currHealth;
    public static int playerStartLives = 3;
    public static int playerlives = 3;

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
        if (Input.GetKeyDown(KeyCode.D))
        {
            TakeDamage(50);
            UseStamina(15);
        }
    }
    public void TakeDamage(int damage)
    {
       if (playerlives != 0)
        {
            if (currHealth > 0)
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
}
