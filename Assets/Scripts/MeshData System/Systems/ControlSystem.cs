using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControlSystem :  MonoBehaviour {

	public float maxSpeed;
    public Vector2 thrustVector;
    public float torqueScalar;
    public ThrustBlock thrustBlock = new ThrustBlock ();
    public float translateThrottle;

    VectorPID gridSteeringPID = new VectorPID(0.5f, 0.01f, 1.5f);


    //TEMP PUBLIC
    public float steering = 0f;
    public float PID;
    public float aimAngle;

    public GameObject parent;
    public Grid grid;
    public Rigidbody2D GridRigidbody;

    //TEMP PUBLIC
    public Controller controller;

	public virtual void InitializeSystem() {

        parent = gameObject;
        grid = parent.GetRequiredComponent<Grid>();

        GridRigidbody = parent.GetOrAddComponent<Rigidbody2D>();
        GridRigidbody.gravityScale = 0f;
        GridRigidbody.angularDrag = 0f;
        GridRigidbody.drag = 0f;

        UpdateSystem();

		maxSpeed = (thrustBlock.getTotalThrust() / GridRigidbody.mass) * GlobalVariables.maxVelocityTuner;
	}

    void FixedUpdate()
    {
        Move(controller.GetMovementVector(), controller.GetDriectionVector());
    }

    public void AssignController(Controller cont)
    {
        controller = cont;

        if (controller is PlayerController)
        {
            parent.tag = "Player";
        }
    }

    public ThrustBlock GetThrustBlock () {
		return thrustBlock;
	}

    public void UpdateSystem ()
    {
        float newMass = 0f;
        thrustBlock.Clear();

        foreach (KeyValuePair<Vector2Int,Tile> kvp in grid.TileData)
        {
            newMass += kvp.Value.Mass;
            ModifyThrust(kvp.Value.TileOrient, kvp.Key,kvp.Value.Thrust, true);
        }

        GridRigidbody.mass = newMass;
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

	public virtual void ModifyThrust (Orientation orient, Vector2Int pos, float amount, bool add) {

        Vector2 localPos = new Vector2(pos.x - grid.GridCenter.x + GlobalVariables.halfTileSize, pos.y - grid.GridCenter.y + GlobalVariables.halfTileSize);

        if (add == false)
			amount = amount * -1f;

        switch (orient)
        {
            case Orientation.NORTH:

                thrustBlock.down -= amount;
                

                if (localPos.x > 0)
                    thrustBlock.cw -= amount;
                else if (localPos.x < 0)
                    thrustBlock.ccw += amount;

                break;
            case Orientation.SOUTH:

                thrustBlock.up += amount;

                if (localPos.x > 0)
                    thrustBlock.ccw += amount;
                else if (localPos.x < 0)
                    thrustBlock.cw -= amount;

                break;
            case Orientation.EAST:

                thrustBlock.left -= amount;

                if (localPos.y > 0)
                    thrustBlock.ccw += amount;
                else if (localPos.y < 0)
                    thrustBlock.cw -= amount;

                break;
            case Orientation.WEST:

                thrustBlock.right += amount;
                
                if (localPos.y > 0)
                    thrustBlock.cw -= amount;
                else if (localPos.y < 0)
                    thrustBlock.ccw += amount;

                break;
            case Orientation.FLIPPED_V:

                thrustBlock.up += amount;

                if (localPos.x > 0)
                    thrustBlock.ccw += amount;
                else if (localPos.x < 0)
                    thrustBlock.cw -= amount;

                break;
            case Orientation.FLIPPED_H:
                
                thrustBlock.down -= amount;

                if (localPos.x > 0)
                    thrustBlock.cw -= amount;
                else if (localPos.x < 0)
                    thrustBlock.ccw += amount;

                break;
            default:
                Debug.LogError("PS ERROR: " + orient.ToString() + " not a valid orientation for thrust direction");
                break;
        }


		
	}

    public virtual void Move(Vector2 movmentVector, Vector2 direction)
    {
        Rotate(direction);
        thrustVector = setThrustVector(movmentVector);
        GridRigidbody.AddRelativeForce(thrustVector);
    }

    public virtual void Rotate(Vector2 direction)
    {


        if (direction != Vector2.zero)
        {
            aimAngle = Vector2.Angle(GridRigidbody.transform.up, direction) / 180f;

            if (Vector3.Cross(GridRigidbody.transform.up, direction).z > 0)
                aimAngle = aimAngle * -1f;

            PID = gridSteeringPID.Update(aimAngle, Time.fixedDeltaTime);

            if (aimAngle > 0)
                steering = thrustBlock.ccw;
            else if (aimAngle < 0)
                steering = -thrustBlock.cw;

            if (PID < GlobalVariables.headingDeadZone && PID > -GlobalVariables.headingDeadZone)
                steering = 0f;


            torqueScalar = PID * steering * GlobalVariables.torqueFactor;
            GridRigidbody.AddTorque(-torqueScalar);
        }

    }

    Vector2 setThrustVector(Vector2 dir)
    {

        translateThrottle = dir.magnitude;
        thrustVector = Vector2.zero;
        float slope = dir.y / dir.x;

        if (dir.x == 0f && dir.y == 0f)
        {
            return thrustVector * dir.magnitude;
        }
        else if (dir.x != 0f && dir.y == 0f)
        {
            if (dir.x > 0f)
            {
                thrustVector.x = thrustBlock.right;
                return thrustVector * dir.magnitude;
            }
            else
            {
                thrustVector.x = thrustBlock.left;
                return thrustVector * dir.magnitude;
            }
        }
        else if (dir.x == 0f && dir.y != 0f)
        {
            if (dir.y > 0f)
            {
                thrustVector.y = thrustBlock.up;
                return thrustVector * dir.magnitude;
            }
            else
            {
                thrustVector.y = thrustBlock.down;
                return thrustVector * dir.magnitude;
            }
        }
        else if (dir.x > 0f)
        {
            float fr = slope * thrustBlock.right;
            if (slope > (thrustBlock.up / thrustBlock.right))
            {
                return new Vector2(dir.x / dir.y * thrustBlock.up, thrustBlock.up) * dir.magnitude;
            }
            else if (slope == (thrustBlock.up / thrustBlock.right))
            {
                return new Vector2(thrustBlock.right, thrustBlock.up) * dir.magnitude;
            }
            else if (slope < (thrustBlock.up / thrustBlock.right) && slope > (thrustBlock.down / thrustBlock.right))
            {
                return new Vector2(thrustBlock.right, fr) * dir.magnitude;
            }
            else if (slope == (thrustBlock.down / thrustBlock.right))
            {
                return new Vector2(thrustBlock.right, thrustBlock.down) * dir.magnitude;
            }
            else if (slope < (thrustBlock.down / thrustBlock.right))
            {
                return new Vector2(dir.x / dir.y * thrustBlock.down, thrustBlock.down) * dir.magnitude;
            }
        }
        else
        {
            float fl = slope * thrustBlock.left;
            if (slope < (thrustBlock.up / thrustBlock.left))
            {
                return new Vector2(dir.x / dir.y * thrustBlock.up, thrustBlock.up) * dir.magnitude;
            }
            else if (slope == (thrustBlock.up / thrustBlock.left))
            {
                return new Vector2(thrustBlock.left, thrustBlock.up) * dir.magnitude;
            }
            else if (slope > (thrustBlock.up / thrustBlock.left) && slope < (thrustBlock.down / thrustBlock.left))
            {
                return new Vector2(thrustBlock.left, fl) * dir.magnitude;
            }
            else if (slope == (thrustBlock.down / thrustBlock.left))
            {
                return new Vector2(thrustBlock.left, thrustBlock.down) * dir.magnitude;
            }
            else if (slope > (thrustBlock.down / thrustBlock.left))
            {
                return new Vector2(dir.x / dir.y * thrustBlock.down, thrustBlock.down) * dir.magnitude;
            }

        }

        Debug.Log("Thrust Block Error: getThrustVector");
        return thrustVector;
    }



}
