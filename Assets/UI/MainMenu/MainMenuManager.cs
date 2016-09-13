using UnityEngine;
using System.Collections;

namespace ProjectSpacer
{
    public class MainMenuManager : MonoBehaviour
    {

        public AudioSource MenuMusic;

        // Use this for initialization
        void Start()
        {
            MenuMusic = gameObject.GetRequiredComponent<AudioSource>();
            MenuMusic.volume = Prefs.MasterVolume * Prefs.MusicVolume;
            Prefs.MasterVolumeChange += OnVolumeChange;
            Prefs.MusicVolumeChange += OnVolumeChange;
        }

        void OnDestroy()
        {
            Prefs.MasterVolumeChange -= OnVolumeChange;
            Prefs.MusicVolumeChange -= OnVolumeChange;
        }

        void OnVolumeChange (float f)
        {
            MenuMusic.volume = Prefs.MasterVolume * Prefs.MusicVolume;
        }
    }
}


