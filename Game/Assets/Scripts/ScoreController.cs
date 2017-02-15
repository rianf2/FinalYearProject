using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreController : MonoBehaviour 
{
	public int currentScore = 0;
	private Text text;

	void Start()
	{
		text = GetComponent<Text>();
	}

	public void score(int points)
	{
		currentScore += points;
		text.text = "Score: " + currentScore.ToString();
	}

	public void reset()
	{
		currentScore = 0;
		text.text = "Score: " + currentScore.ToString();
	}
}
