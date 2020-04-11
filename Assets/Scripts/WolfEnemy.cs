using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WolfEnemy : MonoBehaviour
{
    Transform player;
    // PlayerHealth playerHealth;      // Reference to the player's health.
    // EnemyHealth enemyHealth;        // Reference to this enemy's health.
    NavMeshAgent nav;
    Animator anim;
    public float maxLookRadius = 10;
    public float attackrange = 3;
    private float timerForNextAttack;
    private float cooldown;
    private int randomNumber;
    bool attacking = false;

    public Collider colliderAttack;


    void Awake()
    {
        // Set up the references.
        player = GameObject.FindGameObjectWithTag("Player").transform;
       
        //playerHealth = player.GetComponent<PlayerHealth>();
        //enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        timerForNextAttack = cooldown;
        nav.stoppingDistance = attackrange;
        cooldown = 2;
        colliderAttack = GetComponent<Collider>();

    }
    void Update()
    {

        enemyMoves();


    }

    public void WolfAttacks()
    {

            if (randomNumber == 1)
            {
                anim.SetTrigger("Bite Attack");
            }
            if (randomNumber == 2)
            {
                anim.SetTrigger("Breath Attack");
            }

            if (randomNumber == 3)
            {
                anim.SetTrigger("Pound Attack");
            }
  
    }

    bool Blue = false;
    bool Red = false;
    public void enemyMoves()
    {
        if (Vector3.Distance(player.position, this.transform.position) <= maxLookRadius)
        {
            Blue = true;

            if ((Vector3.Distance(player.position, this.transform.position) <= attackrange))
            {
                Red = true;
               // FindObjectOfType<AudioManager>().Play("Wolf");
            }
            else
            {
                Red = false;
            }
            
        }
        else
        {
            Blue = false;
        }


        if (Blue == true && Red == false)
        {
            Vector3 direction = player.position - this.transform.position;
            direction.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
            Quaternion.LookRotation(direction), 0.1f);
            colliderAttack.enabled = false;
            anim.SetBool("Run Forward", true);


            nav.destination = player.position;
        }
        else
        {
            anim.SetBool("Run Forward", false);


        }
        if (Red ==true && Blue == true)
        {
            colliderAttack.enabled = true;
            anim.SetBool("Run Forward", false);
            if (timerForNextAttack > 0)
            {
                timerForNextAttack -= Time.deltaTime;

            }
            else if (timerForNextAttack <= 0)
            {
                
                WolfAttacks();
                randomNumber = Random.Range(1, 3);
                timerForNextAttack = cooldown;
            }
        }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, maxLookRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackrange);
    }
}


