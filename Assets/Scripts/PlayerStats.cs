using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerStats : MonoBehaviour
{
    private GameObject player;

    public static bool death = false;
    public static bool retry = false;
    //health
    [Header("Health")]
    public static float maxHealth = 300;
    public static float currHealth;
    public static float playerStartLives = 3;
    public static float playerlives = 3;

    //[Header ("Stamina")]
    //public static float currStamina;
    //public static int maxStamina = 60;
    //bool low = false;
    public GameObject scoretext;
    public static int thescore;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerlives = playerStartLives;
        currHealth = maxHealth;
       // currStamina = maxStamina;
        FindObjectOfType<AudioManager>().Play("Music");
    }
    private void resetStats()
    {
        if (retry == true)
        {
            death = false;
            currHealth = maxHealth;
            //currStamina = maxStamina;
            playerlives = playerStartLives;
            retry = false;
        }
    }

    void Update()
    {
        resetStats();
        scoretext.GetComponent<Text>().text = "HP:" + currHealth;
        //   regenStamina();
        //// if (Input.GetKeyDown(KeyCode.D))
        // {
        //     TakeDamage(50);
        //     UseStamina(15);
        // }
    }
   public void TakeDamage(float damage)
    {
      //  Debug.Log(currHealth);
        currHealth -= damage;
       if (playerlives > 0)
        {
            if (currHealth >= 200)
            {
                playerlives = 3;
            }
            if (currHealth >=100 && currHealth < 200)
            {
                playerlives = 2;
            }
            if (currHealth >= 1 && currHealth < 100)
            {
                playerlives = 1;
            }
        }
        if(currHealth < 0)
        {
            playerlives = 0;
            currHealth = 0;
            death = true;
            player.GetComponent<PlayerControl>().Death();
        }
    }
    public void HealingP(int heal)
    {
        currHealth += heal;
    }
    //public void UseStamina(int use)
    //{
        
    //    if (currStamina > 0)
    //    {
    //        currStamina -= use;
    //        if (currStamina < maxStamina)
    //        {
    //            low = true;
    //        }
    //        else
    //        {
    //            low = false;
    //        }
    //    }

    //}

        //I guess no one wanted to implement stamina
    //public void regenStamina()
    //{
    
    //        if (low == true)
    //        {
    //        if (currStamina < 0)
    //        {
    //            currStamina = 0;
    //        }
    //           // Debug.Log(currStamina);
    //            currStamina += 5 * Time.deltaTime;
    //        }
    
       
    //}

    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.tag == "Death")
        {
            TakeDamage(20);

        }
    }
}
