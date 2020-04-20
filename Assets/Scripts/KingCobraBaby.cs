using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingCobraBaby : MonoBehaviour
{
    public Transform player;
    static Animator anim;
    public Rigidbody Cobra;
    public float force = -10f;
    public float damage = 0.3f;
    public float enHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Cobra = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {

    }
    // Update is called once per frame
    void Update()
    {
        Cobra.AddForce(Vector3.up * force);

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
                FindObjectOfType<AudioManager>().Play("Snake");
            }
            else
            {
                anim.SetBool("IsAttack", true);
                anim.SetBool("IsWalking", false);
                player.GetComponent<PlayerStats>().TakeDamage(damage);
                
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
