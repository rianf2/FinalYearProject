using UnityEngine;
using System.Collections;

public class ClickToRegister : MonoBehaviour 
{
	public void goToLink()
	{
		Application.OpenURL("http:localhost:1337");
	}
}
