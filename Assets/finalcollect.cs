using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class finalcollect : MonoBehaviour
{
    public GameObject scoretext;
    public static int thescore;
    public  Text highscore;

    private void Start()
    {
        highscore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
    private void Update()
    {
        scoretext.GetComponent<Text>().text = "Score: " + thescore;
        highscore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        rollBaby();
       
    }
    public void rollBaby()
    {
        if (thescore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", thescore);
            highscore.text = thescore.ToString();
        }

    }
    
}
