using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	/*
	 * IDEA: have a variable for speed to move at. It
	 * creates smoother movement of the player
	 */
	private Vector3 movementVector;
	private float speed = 15.0f;
	/*
	 * Use these at later date for stopping ship when it hits
	 * the left most and right most part of the screen
	 */
	private float xMin, xMax; 

	// Use this for initialization
	void Start () {
		float dist = transform.position.z - Camera.main.transform.position.z;

		Vector3 leftBound = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist));
		Vector3 rightBound = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist));

		xMin = leftBound.x + 0.6f; //finetuned variable
		xMax = rightBound.x - 0.6f;

		Debug.Log("Minimum x value: " + xMin);
		Debug.Log("Maximum x value: " + xMax);
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
		else if(Input.GetKeyDown(KeyCode.Space))
		{
			Debug.Log("FIRE");
		}

		float gamespace = Mathf.Clamp(transform.position.x, xMin, xMax);
		transform.position = new Vector3(gamespace, transform.position.y, transform.position.z);
	}
}
