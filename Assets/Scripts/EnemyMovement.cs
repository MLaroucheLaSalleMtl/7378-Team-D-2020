using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    Transform player;               
   // PlayerHealth playerHealth;      // Reference to the player's health.
   // EnemyHealth enemyHealth;        // Reference to this enemy's health.
    NavMeshAgent nav;               
    Animator anim;
    public float maxLookRadius=10;
    public float medLookRadius=6;
    public float attackrange=3;
    private float timerForNextAttack;
    private float cooldown;
    private int randomNumber;
    bool attacking = false;
    public float damage = 0.3f;
    public float enHealth = 100;


    public Collider Rightarm;
    public Collider Leftarm;
    public GameObject objecta;
    public Animation objectb;

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

        Rightarm = GetComponent<Collider>();
        Leftarm = GetComponent<Collider>();

       // objectb = GetComponent<Animation>();
      //  objecta = GetComponent<GameObject>();

    }
    void Update()
    {

        enemyMoves();
        if (timerForNextAttack > 0)
        {
            timerForNextAttack -= Time.deltaTime;
            
        }
        else if (timerForNextAttack <= 0)
        {
            randomNumber = Random.Range(1, 4);
            GolemAttacks();
            timerForNextAttack = cooldown;
        }
        
    }

    public void GolemAttacks()
    {
        
        if (Vector3.Distance(player.position, this.transform.position) <= attackrange)
        {
            attacking = true;
    
            if(randomNumber == 1)
            {
                anim.SetTrigger("Punch Attack");
            }
            if (randomNumber == 2)
            {
                anim.SetTrigger("Double Punch Attack");              
            }
        
            if (randomNumber == 3)
            {
                anim.SetTrigger("Hit Ground Attack");

                objecta.SetActive(true);
                objectb.Play();               
            }     
            if (randomNumber == 4)
            {
                anim.SetTrigger("Cast Spell Attack");
            }

        }
        else
        {
            attacking = false;
        }
    }

    public void enemyMoves()
    {        

        if (Vector3.Distance(player.position, this.transform.position) <= maxLookRadius && (Vector3.Distance(player.position, this.transform.position) > attackrange))
        {
            Vector3 direction = player.position - this.transform.position;
            direction.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
            Quaternion.LookRotation(direction), 0.1f);

            //move based on navmesh bake
            nav.destination = player.position;


            if(Vector3.Distance(player.position, this.transform.position) > medLookRadius)
            {
                if (attacking == false)
                {
                    anim.SetBool("Run Forward", true);
                    nav.speed = 4;
                }
            }
           
            if (Vector3.Distance(player.position, this.transform.position) < medLookRadius)
            {
                if (attacking == false)
                {
                    anim.SetBool("Run Forward", false);
                    anim.SetBool("Walk Forward", true);
                    nav.speed = 2;
                }
            }
        }
        else
        {
            anim.SetBool("Walk Forward", false);
            anim.SetBool("Run Forward", false);
        }
        if (enHealth <= 0)
        {
            anim.SetBool("Die", true);
            StartCoroutine(destroy());

        }
    }
    public void Endamage(float endam)
    {

        enHealth -= endam;
    }
    IEnumerator destroy()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, maxLookRadius);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, medLookRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackrange);
    }

}
