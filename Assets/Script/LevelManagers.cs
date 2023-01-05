using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManagers : MonoBehaviour
{
    public GameObject[] levelButtons;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("levelUnlocked") == 0)
        {
            PlayerPrefs.SetInt("levelUnlocked", 1);
        }
    }

    private void Start()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].GetComponent<Button>().interactable = false;
        }

        for (int i = 1; i <=PlayerPrefs.GetInt("levelUnlocked"); i++)
        {
            levelButtons[i - 1].GetComponent<Button>().interactable = true;
        }
    }

    public void loadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
