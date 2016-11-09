using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	/*
	 * IDEA: have a variable for speed to move at. It
	 * creates smoother movement of the player
	 */
	private Vector3 movementVector;
	/*
	 * Use these at later date for stopping ship when it hits
	 * the left most and right most part of the screen
	 */
	private int xMin, xMax; 

	// Use this for initialization
	void Start () {
		movementVector = new Vector3(1, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
		//switch styatemant???
		if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
		{
			transform.position -= movementVector;
			Debug.Log("Key pressed: A");
		}
		else if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
		{
			Debug.Log("Key pressed: D");
			transform.position += movementVector;
		}
		else if(Input.GetKeyDown(KeyCode.Space))
		{
			Debug.Log("FIRE");
		}
	}
}
