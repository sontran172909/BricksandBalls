using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level_Unlocked : MonoBehaviour
{
  public void levelunlocked(int nextlevel)
  {
    PlayerPrefs.SetInt("levelUnlocked", value: nextlevel);
  }

}
