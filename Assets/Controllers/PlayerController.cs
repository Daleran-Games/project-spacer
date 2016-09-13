using UnityEngine;

namespace ProjectSpacer
{


    public class PlayerController : Controller
    {

        Vector2 _localVelocity;

        Vector2 _translateVector = Vector2.zero;
        Vector2 _directionVector = Vector2.zero;

        void FixedUpdate()
        {

            if (GameManager.inputManager.mouseLook.GetToggleState())
            {
                _directionVector = getRotateVector();
            }
            else
            {
                _directionVector = getMouseVector().normalized;
            }

            Vector2 inputVector = getTranslateInputVector();

            if (GameManager.inputManager.drift.GetToggleState())
            {
                _translateVector = inputVector.normalized;
            }
            else
            {
                _localVelocity = transform.InverseTransformDirection(_grid.GridRigidbody.velocity.normalized);
                if (inputVector == Vector2.zero && _grid.GridRigidbody.velocity.magnitude > GV.velocityDeadZone)
                {
                    _translateVector =  -_localVelocity;
                }
                else
                {
                    if (inputVector.x != 0 & inputVector.y == 0)
                    {
                        _translateVector = new Vector2(inputVector.x, -_localVelocity.y);
                    }
                    else if (inputVector.x == 0 & inputVector.y != 0)
                    {
                        _translateVector = new Vector2(-_localVelocity.x, inputVector.y);
                    }
                    else
                    {
                        _translateVector = inputVector;
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
            return _translateVector;
        }

        public override Vector2 GetDirectionVector()
        {
            return _directionVector;
        }

    }
}
