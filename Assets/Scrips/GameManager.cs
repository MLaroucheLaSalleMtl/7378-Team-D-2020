using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button BtnPlay;
    public Button BtnOptions;
    public Button BtnQuit;
    public Button BtnCredits;

    private bool btnpopup = false;

    [SerializeField] public GameObject OptionsMenu;
    [SerializeField] public GameObject SoundSettings;
    [SerializeField] public GameObject VideoSettings;
    [SerializeField] public GameObject ControlSettings;
    [SerializeField] public GameObject menuRoot;
    [SerializeField] public GameObject PopUpExit;

    //loading Screen
    public GameObject LoadingScreen;
    public Slider sliderBar;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        BtnPlay.GetComponent<Button>();
        BtnOptions.GetComponent<Button>();
        BtnQuit.GetComponent<Button>();
        BtnCredits.GetComponent<Button>();
        
    }

    public void LoadLevels(int sceneIndex)
    {       
        StartCoroutine (LoadAsyncronously(sceneIndex));
    }
    IEnumerator LoadAsyncronously(int sceneIndex)
    {  
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        LoadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            sliderBar.value = progress;
            Debug.Log(progress);
            text.text = "Loading " + "(" + progress * 100f + "%)"; 
            yield return null;
        }
    }

    public void BtnSettings()
    {
        OptionsMenu.SetActive(true);
        menuRoot.SetActive(false);
    }
    public void BtnExit()
    {
        btnpopup = true;
        SetBtnActive();
        PopUpExit.SetActive(true);
    }
    public void BtnExitYes()
    {
        Application.Quit();
    }
    public void BtnExitNo()
    {
        btnpopup = false;
        SetBtnActive();
        PopUpExit.SetActive(false);
    }
    public void Credits()
    {
        Debug.Log("credits");
    }

    public void BtnSettingsBack()
    {
        OptionsMenu.SetActive(false);
        menuRoot.SetActive(true);
    }
    public void BtnSettingSound()
    {
        SoundSettings.SetActive(true);
        VideoSettings.SetActive(false);
        ControlSettings.SetActive(false);
    }

    public void BtnSettingVideo()
    {
        SoundSettings.SetActive(false);
        VideoSettings.SetActive(true);
        ControlSettings.SetActive(false);
    }
    public void BtnSettingControls()
    {
        SoundSettings.SetActive(false);
        VideoSettings.SetActive(false);
        ControlSettings.SetActive(true);
    }

    public void SetBtnActive()
    {
        if (btnpopup == true)
        {
            BtnPlay.interactable = false;
            BtnOptions.interactable = false;
            BtnQuit.interactable = false;
            BtnCredits.interactable = false;
        }
        else
        {
            BtnPlay.interactable = true;
            BtnOptions.interactable = true;
            BtnQuit.interactable = true;
            BtnCredits.interactable = true;
        }

    }
   
}
