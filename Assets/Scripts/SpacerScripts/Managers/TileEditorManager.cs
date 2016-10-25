using UnityEngine;
using System.Collections;
using DalLib.Unity;


namespace ProjectSpacer
{
    public class TileEditorManager : MonoBehaviour
    {

        public AudioSource EditorMusic;
        public GameObject MenuObject;
        public GameObject OptionsMenu;
        public GameObject Interface;
        public static InputManager inputManager;

        void Start()
        {
            EditorMusic = gameObject.GetRequiredComponent<AudioSource>();
            EditorMusic.volume = Prefs.MasterVolume * Prefs.MusicVolume;
            Prefs.MasterVolumeChange += OnVolumeChange;
            Prefs.MusicVolumeChange += OnVolumeChange;
            inputManager = gameObject.GetOrAddComponent<InputManager>();
        }

        void Update()
        {
            if (inputManager.exit.IsPressedOnce())
            {
                if (MenuObject.activeInHierarchy)
                {
                    MenuObject.SetActive(false);
                }
                else if (OptionsMenu.activeInHierarchy)
                {
                    MenuObject.SetActive(true);
                    OptionsMenu.SetActive(false);
                }
                else
                {
                    MenuObject.SetActive(true);
                }
            }
        }

        void OnDestroy()
        {
            Prefs.MasterVolumeChange -= OnVolumeChange;
            Prefs.MusicVolumeChange -= OnVolumeChange;
        }

        void OnVolumeChange(float f)
        {
            EditorMusic.volume = Prefs.MasterVolume * Prefs.MusicVolume;
        }
    }
}

