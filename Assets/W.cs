using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W : MonoBehaviour
{
    
    void Update()
    {
        FindObjectOfType<AudioManager>().Play("Winner");
    }
}
