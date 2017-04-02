using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BackBtn : MonoBehaviour {

	public void onClick()
	{
		SceneManager.LoadScene("menu_screen");
	}
}
