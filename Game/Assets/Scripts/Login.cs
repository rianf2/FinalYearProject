using UnityEngine;
using System.Collections;
using System;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour {

	public GameObject username;
	public GameObject password;

	private string u_name;
	private string p_word;

	// Update is called once per frame
	void Update () {
		u_name = username.GetComponent<InputField>().text;
		p_word = password.GetComponent<InputField>().text;

		if(Input.GetKeyDown(KeyCode.Tab))
		{
			if(username.GetComponent<InputField>().isFocused)
			{
				password.GetComponent<InputField>().Select();
			}
		}

		if(Input.GetKeyDown(KeyCode.Return))
		{
			if(p_word != "")
			{
				login();
			}
		}
	}

	public void login()
	{
		//czech this out: answers.unity3d.com/questions/935800/

		Debug.Log(u_name);
		Debug.Log(p_word);


		if(u_name.Equals("RianF2") && p_word.Equals("banana"))
		{
			Debug.Log("Logging in...yay!!!");
			SceneManager.LoadScene("menu_screen");
		}
	}
}
