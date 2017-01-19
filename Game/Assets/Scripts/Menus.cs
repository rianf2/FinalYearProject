using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Menus : MonoBehaviour {

	/*
	 * This was wrong approach to it...each button needs seperate script
	 * oops
	 */

	public GameObject playButton;
	public GameObject leaderboardsButton;
	public GameObject controlsButton;
	public GameObject logoutButton;

	private GameObject [] buttons;

	void Start()
	{
		buttons = new GameObject[4];
		buttons[0] = playButton;
		buttons[1] = leaderboardsButton;
		buttons[2] = controlsButton;
		buttons[3] = logoutButton;
	}

	void onClick()
	{
		if(buttons[0])
		{
			Debug.Log("Playing Game");
		}
		else if(buttons[1])
		{
			Debug.Log("Viewing Leaderboards");
		}
		else if(buttons[2])
		{
			Debug.Log("Learning Controls");
		}
		else if(buttons[3])
		{
			Debug.Log("Logging Out");
			Debug.Log("Saving Details");
			SceneManager.LoadScene("load_screen");
		}
	}
}
