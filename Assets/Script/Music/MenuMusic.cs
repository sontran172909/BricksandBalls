using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuMusic : MonoBehaviour
{

    public Slider MusicSlider;
    //public AudioMixer mixer;
    private float value;
    public Slider SoundSlider;

    private void Start()
    {
        MusicSlider.value = PlayerPrefs.GetFloat("musicbg");
       SoundSlider.value = PlayerPrefs.GetFloat("sound");
    }
    

    public void Setvolume()
    {
        PlayerPrefs.SetFloat("musicbg",MusicSlider.value);
        audioManager.instance.VolumeMusicBg(PlayerPrefs.GetFloat("musicbg"));
       PlayerPrefs.SetFloat("sound", SoundSlider.value);
       audioManager.instance.VolumeSound(PlayerPrefs.GetFloat("sound"));
    }
    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);

    }
}
