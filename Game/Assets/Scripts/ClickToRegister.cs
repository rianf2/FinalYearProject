using UnityEngine;
using System.Collections;

public class ClickToRegister : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void goToLink()
	{
		Application.OpenURL("http:localhost:1337");
	}
}
