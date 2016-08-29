using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

    PlayerController player;
    CameraController playerCamera;
    
    
    // Use this for initialization
	void Awake () {
	
	}
	
	void Start ()
    {

    }
    
    // Update is called once per frame
	void Update () {
	
	}

    void LateUpdate ()
    {

    }

    void InitializeControls()
    {
        
        

    }

    public class ToggleButton
    {
        bool isAxisInUse = false;
        bool buttonState = false;
        string axis;

        public ToggleButton(string axisName)
        {
            axis = axisName;
        }

    }

    public class ButtonPress
    {
        float axisValue;
        string axis;

        public ButtonPress(string axisName)
        {
            axis = axisName;
        }
    }

    public class ControlAxis
    {
        float axisValue;
        string axis;

        public ControlAxis(string axisName)
        {
            axis = axisName;
        }
           
    }

    public class ControlModifier
    {
        bool isModified;
        string axis;

        public ControlModifier (string axisName)
        {
            axis = axisName;
        }
    }
}
