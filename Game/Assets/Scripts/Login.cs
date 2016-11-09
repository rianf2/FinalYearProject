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
		/*bool UN = false;
		bool PW = false;

		//if(u_name != "")
		{
			if(System.IO.File.Exists(@"G:\Workarea\FYP\Modern_SI\" + u_name + ".txt"))
			{
				Debug.Log("You are logged in "  + u_name + " :)");
			}
		}*/

		//quick hacked together test to see if logging in is hard
		//realistically this should query the db for user details
		if(u_name.Equals("RianF2") && p_word.Equals("banana"))
		{
			Debug.Log("Logging in...yay!!!");
			SceneManager.LoadScene("load_screen");
		}
	}
}
