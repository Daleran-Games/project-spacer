using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ProjectSpacer;

namespace ProjectSpacer
{

    public class InputManager : MonoBehaviour
    {

        public ControlAxis strafe = new ControlAxis("Strafe");
        public ControlAxis accelerate = new ControlAxis("Accelerate");
        public ControlAxis rotateKeys = new ControlAxis("Rotate");
        public ToggleKey drift = new ToggleKey("Drift", false);
        public ControlAxis fire = new ControlAxis("Fire0");
        public ToggleKey mouseLook = new ToggleKey("MouseSteer", false);
        public ControlAxis mouseWheel = new ControlAxis("Zoom");
        public EventKey layerUp = new EventKey("LayerUp");
        public EventKey layerDown = new EventKey("LayerDown");
        public EventKey exit = new EventKey("Exit");
        public ToggleKey help = new ToggleKey("Help", true);

        
        // Use this for initialization
        void Update()
        {

        }

        // Use this for initialization
        void FixedUpdate()
        {
            drift.SetToggleState();
            mouseLook.SetToggleState();
            help.SetToggleState();
        }

        // Use this for initialization
        void LateUpdate()
        {

        }

        public interface IControl
        {
            string GetAxisName();
            string GetAxisHelpEntry();
        }

        public class ToggleKey 
        {
            bool isAxisInUse = false;
            bool keyState = false;
            string axis;

            public ToggleKey(string axisName, bool startingState)
            {
                axis = axisName;
                keyState = startingState;
            }

            public string GetAxisName()
            {
                return axis;
            }

            public bool GetToggleState ()
            {
                return keyState;
            }

            public void SetToggleState()
            {
                if (Input.GetAxisRaw(axis) != 0)
                {
                    if (isAxisInUse == false)
                    {
                        if (keyState == false)
                            keyState = true;
                        else
                            keyState = false;

                        isAxisInUse = true;
                    }
                }
                if (Input.GetAxisRaw(axis) == 0)
                {
                    isAxisInUse = false;
                }
            }

        }

        public class EventKey
        {
            string axis;
            bool alreadyPressed = false;

            public EventKey(string axisName)
            {
                axis = axisName;
            }

            public string GetAxisName()
            {
                return axis;
            }

            public bool IsPressed ()
            {
                if (Input.GetAxisRaw(axis) != 0f)
                    return true;
                else
                    return false;
            }

            public bool IsPressedOnce()
            {
                if (Input.GetAxisRaw(axis) != 0f && alreadyPressed == false)
                {
                    alreadyPressed = true;
                    return true;
                }
                else if (Input.GetAxisRaw(axis) != 0f && alreadyPressed == true)
                {
                    return false;
                }
                else if (Input.GetAxisRaw(axis) == 0f && alreadyPressed == true)
                {
                    alreadyPressed = false;
                    return false;
                }
                else
                    return false;
                    
            }
        }

        public class ControlAxis
        {
            string axis;

            public ControlAxis(string axisName)
            {
                axis = axisName;
            }

            public string GetAxisName ()
            {
                return axis;
            }

            public float GetAxisValue ()
            {
                return Input.GetAxis(axis);
            }

            public bool IsAxisInUse()
            {
                if (Input.GetAxis(axis) != 0)
                    return true;
                else
                    return false;
            }

            public bool IsPositiveAndInUse ()
            {
                if (Input.GetAxis(axis) > 0 && IsAxisInUse())
                    return true;
                else
                    return false;
            }

        }

    }
}