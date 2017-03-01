using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	static MusicPlayer instance = null;

	public AudioClip startMusic;
	public AudioClip gameMusic;
	public AudioClip endMusic;

	private AudioSource player;

	void Start () 
	{
		if(instance != null && instance != this)
		{
			Destroy(gameObject);
			Debug.Log("Destroying dupliate music player");
		}
		else
		{
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
			player = GetComponent<AudioSource>();
			player.clip = startMusic; //play this sound by default
			player.loop = true;
		}
	}

	void OnLevelWasLoaded(int level)
	{
		Debug.Log("MusicPlayer: loaded level " + level);
		player.Stop();

		if(level == 0)
		{
			player.clip = startMusic;
			player.Play();
		}

		if(level == 1)
		{
			player.clip = gameMusic;
			player.Play();
		}

		if(level == 2)
		{
			player.clip = endMusic;
			player.Play();
		}

		player.loop = true;
	}
}
