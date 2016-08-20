using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public string ProjectileName;
	public float speed = 100f;
	public float burnOut = 1f;
	public int damage = 1;


	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D> ().velocity += (Vector2)transform.up * speed;
		Destroy (gameObject, burnOut);
	
	}

	void OnCollisionEnter2D (Collision2D other) {
		Destroy (gameObject);
	}


}
