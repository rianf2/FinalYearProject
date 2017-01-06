﻿using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	private float shootProbability;
	private int health = 150;
	//public GameObject projectile;
	// Use this for initialization
	void Start () {
		Debug.Log("HELLO FROM ENEMY SCRIPT");
		shootProbability = Random.value;
	}
	
	// Update is called once per frame
	void Update () { 
		if(shootProbability < 0.75)
		{
			Debug.Log("Shooting a laser");
			//Vector3 startPos = transform.position + new Vector3(0, -1, 0);
			//GameObject missile = Instantiate(projectile, startPos, Quaternion.identity) as GameObject;
			//missile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -10f);
		}
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		Debug.Log("HIT");
		Projectile laser = collider.gameObject.GetComponent<Projectile>();

		if(laser)
		{
			health -= laser.getDamage();
			laser.hit();
			if(health <= 0)
			{
				Destroy(gameObject);
			}
		}
	}
}
