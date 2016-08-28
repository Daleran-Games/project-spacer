using UnityEngine;
using System.Collections;

public abstract class Controller : MonoBehaviour {

	public Vector2 aimPoint; // location relative to the ship the weapons should aim at
    public Vector2 movementVector; //vector that the ship should translate towards with a throttle modifer of the magnitude Magnitude must be between 0 and 1.
    public Vector2 directionVector; // vector that the ship should rotate twoards with a throttle modifer of the magnitude. Magnitude must be between 0 and 1.
    public Rigidbody2D rb;
    public bool isFiring;


	// TEMP PUBLIC
	public Vector2 localVelocity;
	// TEMP PUBLIC

	public virtual void InitializeController () {
		rb = GetComponent<Rigidbody2D> ();

	}

	public virtual Vector2 GetMovementVector() {
		return movementVector;
	}

	public virtual Vector2 GetAimPoint (){
		return aimPoint;
	}

	public virtual Vector2 GetDriectionVector() {
		return directionVector;
	}

	public virtual bool IsFiring () {
		return isFiring;
	}

}
