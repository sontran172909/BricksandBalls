using UnityEngine.UI;
using System;
using UnityEngine;
using UnityEngine.Audio;
using Random = System.Random;

public class audioManager : MonoBehaviour
{

	public static audioManager instance;

	public AudioSource bgMusic, soundGame, soundGamecollission;

	public AudioClip[] musicBgClip;
	public AudioClip[] soundClip;
	public bool musicStart { get; set; }
	void Awake()
	{
		if (PlayerPrefs.GetInt("CheckMusicStart") == 0)
		{
			musicStart = false;
		}
		else
		{
			musicStart = true;
		}
		if (musicStart == false)
		{
			PlayerPrefs.SetFloat("musicbg", 1);
			PlayerPrefs.SetFloat("sound", 1);
			
			musicStart = true;
			PlayerPrefs.SetFloat("CheckMusicStart",(musicStart ? 1: 0));
		}
		
		
		if (instance != null)
		{
			Destroy(gameObject);
			return;
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	
		bgMusic.volume = PlayerPrefs.GetFloat("musicbg");
		soundGame.volume = PlayerPrefs.GetFloat("sound");
	}
	
	public void SetMusicBg()
	{
		int rd = UnityEngine.Random.Range(0,musicBgClip.Length);
		bgMusic.clip = musicBgClip[rd];
		bgMusic.Play();
		
		bgMusic.volume = PlayerPrefs.GetFloat("musicbg");
	}
	
	public void SetSound(int id, bool l)
	{
		
		soundGame.clip = soundClip[id];
		soundGame.Play();
		soundGame.loop = l;
		soundGame.volume = PlayerPrefs.GetFloat("sound");
	}

	public void collisionBall()
	{
		soundGamecollission.clip = soundClip[0];
		soundGamecollission.Play();
		// if (PlayerPrefs.GetFloat("sound") > 0)
		// {
		// 	soundGamecollission.volume = 0.4f;
		// }
		// else
		// {
		// 	soundGamecollission.volume = 0;
		// }
	}
	
	public void VolumeMusicBg(float t )
	{
		bgMusic.volume = t;
		
	}
	public void VolumeSound(float g )
	{
		
		soundGame.volume = g;
		soundGamecollission.volume = Mathf.Clamp(g, 0f, .3f);
	}
	

}

