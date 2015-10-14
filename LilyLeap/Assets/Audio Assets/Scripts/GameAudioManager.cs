using UnityEngine;
using System.Collections;

public class GameAudioManager : MonoBehaviour {

	public static GameAudioManager instance = null;

	public AudioSource Click;
	public AudioSource Jump;
	public AudioSource Land;
	public AudioSource BackgroundMusic;

	public static GameAudioManager Instance {
		get{
			return GameAudioManager.instance;
		}
	}

	void Awake()
	{
		if (GameAudioManager.instance == null) {
				
				instance = this;
			} else if (instance != this) {
				Destroy(gameObject);
			}
			DontDestroyOnLoad(gameObject);

	}

	public void PlayClick()
	{
		Click.Play();
	}

	public void PlayJump()
	{
		if(Jump.isPlaying == false)
		{
			Jump.Play();
		}
	}

	public void BackgroundMusicPlay()
	{
		if(BackgroundMusic.isPlaying == false)
		{
			BackgroundMusic.Play();
		}

		
	}

	public void OnApplicationQuit()
	{
		GameAudioManager.instance = null;
	}
}
