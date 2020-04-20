using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    private float v = 0;
    private float h = 0;
    private float d = 0;

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
        //d = value.x * value.y;
        //Debug.Log(d);

        if (h != 0 || v!=0)
        {
            anim.SetBool("Moving", true);
        }
        else
        {
            anim.SetBool("Moving", false);
        }

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
        if (projectile)
        {
            anim.SetTrigger("Attacking");
        }
        else
        {
            anim.ResetTrigger("Attacking");
        }
            
        
    }

    void Start()
    {
        capsule = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        //crouch      
        capsuleCenter = capsule.center;
        capsuleStateCenter = capsule.center / 2f;
        capsuleHeight = capsule.height;
        capsuleStateHeight = capsule.height / 2f;                
        
    }

    void Update()
    {
        //Debug.Log(capsuleHeight);
        anim = GetComponentInChildren<Animator>();
        
        Movement();

        Crouching();
        WalkSlowly();

    }

    public void Movement()
    {
        CharacterController controller = GetComponent<CharacterController>();
              
        moveDirection = new Vector3(h * speed, gravity, v * speed);

        // Debug.Log(moveDirection);


        if (controller.isGrounded)
        {
            WalkSlowly();


            moveDirection = transform.TransformDirection(moveDirection);
            // lookat = transform.LookAt(lookat);
            //moveDirection *= speed;

            if (jump)
            {
                gravity = jumpSpeed;
               
            }
           

        }

        gravity += Physics.gravity.y * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    public void WalkSlowly()
    {
        if (slowWalk)
        {
            moveDirection = moveDirection / 2;
            slowWalk = true;
        }
        else
        {
            slowWalk = false;
        }
    }
    public void Crouching()
    {

        if (crouch)
        {
            anim.SetBool("Crouch", true);
            capsule.center = new Vector3(0, -0.40f, 0);
            capsule.height = 0.6f;
            slowWalk = true;
        }
        else
        {
            anim.SetBool("Crouch", false);
            capsule.center = new Vector3(0, 0, 0);
            capsule.height = 1.5f;
            slowWalk = false;
        }
    }


    public void Death()
    {
        
         Object.Destroy(GameObject.FindWithTag("Player"));


    }

    public void AnimationController(float x,float y)
    {
        //Debug.Log(a);
        //Debug.Log(y);

        //movement

        anim.SetFloat("X", x);
        anim.SetFloat("Y", y);
    }


  
}
