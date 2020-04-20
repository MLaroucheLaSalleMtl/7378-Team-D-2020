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

    public Rigidbody wolf;
    public float force = -50f;
    public float damage = 0.3f;
    public float enHealth = 100;

    public Collider colliderAttack;


    void Awake()
    {
        // Set up the references.
        player = GameObject.FindGameObjectWithTag("Player").transform;
        wolf = GetComponent<Rigidbody>();
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
        FindObjectOfType<AudioManager>().Play("Wolf");

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

    public void enemyMoves()
    {
        wolf.AddForce(Vector3.up * force);
        if (Vector3.Distance(player.position, this.transform.position) < maxLookRadius)
        {
            Vector3 direction = player.position - this.transform.position;
            direction.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                Quaternion.LookRotation(direction), 0.1f);
            anim.SetBool("Resting", false);
            if (direction.magnitude > 1)
            {
                this.transform.Translate(0, 0, 0.05f);
                anim.SetBool("Walk Forward", true);
            }
            else
            {
                WolfAttacks();
                anim.SetBool("Walk Forward", false);
                FindObjectOfType<AudioManager>().Play("Enemy");
            }

        }
        else
        {
            anim.SetBool("Resting", true);
            anim.SetBool("Walk Forward", false);
            WolfAttacks();
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
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackrange);
    }
}


