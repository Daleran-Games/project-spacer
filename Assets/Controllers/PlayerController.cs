using UnityEngine;

namespace ProjectSpacer
{


    public class PlayerController : Controller
    {

        Vector2 localVelocity;

        public bool isMouseWheelAxisInUse = false;

        void Update()
        {


        }

        void FixedUpdate()
        {


            aimPoint = getMouseVector();

            if (GameManager.inputManger.mouseLook.GetToggleState())
            {
                directionVector = getRotateVector();
            }
            else
            {
                directionVector = aimPoint.normalized;
            }

            Vector2 inputVector = getTranslateInputVector();

            if (GameManager.inputManger.drift.GetToggleState())
            {
                movementVector = inputVector.normalized;
            }
            else
            {
                localVelocity = transform.InverseTransformDirection(gridRigidBody.velocity).normalized;
                if (inputVector == Vector2.zero && gridRigidBody.velocity.magnitude > GV.velocityDeadZone)
                {
                    movementVector = -localVelocity;
                }
                else
                {
                    if (inputVector.x != 0 & inputVector.y == 0)
                    {
                        movementVector = new Vector2(inputVector.x, -localVelocity.y).normalized;
                    }
                    else if (inputVector.x == 0 & inputVector.y != 0)
                    {
                        movementVector = new Vector2(-localVelocity.x, inputVector.y).normalized;
                    }
                    else
                    {
                        movementVector = inputVector.normalized;
                    }

                }
            }

        }

        Vector2 getTranslateInputVector()
        {
            return new Vector2(GameManager.inputManger.strafe.GetAxisValue(), GameManager.inputManger.accelerate.GetAxisValue());
        }


        Vector2 getMouseVector()
        {
            Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            return MousePos - (Vector2)transform.position;

        }

        Vector2 getRotateVector()
        {

            float angle;
            if (GameManager.inputManger.rotateKeys.GetAxisValue() > 0)
                angle = -GV.playerRotateRadian;
            else if (GameManager.inputManger.rotateKeys.GetAxisValue() < 0)
                angle = GV.playerRotateRadian;
            else
                angle = 0f;

            return new Vector2(directionVector.x * Mathf.Cos(angle) - directionVector.y * Mathf.Sin(angle), directionVector.y * Mathf.Cos(angle) + directionVector.x * Mathf.Sin(angle));
        }


    }
}
