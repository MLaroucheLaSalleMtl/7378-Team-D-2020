using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectible : MonoBehaviour
{
    //public AudioSource collectscound;
    public Transform collected;
    public int score = 50;
    private GameObject UI;

    private void Start()
    {
        UI = GameObject.FindWithTag("UI");
    }
    void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<AudioManager>().Play("Collect");
        //   collectscound.Play();
        UI.GetComponent<InGameUI>().updateScore(score);
        Instantiate(collected, transform.position, transform.rotation);
        //Debug.Log("destroy");
      
        Destroy(gameObject); 
    }
}
