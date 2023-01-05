using System;
using System.Collections;
using System.Collections.Generic;
using DunnGSunn;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public Image[] Star;
    public Sprite emptyStar;
    public int level;
    public Text levelText;
    
    private void Start()
    {
        levelText.text = level.ToString();
        var star = PlayerPrefs.GetInt("level_" + level, 0);
        for (int i = 0; i < star; i++)
        {
            Star[i].sprite = emptyStar;
        }
    }
    public void OpenScene()
    {
        TestStatic.Instance.CurrentLevelPlaying = level;
        SceneManager.LoadScene("Level" + level.ToString());
    }
    
}
