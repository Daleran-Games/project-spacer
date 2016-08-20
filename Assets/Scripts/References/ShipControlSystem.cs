using UnityEngine;
using System.Collections;

public class ShipControlSystem : ControlSystem {

	VectorPID gridSteeringPID = new VectorPID (0.5f, 0.01f, 1.5f);


	//TEMP PUBLIC
	public float steering = 0f;
	public float PID;
	public float aimAngle;

	void FixedUpdate() {
		Move (controller.GetMovementVector (), controller.GetDriectionVector ());
	}


	protected override void Move (Vector2 movmentVector, Vector2 direction) {
		Rotate (direction);
		thrustVector = setThrustVector (movmentVector);
		rb.AddRelativeForce (thrustVector);
	}

	protected override void Rotate (Vector2 direction) {


		if (direction != Vector2.zero) {	
			aimAngle = Vector2.Angle (rb.transform.up, direction)/180f;

			if (Vector3.Cross (rb.transform.up, direction).z > 0)
				aimAngle = aimAngle * -1f;

			PID = gridSteeringPID.Update (aimAngle, Time.fixedDeltaTime);

			if (aimAngle > 0)
				steering = thrustBlock.ccw;
			else if (aimAngle < 0)
				steering = -thrustBlock.cw;

			if (PID < GlobalVariables.headingDeadZone && PID > -GlobalVariables.headingDeadZone)
				steering = 0f;


			torqueScalar = PID * steering * GlobalVariables.torqueFactor;
			rb.AddTorque (-torqueScalar);
		} 

	}
		
	Vector2 setThrustVector(Vector2 dir) {

		translateThrottle = dir.magnitude;
		thrustVector = Vector2.zero;
		float slope = dir.y / dir.x;

		if (dir.x == 0f && dir.y == 0f) {
			return thrustVector * dir.magnitude;
		} else if (dir.x != 0f && dir.y == 0f) {
			if (dir.x > 0f) {
				thrustVector.x = thrustBlock.right;
				return thrustVector * dir.magnitude;
			} else {
				thrustVector.x = thrustBlock.left;
				return thrustVector * dir.magnitude;
			}
		} else if (dir.x == 0f && dir.y != 0f) {
			if (dir.y > 0f) {
				thrustVector.y = thrustBlock.up;
				return thrustVector * dir.magnitude;
			} else {
				thrustVector.y = thrustBlock.down;
				return thrustVector * dir.magnitude;
			}
		} else if (dir.x>0f) {
			float fr = slope * thrustBlock.right;
			if (slope > (thrustBlock.up / thrustBlock.right)) {
				return new Vector2 (dir.x / dir.y * thrustBlock.up, thrustBlock.up) * dir.magnitude;
			} else if (slope == (thrustBlock.up / thrustBlock.right)) {
				return new Vector2 (thrustBlock.right, thrustBlock.up) * dir.magnitude;
			} else if (slope < (thrustBlock.up / thrustBlock.right) && slope > (thrustBlock.down / thrustBlock.right)) {
				return new Vector2 (thrustBlock.right, fr) * dir.magnitude;
			} else if (slope == (thrustBlock.down / thrustBlock.right)) {
				return new Vector2 (thrustBlock.right, thrustBlock.down) * dir.magnitude;
			} else if (slope < (thrustBlock.down / thrustBlock.right)) {
				return new Vector2 (dir.x / dir.y * thrustBlock.down, thrustBlock.down) * dir.magnitude;
			}
		} else {
			float fl = slope * thrustBlock.left;
			if (slope < (thrustBlock.up / thrustBlock.left)) {
				return new Vector2 (dir.x / dir.y * thrustBlock.up, thrustBlock.up) * dir.magnitude;
			} else if (slope == (thrustBlock.up / thrustBlock.left)) {
				return new Vector2 (thrustBlock.left, thrustBlock.up) * dir.magnitude;
			} else if (slope > (thrustBlock.up / thrustBlock.left) && slope < (thrustBlock.down / thrustBlock.left)) {
				return new Vector2 (thrustBlock.left, fl) * dir.magnitude;
			} else if (slope == (thrustBlock.down / thrustBlock.left)) {
				return new Vector2 (thrustBlock.left, thrustBlock.down) * dir.magnitude;
			} else if (slope > (thrustBlock.down / thrustBlock.left)) {
				return new Vector2 (dir.x / dir.y * thrustBlock.down, thrustBlock.down) * dir.magnitude;
			}

		}

		Debug.Log ("Thrust Block Error: getThrustVector");
		return thrustVector;
	}
}
