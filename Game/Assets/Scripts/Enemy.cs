using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public GameObject projectile;

	private float missileSpeed = 10;
	private int health = 100;
	private float frequency = 0.4f;
	private int value = 10;
	private ScoreController scoreController;
	public AudioClip shootSound; //link to audio: http://www.freesound.org/people/jobro/sounds/35679/
	public AudioClip deadSound; //link to audio: http://www.freesound.org/people/wubitog/sounds/200465/
	private EnemySpawner es; //need access to this to change speed of enemies

	void Start () 
	{
		scoreController = GameObject.Find("ScoreText").GetComponent<ScoreController>();
		es = GameObject.Find("EnemyPositions").GetComponent<EnemySpawner>();
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
				dead();
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
		missile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -missileSpeed);
		AudioSource.PlayClipAtPoint(shootSound, transform.position);
	}

	void dead()
	{
		AudioSource.PlayClipAtPoint(deadSound, transform.position);
		scoreController.score(value);

		if (scoreController.getScore () % 100 == 0) 
		{
			int selectedValue = Random.Range (0, 3); //the 3 is because 3 factors are being modified, CHANGE

			const int healthModifier = 50;
			const float speedModifier = 0.5f;
			const float frequencyModifier = 0.05f;

			switch (selectedValue) 
			{
				case 0:
					es.setSpeed (es.getSpeed() + speedModifier);
					Debug.Log("Modifying enemy speed");
				break;

				case 1:
					this.health = this.health + healthModifier;
					Debug.Log("Modifying enemy health");
				break;

			case 2:
				this.frequency = this.frequency + frequencyModifier;
				if (this.frequency > 0.85) 
				{
					this.frequency = 0.85f;
				}
				Debug.Log("Modifying enemy frequency");
			break;
			}
		}
		Destroy(gameObject);
	}
}
