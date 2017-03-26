using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UsernameController : MonoBehaviour 
{
	public static UsernameController instance;
	public string username;
	public double timePlayed;
	private Text text;

	void Awake()
	{
		if (instance == null) {
			DontDestroyOnLoad (gameObject);
			instance = this;
		} 
		else if (instance != null) 
		{
			Destroy(gameObject);
		}
	}

	void Start () 
	{
		text = GetComponent<Text> ();
	}
	
	public string getUsername()
	{
		username = text.text.ToString();
		return username;
	}

	public void setUsername(string username)
	{
		text.text = username;
	}

	public void setTimePlayed(double timePlayed)
	{
		this.timePlayed = timePlayed;
	}

	public double getTimePlayed()
	{
		return timePlayed;
	}
}
