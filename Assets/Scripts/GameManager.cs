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
    public Button BtnAbout;

    private bool btnpopup = false;

    [SerializeField] public GameObject OptionsMenu;
    [SerializeField] public GameObject SoundSettings;
    [SerializeField] public GameObject VideoSettings;
    [SerializeField] public GameObject ControlSettings;
    [SerializeField] public GameObject menuRoot;
    [SerializeField] public GameObject PopUpExit;
    [SerializeField] public GameObject AboutMenu;

    // osmethings
    public GameObject credits;
    public GameObject creditsb;
    public GameObject creditsc;
   // public GameObject btnaiuda;
    private int aiuda = 0;

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
        BtnAbout.GetComponent<Button>();
        FindObjectOfType<AudioManager>().Play("Menu");
    }
    
    public void DemoLVL()
    {
        SceneManager.LoadScene("Demo");
    }

    public void LoadLevels(int sceneIndex)
    {
        StartCoroutine(WaitForSceneLoad());
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

    IEnumerator WaitForSceneLoad()
    {
        yield return new WaitForSeconds(5);
    }

    public void BtnSettings()
    {
        StartCoroutine(WaitForSceneLoad());
        OptionsMenu.SetActive(true);
        menuRoot.SetActive(false);
    }
    public void BtnAboutGame()
    {
        AboutMenu.SetActive(true);
        menuRoot.SetActive(false);
    }
    public void BtnExit()
    {
       // Debug.Log("a");
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
        //Debug.Log("credits");

        aiuda++;
        if (aiuda == 1)
        {
            credits.SetActive(true);
        }
        if (aiuda == 2)
        {
            creditsb.SetActive(true);
        }
        if (aiuda == 3)
        {
            creditsc.SetActive(true);
            SetBtnActive();

        }
        

    }

    public void BtnSettingsBack()
    {
        OptionsMenu.SetActive(false);
        menuRoot.SetActive(true);
    }

    public void BtnAboutBack()
    {
        AboutMenu.SetActive(false);
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
        StartCoroutine(WaitForSceneLoad());
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
