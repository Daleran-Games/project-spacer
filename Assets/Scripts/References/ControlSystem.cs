using UnityEngine;
using System.Collections;

public abstract class ControlSystem :  MonoBehaviour, IInitialize {

	protected float maxSpeed;
	protected Vector2 thrustVector;
	protected float torqueScalar;
	protected ThrustBlock thrustBlock = new ThrustBlock (0f, 0f, 0f, 0f, 0f, 0f);
	protected float translateThrottle;

	//TEMP PUBLIC
	public Controller controller;
	public Rigidbody2D rb;

	public virtual void Initialize() {
		rb = GetComponent<Rigidbody2D> ();
		controller = GetComponent<Controller> ();
		maxSpeed = (thrustBlock.getTotalThrust() / rb.mass) * GlobalVariables.maxVelocityTuner;
	}
		
	public ThrustBlock GetThrustBlock () {
		return thrustBlock;
	}

	public virtual float GetMaxSpeed (){
		return maxSpeed;
	}

	public virtual Vector2 GetThrustVector () {
		return thrustVector;
	}

	public virtual float GetTorqueScalar() {
		return torqueScalar;
	}

	public virtual float GetTranslationFractional () {
		return translateThrottle;
	}

	public virtual float GetTorqueFractional () {
		if (torqueScalar > 0f)
			return torqueScalar / thrustBlock.ccw;
		else if (torqueScalar < 0f)
			return torqueScalar / thrustBlock.cw;
		else
			return 0f;
	}

	public virtual void ModifyThrust (Vector3 orientation, float amount, bool add) {

		if (add == false)
			amount = amount * -1f;

		//Add thrust in the y direction
		if (orientation.y > 0)
			thrustBlock.up += amount;
		else if (orientation.y < 0)
			thrustBlock.down -= amount;

		//Add thrust in the x direction
		if (orientation.x > 0)
			thrustBlock.right += amount;
		else if (orientation.x < 0)
			thrustBlock.left -= amount;

		//Add thrust in the z direction
		if (orientation.z > 0)
			thrustBlock.ccw += amount;
		else if (orientation.z < 0)
			thrustBlock.cw -= amount;
	}

	protected abstract void Move (Vector2 movmentVector, Vector2 direction);
	protected abstract void Rotate (Vector2 direction);



}
