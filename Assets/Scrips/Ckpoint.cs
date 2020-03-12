using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ckpoint : MonoBehaviour
{
    public Transform chkpoint;
    //public void OnTriggerEnter(Collider other)//if the player touch this circle he will enter the
    //    // next Scene which is level 2
    //{
    //    if(other.tag == "Player")
    //    {
    //        SceneManager.LoadScene(2);
    //    }
    //}
    private IEnumerator WaitForSceneLoad()
    {
        yield return new WaitForSeconds(1);
        
        SceneManager.LoadScene(2);

    }
    void OnTriggerEnter(Collider other)
    {
       //Destroy(gameObject);
        Instantiate(chkpoint, transform.position, transform.rotation);
        // Do your things, then:
        StartCoroutine(WaitForSceneLoad());
       
        // And done
    }
}
