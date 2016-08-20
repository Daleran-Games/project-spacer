using UnityEngine;
using System.Collections;

public abstract class Weapon : Part {

	protected Rigidbody2D rb;
	protected AudioSource bulletSound;

	public override void Initialize () {

		rb = transform.root.GetComponent<Rigidbody2D> ();
		partCollider = GetComponent<Collider2D> ();
		bulletSound = GetComponent<AudioSource> ();

	}

	public abstract void Fire ();


}
