using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinspin : MonoBehaviour
{

    public Text cointext;

    void Update()
    {
        cointext.text = PlayerPrefs.GetInt("Coin").ToString();
    }
}
