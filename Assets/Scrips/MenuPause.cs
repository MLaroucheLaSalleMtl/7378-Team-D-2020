using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MenuPause : MonoBehaviour
{
    private  bool Pause;
    public GameObject pauseMenu;

    private AsyncOperation async;


    public void OnPause()
    {
            Pause = !Pause;
    }

    void Update()
    {
        GamePaused();
    }

    public void GamePaused()
    {
        if (Pause)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            Pause = true;
        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            Pause = false;
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
