using UnityEngine;
using ProjectSpacer.Database;

namespace ProjectSpacer
{

    public class GameManager : MonoBehaviour
    {

        public Material TextureAtlas;

        public static GameManager gameManager;
        public static InputManager inputManager;
        public static GameDatabase database;


        // Use this for initialization
        void Awake()
        {
            if (gameManager == null)
            {
                gameManager = this;
            }
            else if (gameManager != null)
            {
                Destroy(this);
            }

            GV.atlas = TextureAtlas;
            inputManager = gameObject.GetOrAddComponent<InputManager>();
            database = new GameDatabase();

        }

        void Update()
        {
            if (inputManager.exit.IsPressedOnce())
            {
                Application.Quit();
            }



        }

    }
}
