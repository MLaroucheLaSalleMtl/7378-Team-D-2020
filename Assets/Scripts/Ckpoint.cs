using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ckpoint : MonoBehaviour
{
    public Transform chkpoint;
    public GameObject Heart1;
    
    private IEnumerator WaitForSceneLoad()
    {
        yield return new WaitForSeconds(1);
        
        SceneManager.LoadScene(3);

    }
    void OnTriggerEnter(Collider other)
    {
       //Destroy(gameObject);
        Instantiate(chkpoint, transform.position, transform.rotation);
        // Do your things, then:
        StartCoroutine(WaitForSceneLoad());
        Heart1.SetActive(true);
        
       
        // And done
    } 
}
