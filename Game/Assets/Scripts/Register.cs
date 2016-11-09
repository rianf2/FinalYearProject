using UnityEngine;
using System.Collections;
using System;
using System.Text.RegularExpressions;
using UnityEngine.UI;

public class Register : MonoBehaviour {

	public GameObject email;
	public GameObject username;
	public GameObject password;
	public GameObject confirmPassword;

	private string e_mail;
	private string u_name;
	private string p_word;
	private string p_wordConfirm;

	private string form;
	private bool emailValid = false;
	private string [] characters = {"a", "b", "c", "d",
									"e", "f", "g", "h",
									"i", "j", "k", "l", 
									"m", "n", "o", "p",
									"q", "r", "s", "t", 
									"u", "v", "w", "x",
									"y", "x", "A", "B",
									"C", "D", "E", "F",
									"G", "H", "I", "J",
									"K", "L", "M", "N", 
									"O", "P", "Q", "R",
									"S", "T", "U", "V",
									"W", "X", "Y", "Z",
									"1", "2", "3", "4",
									"5", "6", "7", "8", 
									"9", "0", "_", "-"
								   };
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Tab))
		{
			if(email.GetComponent<InputField>().isFocused)
			{
				username.GetComponent<InputField>().Select();
			}
			else if(username.GetComponent<InputField>().isFocused)
			{
				password.GetComponent<InputField>().Select();
			}
			else if(password.GetComponent<InputField>().isFocused)
			{
				confirmPassword.GetComponent<InputField>().Select();
			}
		}

		if(Input.GetKeyDown(KeyCode.Return))
		{
			if(p_word != "" && e_mail != "" &&  p_word != "" && p_wordConfirm != "")
			{
				register();
			}
		}

		e_mail = email.GetComponent<InputField>().text;
		u_name = username.GetComponent<InputField>().text;
		p_word = password.GetComponent<InputField>().text;
		p_wordConfirm = confirmPassword.GetComponent<InputField>().text;
	}

	public void register()
	{
		bool UN = false;
		bool EM = false;
		bool PW = false;
		bool CPW = false;

		Debug.Log("Registering...");

		//for unique usernames
		if(u_name != "")
		{
			if(!System.IO.File.Exists(@"G:\Workarea\FYP\Modern_SI\" + u_name + ".txt"))
			{
				UN = true;
			}
			else
			{
				Debug.LogWarning("Username taken");
			}
		}
		else
		{
			Debug.LogWarning("Username is null");
		}

		if(e_mail != "")
		{
			emailValidation();
			if(emailValid)
			{
				if(e_mail.Contains("@") && e_mail.Contains("."))
				{
					EM = true;
				}
				else
				{
					Debug.LogWarning("Email is in wrong format");
				}
			}
			else
			{
				Debug.LogWarning("Email is not vaild");
			}
		}
		else
		{
			Debug.LogWarning("Email is null");
		}

		if(p_word != null)
		{
			if(p_word.Length > 5)
			{
				PW = true;
			}
			else
			{
				Debug.LogWarning("Password is too short");
			}
		}
		else
		{
			Debug.LogWarning("Password is null");
		}

		if(p_wordConfirm != "")
		{
			if(p_wordConfirm == p_word)
			{
				CPW = true;
			}
			else
			{
				Debug.LogWarning("Passwords do not match");
			}
		}
		else
		{
			Debug.LogWarning("Confirm password is null");
		}

		if(UN && EM && PW && CPW)
		{
			bool clear = true;
			int i = 1;

			foreach(char c in p_word)
			{
				if(clear)
				{
					p_word = "";
					clear = false;
				}

				i++;
				char encrypted = (char)(c * i);
				p_word += encrypted.ToString();
			}

			form = (u_name + Environment.NewLine + e_mail + Environment.NewLine + p_word);
			System.IO.File.WriteAllText(@"G:\Workarea\FYP\Modern_SI\" + u_name + ".txt", form);

			email.GetComponent<InputField>().text = "";
			username.GetComponent<InputField>().text = "";
			password.GetComponent<InputField>().text = "";
			confirmPassword.GetComponent<InputField>().text = "";

			print("Registration complete. :) ");
		}
	}

	void emailValidation()
	{
		bool SW = false;
		bool EW = false;

		for(int i = 0;i < characters.Length;i++)
		{
			if(e_mail.StartsWith(characters[i]))
			{
				SW = true;
			}

			if(e_mail.EndsWith(characters[i]))
			{
				EW = true;
			}
		}

		if(SW == true && EW == true)
		{
			emailValid = true;
		}
	}
}
