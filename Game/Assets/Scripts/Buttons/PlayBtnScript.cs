using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayBtnScript : MonoBehaviour {

	public void onClick()
	{
		SceneManager.LoadScene("load_screen");
	}
}