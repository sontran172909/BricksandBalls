﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuLevel : MonoBehaviour
{
    public void OpenMenu()
    {
        SceneManager.LoadScene("MenuLevel");
    }
}
