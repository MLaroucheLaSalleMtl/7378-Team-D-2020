using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class collectible : MonoBehaviour
{
    public Transform particles;
    public Text highscore;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(particles, transform.position, transform.rotation);
            FindObjectOfType<AudioManager>().Play("Collect");
            finalcollect.thescore += 50;
            Destroy(gameObject);
            if (finalcollect.thescore > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", finalcollect.thescore);
                highscore.text = finalcollect.thescore.ToString();
            }

        }

    }
    public void Reset()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayerPrefs.DeleteAll();
            highscore.text = "0";
        }
    }
    private void Update()
    {
        highscore.text = finalcollect.thescore.ToString();
        Reset();
    }
}


