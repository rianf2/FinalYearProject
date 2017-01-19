using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayBtnScript : MonoBehaviour {

	public void onClick()
	{
		Debug.Log("Playing game");
		SceneManager.LoadScene("load_screen");
	}
}