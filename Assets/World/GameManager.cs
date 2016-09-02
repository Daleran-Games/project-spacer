using UnityEngine;

namespace ProjectSpacer
{

    public class GameManager : MonoBehaviour
    {

        public Material TextureAtlas;

        public static GameManager gameManager;
        public static InputManager inputManger;
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
            inputManger = gameObject.GetOrAddComponent<InputManager>();
            database = gameObject.GetOrAddComponent<GameDatabase>();

        }

        void Update()
        {
            if (inputManger.exit.IsPressedOnce())
            {
                Application.Quit();
            }



        }

    }
}
