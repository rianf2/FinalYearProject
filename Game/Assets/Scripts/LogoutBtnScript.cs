using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LogoutBtnScript : MonoBehaviour {

	public void onClick()
	{
		Debug.Log("Logging out");
		Debug.Log("Should make sure details are saved");
		SceneManager.LoadScene("login_screen");
	}
}
