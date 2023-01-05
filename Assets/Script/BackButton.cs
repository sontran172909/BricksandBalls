using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadScene("Global");
    }

    public void DailyReWard()
    {
        SceneManager.LoadScene("Daily Rewards Landscape");
    }

    public void Task()
    {
        SceneManager.LoadScene("Task");
    }

    public void Skin()
    {
        SceneManager.LoadScene("Skin");
    }

    // public Button thisbuttonExit;
    // public GameObject SkinShop;
    //
    // private void Start()
    // {
    //     thisbuttonExit.onClick.AddListener(onclick);
    // }
    //
    // public void onclick()
    // {
    //     thisbuttonExit.GetComponent<Button>().enabled = true;
    //     SkinShop.SetActive(false);
    // }
}
