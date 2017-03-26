using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

[System.Serializable]
public class Player
{
	public string username;
	public string password;
	public int score;
	public double timePlayed;


	public string getPassword()
	{
		//encrypt here
		return password;
	}

	public void saveDetails(string playerName, int score, double timePlayed)
	{
		string url = "localhost:1337/userDetails/" + playerName;
		this.username = playerName;
		this.score = score;
		this.timePlayed += timePlayed;

		string json = JsonUtility.ToJson(this);
		Debug.Log(json);
		byte [] body = Encoding.UTF8.GetBytes(json);
		Dictionary<string, string> headers = new Dictionary<string, string>();
		headers.Add("Content-Type", "application/json");
		headers.Add("X-HTTP-Method-Override", "put");
		WWW www = new WWW(url, body, headers);
		Debug.Log("Form sent");
		Debug.Log(url);
	}

	public string createURL(string pName)
	{
		return "localhost:1337/userDetails/" + pName;
	}
}
