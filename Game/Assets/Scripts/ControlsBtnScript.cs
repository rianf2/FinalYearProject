using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ControlsBtnScript : MonoBehaviour {

	public void onClick()
	{
		Debug.Log("Looking at controls");
		SceneManager.LoadScene("controls");
	}
}
