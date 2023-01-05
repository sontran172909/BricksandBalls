using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundButton : MonoBehaviour
{
    // Start is called before the first frame update
    public Button buttonDaily;
    public Button buttonSpin;
    public Button buttonSetting;
    public Button buttonShop;
    public Button buttonTask;
    public Button buttonSkin;
    public Button buttonVang;
    public Button buttonBall;
    public Button buttonTime;
    public Button buttoncloseDaily;
    public Button buttoncloseSpin;
 
    private void Reset()
    {
        buttonDaily = GetComponent<Button>();
        buttonSpin = GetComponent<Button>();
        buttonSetting = GetComponent<Button>();
        buttonShop = GetComponent<Button>();
        buttonTask = GetComponent<Button>();
        buttonSkin = GetComponent<Button>();
        buttonVang = GetComponent<Button>();
        buttonBall = GetComponent<Button>();
        buttonTime = GetComponent<Button>();
        buttoncloseDaily = GetComponent<Button>();
        buttoncloseSpin = GetComponent<Button>();
    }

    private void Start()
    {
        buttonDaily.onClick.AddListener(onclickGrade);
        buttonSpin.onClick.AddListener(onclickGrade);
        buttonSetting.onClick.AddListener(onclickGrade);
        buttonShop.onClick.AddListener(onclickGrade);
        buttonTask.onClick.AddListener(onclickGrade);
        buttonSkin.onClick.AddListener(onclickGrade);
        buttonVang.onClick.AddListener(onclickGrade);
        buttonBall.onClick.AddListener(onclickGrade);
        buttonTime.onClick.AddListener(onclickGrade);
        buttoncloseDaily.onClick.AddListener(onclickGrade);
        buttoncloseSpin.onClick.AddListener(onclickGrade);
    }

    public void onclickGrade()
    {
        buttonDaily.enabled = true;
        audioManager.instance.SetSound(3, false);
    }
}
