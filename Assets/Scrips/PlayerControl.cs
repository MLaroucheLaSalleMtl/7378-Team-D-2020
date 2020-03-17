using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//Ask Fabian if any Question

public class PlayerControl : MonoBehaviour
{
    

    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    private float gravity = 0f;
    private Vector3 moveDirection = Vector3.zero;
    public int playerlive = 4;
    public GameObject health;
  

    //capsule for croch
    CharacterController capsule;
    Vector3 capsuleCenter;
    float capsuleHeight;
    Vector3 capsuleStateCenter;
    float capsuleStateHeight;

    //InputSystem
    private bool slowWalk = false;
    private bool jump = false;
    private bool crouch = false;
    private float v = 0;
    private float h = 0;

    //animations
    Animator anim;
    public void OnWalk(InputAction.CallbackContext context)
    {
        Vector2 value = context.ReadValue<Vector2>();
        h = value.x;
        v = value.y;
        //Debug.Log(value.x);

         AnimationController(value.x, value.y);

    }
    public void OnJump(InputAction.CallbackContext context)
    {
        jump = context.performed;
    }
    public void OnCrouch(InputAction.CallbackContext context)
    {
        crouch = context.performed;

    }
    public void OnSlowWalk(InputAction.CallbackContext context)
    {

        slowWalk = context.performed;

    }

    void Start()
    {
        //crouch
        capsule = GetComponent<CharacterController>();
        capsuleCenter = capsule.center;
        //capsuleStateCenter = capsule.center / 2f;
        capsuleHeight = capsule.height;
       // capsuleStateHeight = capsule.height / 2f;
        //animations
        anim = GetComponentInChildren<Animator>();
        
    }

    void Update()
    {
        Movement();
                
    }

    public void Movement()
    {
        CharacterController controller = GetComponent<CharacterController>();
              
        moveDirection = new Vector3(h * speed, gravity, v * speed);
  

       // Debug.Log(moveDirection);
    
        
        if (controller.isGrounded)
        {
            if (slowWalk == true)
            {
                moveDirection = moveDirection / 2;
            }

            moveDirection = transform.TransformDirection(moveDirection);
           // lookat = transform.LookAt(lookat);
            //moveDirection *= speed;

            if (jump)
            {
                gravity = jumpSpeed;

            }
          //  Crouching();
        }

        gravity += Physics.gravity.y * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    public void Crouching()
    {
          
        if (crouch)
        {
            capsule.height = capsuleStateHeight;
            capsule.center = capsuleStateCenter;
        }
        else
        {
            capsule.height = capsuleHeight;
            capsule.center = capsuleCenter;
            crouch = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //if(other.transform.tag == "Death")
        //{
        //   //Death();
        //   playerlive = playerlive - 1;
            
        //}
        if(other.transform.tag == "Death")
        {
            playerlive--;
            health.GetComponent<Text>().text = "Lives : " + playerlive;
            if (playerlive == 0)
            {
               
                Death();
            }
        }
       

    }
    public void Death()
    {
        // Debug.Log("Death");
         Object.Destroy(GameObject.FindWithTag("Player"));
         
    }

    public void AnimationController(float x,float y)
    {
        Debug.Log(x);
        anim.SetFloat("X",x);
        anim.SetFloat("Y",y);
    }
}
