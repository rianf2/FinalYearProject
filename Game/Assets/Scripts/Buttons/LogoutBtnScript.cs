using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LogoutBtnScript : MonoBehaviour 
{
	private UsernameController usernameController;

	void Start()
	{
		usernameController = GameObject.Find ("Username").GetComponent<UsernameController> ();
	}

	public void onClick()
	{
		usernameController.setUsername("");
		/*
		 * Have a setPassword method in UsernameController to reset it?
		 */
		SceneManager.LoadScene("login_screen");
	}
}
