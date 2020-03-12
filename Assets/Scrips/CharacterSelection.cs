using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{

    public GameObject[] characterList;
    private int index;
    public GameObject Buttons;
    public GameObject cameraFollow;
    public GameObject InvisibleWall;

    // Start is called before the first frame update
    void Start()
    {
        index = PlayerPrefs.GetInt("CharacterSelected");
        characterSelection();
        checkCameraFollow();
    }

    // Update is called once per frame
    void Awake()
    {
       // DontDestroyOnLoad(transform.gameObject);
    }
   
    public void checkCameraFollow()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.buildIndex >= (2))
        {
            cameraFollow.transform.parent = characterList[index].transform;
        }

    }
    public void characterSelection()
    {
        characterList = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            characterList[i] = transform.GetChild(i).gameObject;
        }
        foreach (GameObject go in characterList)
        {
            go.SetActive(false);
        }
        if (characterList[index])
        {
            characterList[index].SetActive(true);
        }
    }

    public void buttonLeft()
    {
        characterList[index].SetActive(false);

        index--;
        if (index < 0)
        {
            index = characterList.Length - 1;
        }

        characterList[index].SetActive(true);
    }

    public void buttonRight()
    {
        characterList[index].SetActive(false);

        index++;
        if (index == characterList.Length)
        {
            index = 0;
        }

        characterList[index].SetActive(true);
    }
    public void buttonConfirm()
    {
        if (InvisibleWall.activeInHierarchy)
        {
            InvisibleWall.SetActive(false);
        }
        if (Buttons.activeInHierarchy)
        {
            Buttons.SetActive(false);
        }

        PlayerPrefs.SetInt("CharacterSelected", index);
        cameraFollow.transform.parent = characterList[index].transform;

        SceneManager.LoadScene(2);
        
    }
}
