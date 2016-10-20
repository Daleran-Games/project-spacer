using UnityEngine;

namespace ProjectSpacer
{

    public class UIManager : MonoBehaviour
    {

        HelpPanel playerControls;
        public Texture2D cursor;
        public Texture2D crossHair;
        public CursorMode cursorMode = CursorMode.Auto;

        // Use this for initialization
        void Start()
        {
            playerControls = GetComponentInChildren<HelpPanel>();
        }

        void Update()
        {
            if (GameManager.inputManager.help.GetToggleState())
            {
                playerControls.gameObject.SetActive(true);
            }
            else
            {
                playerControls.gameObject.SetActive(false);
            }

            if (GameManager.inputManager.mouseLook.GetToggleState())
            {
                Cursor.SetCursor(cursor, Vector2.zero, cursorMode);
            }
            else
            {
                Cursor.SetCursor(crossHair, Vector2.zero, cursorMode);
            }


        }

    }
}
