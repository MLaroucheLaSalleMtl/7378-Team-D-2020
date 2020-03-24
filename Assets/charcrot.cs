using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charcrot : MonoBehaviour
{
    // Start is called before the first frame update
    public void flip()
    {
        transform.Rotate(0f, 180f, 0f);
    }
    public void Update()
    {
        flip();
    }
}
