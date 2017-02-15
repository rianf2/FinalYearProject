using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public GameObject projectile;

	private float shootProbability;
	private float speed = 10;
	private int health = 150;
	private float frequency = 0.5f;
	private int value = 10;
	private ScoreController scoreController;

	void Start () 
	{
		scoreController = GameObject.Find("ScoreText").GetComponent<ScoreController>();
		shootProbability = Random.value;
	}
	
	// Update is called once per frame
	void Update () 
	{ 
		// P(fire) = time_elapsed * frequency
		//probability of firing depends on how long has elapsed and the frequency
		float probability = Time.deltaTime * frequency;

		if(Random.value < probability)
		{
			shoot();
		}
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		Projectile laser = collider.gameObject.GetComponent<Projectile>();

		if(laser)
		{
			health -= laser.getDamage();
			laser.hit();
			if(health <= 0)
			{
				scoreController.score(value);
				Destroy(gameObject);
			}
		}
	}

	public int getHealth()
	{
		return health;
	}

	void shoot()
	{
		Vector3 startPosition = transform.position + new Vector3(0, -1, 0);
		GameObject missile = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;
		missile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
	}
}
