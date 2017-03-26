using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LeaderboardsBtnScript : MonoBehaviour {

	public void onClick()
	{
		Application.OpenURL("http://localhost:1337");
	}
}