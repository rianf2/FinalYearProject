﻿using UnityEngine;
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
	private string url;
	private Player p;
	private UsernameController uC;

	void Start()
	{
		uC = GameObject.Find("Username").GetComponent<UsernameController>();
	}

	void Update () 
	{
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
			if ( !p_word.Equals("") && !u_name.Equals("") ) 
			{
				login ();
			}
		}
	}

	public void login()
	{
		url = "http://localhost:1337/userDetails/" + u_name;

		if (url.Equals ("http://localhost:1337/userDetails/")) 
		{
			Debug.Log ("Not going to log you in");
		} 
		else 
		{
			WWW www = new WWW (url);
			StartCoroutine (serverInteract (www));
		}
	}

	IEnumerator serverInteract(WWW www)
	{
		yield return www;

		if(www.error == null)
		{
			string json = www.text;
			p = new Player();
			p = JsonUtility.FromJson<Player>(json);
			uC.setTimePlayed(p.timePlayed);
			uC.setUsername (p.username);

			if(p_word.Equals(p.getPassword() ))
			{
				SceneManager.LoadScene("menu_screen");
			}
			else{
				Debug.Log("Error: Unable to login");
			}
		}
		else
		{
			Debug.Log(www.error);
		}
	}
}