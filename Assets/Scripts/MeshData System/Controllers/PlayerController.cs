﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class PlayerController : Controller {


    public bool drift;
	public bool mouseLook;
	public bool isAxisInUse = false;


	void Update () {
		
		float fire = Input.GetAxis ("Fire");

		if (fire > 0) {
			isFiring = true;
		} else
			isFiring = false;


	}

	void FixedUpdate ()	{
		
		setDriftState ();
		setMouseLookState ();
		aimPoint = getMouseVector ();

		if (mouseLook == true) {
			directionVector = getRotateVector ();
		} else {
			directionVector = aimPoint.normalized;
		}

		Vector2 inputVector = getTranslateInputVector ();

		if (drift == true) {
			movementVector = inputVector.normalized;
		} else {
			localVelocity = transform.InverseTransformDirection (rb.velocity).normalized;
			if (inputVector == Vector2.zero && rb.velocity.magnitude > GlobalVariables.velocityDeadZone) {
				movementVector = -localVelocity;
			} else {
				if (inputVector.x != 0 & inputVector.y == 0) {
					movementVector = new Vector2 (inputVector.x,-localVelocity.y).normalized;
				} else if (inputVector.x == 0 & inputVector.y != 0) {
					movementVector = new Vector2 (-localVelocity.x,inputVector.y).normalized;
				} else {
					movementVector = inputVector.normalized;
				}
					
			}
		}

	}

	Vector2 getTranslateInputVector () {
		return new Vector2 (Input.GetAxis ("Horizontal"),Input.GetAxis ("Vertical"));
	}
		

	Vector2 getMouseVector () {
		Vector2 MousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		return MousePos - (Vector2)transform.position;
			
	}

	Vector2 getRotateVector () {
		float rotate = Input.GetAxis ("Rotate");

		float angle;
		if (rotate > 0)
			angle = -GlobalVariables.playerRotateRadian;
		else if (rotate < 0)
			angle = GlobalVariables.playerRotateRadian;
		else
			angle = 0f;

		return new Vector2 (directionVector.x * Mathf.Cos(angle) - directionVector.y * Mathf.Sin(angle), directionVector.y * Mathf.Cos(angle) + directionVector.x * Mathf.Sin(angle));
	}

	void setDriftState () {
		float d = Input.GetAxis ("Drift");

		if (d > 0)
			drift = true;
		else
			drift = false;
	}

	void setMouseLookState () {

		if (Input.GetAxisRaw ("Toggle Mouse") != 0) {
			if (isAxisInUse == false) {

				if (mouseLook == false)
					mouseLook = true;
				else {
					mouseLook = false;
					directionVector = aimPoint.normalized;
				}

				isAxisInUse = true;
			}
		}
		if (Input.GetAxisRaw ("Toggle Mouse") == 0) {
			isAxisInUse = false;
		}
	}




}