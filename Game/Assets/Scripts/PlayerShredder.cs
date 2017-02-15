using UnityEngine;
using System.Collections;

public class PlayerShredder : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider)
	{
		//dont destroy collider, destroy gameobject acssociated with collider
		Destroy(collider.gameObject);
	}
}
