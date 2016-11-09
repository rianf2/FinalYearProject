using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	private float shootProbability = Random.value;
	public GameObject projectile;
	// Use this for initialization
	void Start () {
		Debug.Log("HELLO FROM ENEMY SCRIPT");
	}
	
	// Update is called once per frame
	void Update () { 
		if(shootProbability < 0.75)
		{
			Vector3 startPos = transform.position + new Vector3(0, -1, 0);
			GameObject missile = Instantiate(projectile, startPos, Quaternion.identity) as GameObject;
			missile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -10f);
		}
	}
}
