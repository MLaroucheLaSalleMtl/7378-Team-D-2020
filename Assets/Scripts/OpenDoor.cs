using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OpenDoor : MonoBehaviour
{
    public Animation anim;
    public GameObject slot;
    public GameObject panel;
    private bool interct;

    public void OnInteract(InputAction.CallbackContext context)
    {
        interct = context.performed;

    }

    private void OnTriggerStay ()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            anim.Play();
            slot.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            panel.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            panel.SetActive(false);
        }
    }
    //Animator anim;
    //public GameObject image;

    //void Start()
    //{
    //    anim = GetComponent<Animator>();
    //}

    //public void Play()
    //{
    //            Debug.Log("open");
    //            anim.Play("OpenDoor");
    //            image.SetActive(false);

    //}


}
