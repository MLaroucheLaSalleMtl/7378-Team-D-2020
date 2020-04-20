using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class winerscore : MonoBehaviour
{
    public Text winhigh;
    // Start is called before the first frame update
    void Start()
    {
       winhigh.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
