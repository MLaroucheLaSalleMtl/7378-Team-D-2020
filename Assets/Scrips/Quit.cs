using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Quit : MonoBehaviour
{
    private AsyncOperation async;

    public void loadScene(int i)
    {
        if (async == null) {
            async = SceneManager.LoadSceneAsync(i);
            async.allowSceneActivation = true;
        }
    }
    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
