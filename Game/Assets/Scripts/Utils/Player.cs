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

	public void saveDetails(string playerName, int playerScore, double playerTime)
	{
		string url = "localhost:1337/userDetails/" + playerName;
		string json;
		byte[] body;
		WWW wwwSend;
		Dictionary<string, string> headers = new Dictionary<string, string>();

		username = playerName;
		score = playerScore;
		timePlayed += playerTime;

		json = JsonUtility.ToJson(this);
		body = Encoding.UTF8.GetBytes(json);
		headers.Add("Content-Type", "application/json");
		headers.Add("X-HTTP-Method-Override", "put");
		//unity will complain that wwwSend is not being used but it is
		wwwSend = new WWW(url, body, headers);
	}
}
