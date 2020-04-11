using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLocation : MonoBehaviour
{
    //position
    //public float xPosition;
    //public float yPosition;
    //public float zPosition;
    public Transform player;
    //GETTING THE VALUES FOR CURRENT POSITION

    //Setting the values for the current position
    void Start()
    {
         load();
        //xPosition = PlayerPrefs.GetFloat.tag("Player");//gets the saved position x from the player prefs and fill the variable
        //yPosition = PlayerPrefs.GetFloat("MyPositionY");
        //zPosition = PlayerPrefs.GetFloat("MyPositionZ");
        //transform.position = new Vector3(xPosition, yPosition, zPosition);//set the position of the transform character
    }

    // Saving the values of the current position of the player
    void update()
    {
       save();
    }
    public void save()
    {
        

        PlayerPrefs.SetFloat("x",player.transform.position.x);
        PlayerPrefs.SetFloat("y",player.transform.position.y);
        PlayerPrefs.SetFloat("z",player.transform.position.z);
        Debug.Log("saved");
    }
   public void load()
    {
        // if (PlayerPrefs.GetFloat("x") != null)
        //{
      //  save();
        transform.position = new Vector3(PlayerPrefs.GetFloat("x"), PlayerPrefs.GetFloat("y"), PlayerPrefs.GetFloat("z"));
       
        Debug.Log("loded");
        //}
       // transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
        //save();
    }
    
}
