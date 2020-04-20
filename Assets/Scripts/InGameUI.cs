using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;

//Ask FC
public class InGameUI : MonoBehaviour
{
    [Header("Pause Menu")]
    private bool pause;
    public GameObject pauseMenu; //UI Pause Menu
    private AsyncOperation async;

    [Header("Player UI")]
    public Slider HealthBar;
    public Slider StaminaBar;
    public Text LivesTxT;
    public Text Score;
    private float lives;
    private float health;
    private float stamina;


    [Header("Death Screen")]
    private bool death;
    public GameObject deathScreen;
    public GameObject playerUI;

    public void updateScore(int scr)
    {       
        Score.text = "Score:" + scr.ToString();
       
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            pause = !pause;
        }
    }
    private void Start()
    {
        HealthBar.maxValue = PlayerStats.maxHealth;
       // StaminaBar.maxValue = PlayerStats.maxStamina;
    }

    void Update()
    {
        health = PlayerStats.currHealth;
       // stamina = PlayerStats.currStamina;
        lives = PlayerStats.playerlives;
        death = PlayerStats.death;
        UpdateUI(); 
        GamePaused();
        deathUI();
    }

    public void deathUI()
    {
        if (death == true)
        {
                deathScreen.SetActive(true);
                playerUI.SetActive(false);
        }
        else
        {
            deathScreen.SetActive(false);
        }
       
    }
    public void UpdateUI()
    {
       // Debug.Log(health);
        HealthBar.value = health;
        LivesTxT.text = (lives.ToString());
        StaminaBar.value = stamina;
    }

    public void GamePaused()
    {
        if (pause)
        {
            pauseMenu.SetActive(true);
            playerUI.SetActive(false);
            Time.timeScale = 0f;
            pause = true;
        }
        else
        {
            playerUI.SetActive(true);
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            pause = false;
        }
    }

    public void LoadScene(int i)
    {
        if (async == null)
        {
            async = SceneManager.LoadSceneAsync(i);
            async.allowSceneActivation = true;
        }
    }
    public void LoadCurrentScene()
    {
        PlayerStats.retry = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
