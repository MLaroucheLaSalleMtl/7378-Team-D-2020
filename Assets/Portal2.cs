using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal2 : MonoBehaviour
{
    public Transform point;
    public GameObject Heart1;
    public GameObject Heart2;

    private IEnumerator WaitForSceneLoad()
    {
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(4);

    }
    private void Update()
    {
        Heart1.SetActive(true);
    }
    void OnTriggerEnter(Collider other)
    {
        //Destroy(gameObject);
        Instantiate(point, transform.position, transform.rotation);
        // Do your things, then:
        StartCoroutine(WaitForSceneLoad());
        Heart2.SetActive(true);


        // And done
    }
}
