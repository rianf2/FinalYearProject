using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	//needs to be monobehaviour to register with UnityAPI???
	private int damage = 100;

	public int getDamage()
	{
		return damage;
	}

	public void hit()
	{
		Destroy(gameObject);
	}
}
