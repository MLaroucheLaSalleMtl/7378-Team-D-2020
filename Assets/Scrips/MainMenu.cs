using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
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
    // Start is called before the first frame update
    void Start()
    {
        BtnPlay.GetComponent<Button>();
        BtnOptions.GetComponent<Button>();
        BtnQuit.GetComponent<Button>();
        BtnCredits.GetComponent<Button>();
        
    }

    public void BtnNewGame()
    {
        SceneManager.LoadScene(1);
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
