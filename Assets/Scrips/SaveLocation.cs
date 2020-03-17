using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLocation : MonoBehaviour
{
    //position
    public float xPosition;
    public float yPosition;
    public float zPosition;

    //GETTING THE VALUES FOR CURRENT POSITION
    public void Awake()
    {
        xPosition = PlayerPrefs.GetFloat("MyPositionX");//gets the saved position x from the player prefs and fill the variable
        yPosition = PlayerPrefs.GetFloat("MyPositionY");
        zPosition = PlayerPrefs.GetFloat("MyPositionZ");
    }
    //Setting the values for the current position
    void Start()
    {
        transform.position = new Vector3(xPosition, yPosition, zPosition);//set the position of the transform character
    }

    // Saving the values of the current position of the player
    void Update()
    {
        PlayerPrefs.SetFloat("MyPositionX", transform.position.x);
        PlayerPrefs.SetFloat("MyPositionY", transform.position.y);
        PlayerPrefs.SetFloat("MyPositionZ", transform.position.z);
    }
}
