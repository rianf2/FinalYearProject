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
	private string url;

	void Start()
	{
		
	}

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
			if(p_word != "" && u_name != "")
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

		url = "http://localhost:1337/userDetails/" + u_name;
		Debug.Log(url);
		WWW www = new WWW(url);
		StartCoroutine(serverInteract(www));
	}

	IEnumerator serverInteract(WWW www)
	{
		yield return www;

		if(www.error == null)
		{
			Debug.Log(www.text);
			string json = www.text;
			Player p = new Player();
			p = JsonUtility.FromJson<Player>(json);

			if(p_word.Equals(p.password))
			{
				SceneManager.LoadScene("menu_screen");
			}
			else{
				Debug.Log("SCENE ERROR");
			}
		}
		else
		{
			Debug.Log(www.error);
		}
	}
}

[System.Serializable]
public class Player
{
	public string username;
	public string password;
	public int highscore;
	public float time;
}