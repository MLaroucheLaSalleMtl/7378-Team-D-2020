using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class scoringtext : MonoBehaviour
{
    public GameObject textii;
    public static int thescore;
    
   

     void Update()
    {
       
        textii.GetComponent<Text>().text = "Score :" + thescore;
    }
}
