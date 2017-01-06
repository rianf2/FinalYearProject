using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public GameObject missile;
	private float speed = 15.0f;
	private float xMin, xMax; 
	public float projectileSpeed;

	// Use this for initialization
	void Start () {
		float dist = transform.position.z - Camera.main.transform.position.z;

		Vector3 leftBound = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist));
		Vector3 rightBound = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist));

		xMin = leftBound.x + 0.6f; //finetuned variable
		xMax = rightBound.x - 0.6f;
	}
	
	// Update is called once per frame
	void Update () {
		
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
	}
}
