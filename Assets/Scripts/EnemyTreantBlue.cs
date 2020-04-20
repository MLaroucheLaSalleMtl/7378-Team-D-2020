using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTreantBlue : MonoBehaviour
{
    public Transform player;
    static Animator anim;
    public Rigidbody treant;
    public float force = -50f;
    public float damage = 0.3f;
    public float enHealth = 100;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        treant = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        treant.AddForce(Vector3.up * force);
        if (Vector3.Distance(player.position, this.transform.position) < 10)
        {
            Vector3 direction = player.position - this.transform.position;
            direction.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                Quaternion.LookRotation(direction), 0.1f);
            anim.SetBool("IsIdle", false);
            if (direction.magnitude > 1)
            {
                // anim.SetBool("IsWalking", true);
                this.transform.Translate(0, 0, 0.05f);
                anim.SetBool("IsWalking", true);
                anim.SetBool("IsAttack", true);
                FindObjectOfType<AudioManager>().Play("Treant");
            }
            else
            {
                anim.SetBool("IsAttack", true);
                anim.SetBool("IsWalking", false);
               
            }

        }
        else
        {
            anim.SetBool("IsIdle", true);
            anim.SetBool("IsWalking", false);
            anim.SetBool("IsAttack", false);
        }
        if (enHealth <= 0)
        {
            anim.SetBool("IsDie", true);
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

}

