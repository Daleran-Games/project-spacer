using UnityEngine;
using System.Collections;
using DalLib.Unity;

namespace ProjectSpacer
{
    public class Frame : MonoBehaviour
    {
        public Controller FrameController;
        public Rigidbody2D FrameRigidbody;

        public ControlSystem FrameControlSystem;

        public delegate void ControllerEvent(Controller cont);
        public ControllerEvent ControllerAssigned;
        public ControllerEvent ControllerUnassigned;

        public delegate void FrameSystemEvent(int priority);
        public FrameSystemEvent InitializeSystem;
        public FrameSystemEvent DeinitializeSystem;

        public void InitializeGrid(Controller cont)
        {


            FrameRigidbody = gameObject.GetOrAddComponent<Rigidbody2D>();
            FrameRigidbody.gravityScale = 0f;
            FrameRigidbody.angularDrag = 0f;
            FrameRigidbody.drag = 0f;
            FrameRigidbody.mass = 0f;


            FrameControlSystem = gameObject.GetOrAddComponent<ControlSystem>();
            FrameControlSystem.InitializeSystemExtension();

            FrameController = cont;
            FrameController.InitializeController();

            ControllerAssigned(FrameController);

        }

    }
}


