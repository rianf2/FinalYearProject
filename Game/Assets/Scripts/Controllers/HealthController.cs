using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthController : MonoBehaviour {

	public int currentHealth = 250;
	private Text text;

	void Start()
	{
		text = GetComponent<Text> ();
	}

	public void decrease(int damage)
	{
		currentHealth -= damage;
		text.text = "Health: " + currentHealth.ToString();
	}

	public void reset()
	{
		currentHealth = 0;
		text.text = "Health: " + currentHealth.ToString();
	}

	public int getHealth()
	{
		return currentHealth;
	}
}
