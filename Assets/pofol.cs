using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pofol : MonoBehaviour
{


    public GameObject otherobjectright;
    public GameObject otherobjectleft;
    public float x;
    public float y;
    public float z;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // firespot.transform.position = player.position + player.TransformDirection(new Vector3(1, 0, 0));
        otherobjectright.transform.position = transform.TransformPoint(x, y, z);

        //   otherobjectleft.transform.position = transform.TransformPoint(10, 0, 0);



    }

}


