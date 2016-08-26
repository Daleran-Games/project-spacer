using UnityEngine;
using System.Collections;

public class ThrustModule : Module {

	public float thrust;

	//TEMP PUBLIC
	public float throttle;
	//TEMP PUBLIC

	public Vector3 Orientation;
	ControlSystem controlSystem;



	// Use this for initialization
	public override void Initialize () {
		controlSystem = transform.root.GetComponent<ControlSystem> ();
		Orientation = Vector3.zero;
		setOrientation ();
		controlSystem.ModifyThrust (Orientation, thrust, true);

	}

	void FixedUpdate() {
		if (shouldThrusterFire (controlSystem.GetThrustVector(),controlSystem.GetTorqueScalar()))
			throttle = controlSystem.GetTorqueFractional () + controlSystem.GetTranslationFractional ();
		else
			throttle = 0f;
	}
		
	void OnDestroy() {
		controlSystem.ModifyThrust (Orientation, thrust, false);
	}

	public float getThrottle () {
		return throttle;
	}

	private bool confirmDirection (float angle) {
		if (transform.localEulerAngles.z > (angle - GlobalVariables.directionError) && transform.localEulerAngles.z < (angle + GlobalVariables.directionError)) {
			return true;
		} else {
			return false;
		}
			
	}

	private void setOrientation () {

		if (confirmDirection (0)) 
			Orientation = new Vector3 (0f, 1f, 0f);
		if (confirmDirection (180))
			Orientation = new Vector3 (0f, -1f, 0f);
		if (confirmDirection (90))
			Orientation = new Vector3 (-1f, 0f, 0f);
		if (confirmDirection (270))
			Orientation = new Vector3 (1f, 0f, 0f);

		if (confirmDirection (180) && transform.localPosition.x < (0 - GlobalVariables.directionError) && transform.localPosition.y > (0 + GlobalVariables.directionError))
			Orientation.z = -1f;
		if (confirmDirection (270) && transform.localPosition.x < (0 - GlobalVariables.directionError) && transform.localPosition.y > (0 + GlobalVariables.directionError))
					Orientation.z = 1f;
		if (confirmDirection (180) && transform.localPosition.x > (0 + GlobalVariables.directionError) && transform.localPosition.y > (0 + GlobalVariables.directionError))
					Orientation.z = 1f;
		if (confirmDirection (90) && transform.localPosition.x > (0 + GlobalVariables.directionError) && transform.localPosition.y > (0 + GlobalVariables.directionError))
					Orientation.z = -1f;
		if (confirmDirection (90) && transform.localPosition.x > (0 + GlobalVariables.directionError) && transform.localPosition.y < (0 - GlobalVariables.directionError))
					Orientation.z = 1f;
		if (confirmDirection (270) && transform.localPosition.x < (0 - GlobalVariables.directionError) && transform.localPosition.y < (0 - GlobalVariables.directionError))
					Orientation.z = -1f;
		if (confirmDirection (0) && transform.localPosition.x > (0 + GlobalVariables.directionError) && transform.localPosition.y < (0 - GlobalVariables.directionError))
					Orientation.z = -1f;
		if (confirmDirection (0) && transform.localPosition.x < (0 - GlobalVariables.directionError) && transform.localPosition.y < (0 - GlobalVariables.directionError))
					Orientation.z = 1f;
	}

	bool shouldThrusterFire (Vector2 tV, float tS) {

		if (GlobalVariables.SameSign (tV.x, Orientation.x))
			return true;
		else if (GlobalVariables.SameSign (tV.y, Orientation.y))
			return true;
		else if (GlobalVariables.SameSign (tS, Orientation.z))
			return true;
		else
			return false;
	}
		
		

}
