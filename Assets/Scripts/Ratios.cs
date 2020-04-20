using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ratios : MonoBehaviour
{

    Resolution[] resolutions;
    public Dropdown diffRatio;
    void Start()
    {
       resolutions = Screen.resolutions;
        diffRatio.ClearOptions();          //clear all the options in the ratio dropdown
        List<string> options = new List<string>();      //list of strings which is going to be our options  

        int currRatioIndex = 0;
        for (int i = 0; i < resolutions.Length; i++) //then we loop through each element of diff ratios
        {
            string option = resolutions[i].width + "x" + resolutions[i].height; //display the ratio
            options.Add(option); //added to the options

            if(resolutions[i].width == Screen.currentResolution.width && 
                resolutions[i].height == Screen.currentResolution.height)
            {
                currRatioIndex = i;
            }
            
        }
        diffRatio.AddOptions(options); //add the list to the diffratio drop down
        diffRatio.value = currRatioIndex;
        diffRatio.RefreshShownValue();
    }

   public void setRatio(int ratioIndex)
   {
        Resolution resolution = resolutions[ratioIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
   }

    public void setQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void setFullScreen(bool isFull)
    {
        Screen.fullScreen = isFull;
    }
   
}
