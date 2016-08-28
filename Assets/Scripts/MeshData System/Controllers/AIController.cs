using UnityEngine;
using System.Collections;

public class AIController : Controller {

	public GameObject Target; //Temporarty value that will have the AI chase an editor selected target


	// Update is called once per frame
	void FixedUpdate () {

		Vector3 MousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector2 targetDir = MousePos - transform.position;
		Vector2 velocity = rb.velocity;

		if (getRangeToTargetFloat (Target) >= 30f) {
			movementVector = Vector2.up;
		} else if ((getRangeToTargetFloat (Target) < 25f)) {
			movementVector  = Vector2.down;
		} else
			movementVector  = Vector2.zero;

		aimPoint = getRangeToTargetVector (Target);

		//grid.logic.Move (MVMT, getRangeToTargetVector(Target), false);

	
	}



	float getRangeToTargetFloat (GameObject target) {
		return (target.transform.position - rb.transform.position).magnitude;
	}

	Vector2 getRangeToTargetVector (GameObject target) {
		return (Vector2)(target.transform.position - rb.transform.position);
	}

	float getOptimalRange() {
		return 100f;
	}



}
