using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour 
{
	public GameObject missile;

	private Player p;
	private float speed = 15.0f;
	private int health = 250;
	private float xMin, xMax; 
	private float projectileSpeed = 10f;
	private ScoreController scoreController;
	private HealthController healthController;
	public AudioClip shootSound; //link to audio: http://www.freesound.org/people/djfroyd/sounds/348163/
	private UsernameController uC;
	private float timePlayed;

	void Start () 
	{
		timePlayed = 0.0f;
		healthController = GameObject.Find("HealthText").GetComponent<HealthController>();
		p = new Player();
		scoreController = GameObject.Find("ScoreText").GetComponent<ScoreController>();
		uC = GameObject.Find("Username").GetComponent<UsernameController>();
		float dist = transform.position.z - Camera.main.transform.position.z;

		Vector3 leftBound = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist));
		Vector3 rightBound = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist));

		xMin = leftBound.x + 0.6f;
		xMax = rightBound.x - 0.6f;
	}
	

	void Update () 
	{
		timePlayed += Time.deltaTime;
		/*
		 * For report: there was a problem here. Input.GetKeyDown only 
		 * registered when key was pressed (duh) ond only moved one unit.
		 * When changed to Input.GetKey, allowed for fluid movement. Think
		 * of better way to write this for report
		 */
		if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			transform.position += Vector3.right * speed * Time.deltaTime;
		}

		if(Input.GetKeyDown(KeyCode.Space))
		{
			InvokeRepeating("shoot", 0.00001f, 0.2f);
		}

		if(Input.GetKeyDown(KeyCode.Escape))
		{


			Debug.Log(uC.getUsername());
			Debug.Log("p.saveDetails()");
			uC.setTimePlayed (uC.getTimePlayed () + Math.Round((timePlayed / 60), 2));
			p.saveDetails(uC.getUsername(), scoreController.getScore(), uC.getTimePlayed());
			SceneManager.LoadScene("menu_screen");
		}
		/*
		 * There was a problem here, originally use else if but only 
		 * one projectile was fired at a time. 
		 */
		if(Input.GetKeyUp(KeyCode.Space))
		{
			CancelInvoke("shoot");
		}

		float gamespace = Mathf.Clamp(transform.position.x, xMin, xMax);
		transform.position = new Vector3(gamespace, transform.position.y, transform.position.z);
	}

	void shoot()
	{
		Vector3 offset = new Vector3(0, 1, 0);
		GameObject beam = Instantiate(missile, transform.position + offset, Quaternion.identity) as GameObject;
		beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed, 0);
		AudioSource.PlayClipAtPoint(shootSound, transform.position);
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		Projectile laser = collider.gameObject.GetComponent<Projectile>();

		if(laser)
		{
			healthController.decrease( laser.getDamage() );
			laser.hit();

			if(healthController.getHealth() <= 0)
			{
				uC.setTimePlayed (uC.getTimePlayed () + Math.Round((timePlayed / 60), 2));
				p.saveDetails(uC.getUsername(), scoreController.getScore(), uC.getTimePlayed());
				Destroy(gameObject);
				SceneManager.LoadScene("menu_screen");
			}
		}
	}
}
