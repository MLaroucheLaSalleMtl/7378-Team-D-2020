using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class active : MonoBehaviour
{
    public GameObject myobject;
    public bool activename;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(activename == true)
        {
            myobject.SetActive(true);
        }
        else
        {
            myobject.SetActive(false);
        }
        
    }
}
