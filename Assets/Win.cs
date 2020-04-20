using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{

    public Transform chkpoint;
    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;
    public GameObject Winer;

    private void Update()
    {
        Heart1.SetActive(true);
        Heart2.SetActive(true);
    }
    private IEnumerator WaitForSceneLoad()
    {
        yield return new WaitForSeconds(1);

        Winer.SetActive(true);

    }
    void OnTriggerEnter(Collider other)
    {
        //Destroy(gameObject);
        Instantiate(chkpoint, transform.position, transform.rotation);
        // Do your things, then:
        StartCoroutine(WaitForSceneLoad());
        Heart3.SetActive(true);
      

        // And done
    }
}
