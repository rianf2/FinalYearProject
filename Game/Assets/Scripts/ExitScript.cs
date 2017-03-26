using UnityEngine;
using System.Collections;

public class ExitScript : MonoBehaviour 
{
	public void onClick()
	{
		Debug.Log("Time to exit the game");
		Application.Quit();
	}
}
