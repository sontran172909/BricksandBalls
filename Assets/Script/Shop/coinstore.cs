using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinstore : MonoBehaviour
{
    public Text coinText;

    private void Update()
    {
        coinText.text = PlayerPrefs.GetInt("Coin").ToString();
    }
}
