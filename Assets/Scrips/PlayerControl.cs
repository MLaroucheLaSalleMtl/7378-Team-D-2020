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
    private bool projectile = false;
    public float v = 0;
    public float h = 0;

    //animations
    Animator anim;

    public void flip()
    {
        transform.Rotate(0f, 180f, 0f);
    }
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
    public void OnProjectile(InputAction.CallbackContext context)
    {
        projectile = context.performed;
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
               // anim.SetBool("Jump", true);

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


    public void Death()
    {
        
         Object.Destroy(GameObject.FindWithTag("Player"));
         
    }

    public void AnimationController(float x,float y)
    {
        //Debug.Log(x);
        //Debug.Log(y);
        anim.SetFloat("X",x);
        anim.SetFloat("Y",y);
        if (projectile)
        {
            anim.SetBool("Projectile", true);
        }
        else
        {
            anim.SetBool("Projectile", false);
        }
        
    }
  
}
