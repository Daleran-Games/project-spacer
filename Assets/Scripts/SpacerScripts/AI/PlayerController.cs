using System;
using UnityEngine;

namespace ProjectSpacer
{


    public class PlayerController : Controller
    {
        [SerializeField]
        Vector2 localVelocity;
        [SerializeField]
        Vector2 translateVector = Vector2.zero;
        [SerializeField]
        Vector2 directionVector = Vector2.zero;

        public override void InitializeControllerExtension()
        {

        }

        void FixedUpdate()
        {

            if (GameManager.inputManager.mouseLook.GetToggleState())
            {
                directionVector = getRotateVector();
            }
            else
            {
                directionVector = getMouseVector().normalized;
            }

            Vector2 inputVector = getTranslateInputVector();

            if (GameManager.inputManager.drift.GetToggleState())
            {
                translateVector = inputVector.normalized;
            }
            else
            {
                localVelocity = transform.InverseTransformDirection(frame.FrameRigidbody.velocity.normalized);
                if (inputVector == Vector2.zero && frame.FrameRigidbody.velocity.magnitude > GV.velocityDeadZone)
                {
                    translateVector =  -localVelocity;
                }
                else
                {
                    if (inputVector.x != 0 & inputVector.y == 0)
                    {
                        translateVector = new Vector2(inputVector.x, -localVelocity.y);
                    }
                    else if (inputVector.x == 0 & inputVector.y != 0)
                    {
                        translateVector = new Vector2(-localVelocity.x, inputVector.y);
                    }
                    else
                    {
                        translateVector = inputVector;
                    }

                }
            }

        }

        Vector2 getTranslateInputVector()
        {
            return new Vector2(GameManager.inputManager.strafe.GetAxisValue(), GameManager.inputManager.accelerate.GetAxisValue());
        }


        Vector2 getMouseVector()
        {
            Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            return MousePos - (Vector2)transform.position;
        }

        Vector2 getRotateVector()
        {
            if (GameManager.inputManager.rotateKeys.GetAxisValue() > 0)
                return Vector2.right;
            else if (GameManager.inputManager.rotateKeys.GetAxisValue() < 0)
                return Vector2.left;
            else
                return Vector2.up;
        }

        public override Vector2 GetTranslateVector()
        {
            return translateVector;
        }

        public override Vector2 GetDirectionVector()
        {
            return directionVector;
        }


    }
}
