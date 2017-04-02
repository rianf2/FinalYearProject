using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ControlsBtnScript : MonoBehaviour {

	public void onClick()
	{
		SceneManager.LoadScene("controls");
	}
}
