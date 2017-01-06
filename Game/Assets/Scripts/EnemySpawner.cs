﻿using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;
	public float width = 15f;
	public float height = 11f;
	private bool moveRight = false;
	public float speed = 5f;
	private float xMin, xMax;

	// Use this for initialization
	void Start () {

		float cameraDistance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftBound = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, cameraDistance));
		Vector3 rightBound = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, cameraDistance));

		xMin = leftBound.x;
		xMax = rightBound.x;

		foreach(Transform child in transform)
		{
			GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
	}

	public void OnDrawGizmos()
	{
		Vector3 offset = new Vector3(0, 2, 0);
		Vector3 center = transform.position + offset;
		Gizmos.DrawWireCube(center, new Vector3(width, height, 0));
	}

	// Update is called once per frame
	void Update () 
	{
		if(moveRight)
		{
			transform.position += Vector3.right * speed *Time.deltaTime;
		}
		else
		{
			transform.position += Vector3.left * speed * Time.deltaTime;
		}

		float rightFormation = transform.position.x + (0.5f * width);
		float leftFormation = transform.position.x - (0.5f * width);

		if(leftFormation < xMin)
		{
			Debug.Log("TIME TO GO RIGHT");
			moveRight = true;
		}
		else if(rightFormation > xMax)
		{
			/*
			 * There was a problem here, used the wrong sign and as a 
			 * result, the enemyies would only travel one direction forever
			 * Solved by checking is RF > xMax...think of better way to
			 * write this for report :)
			 */
			Debug.Log("TIME TO GO LEFT");
			moveRight = false;
		}
	}
}