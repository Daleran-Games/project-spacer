using UnityEngine;
using System.Collections;


namespace ProjectSpacer
{
    public delegate void DefaultsRestored();

    public class RestoreDefaults : MonoBehaviour
    {

        public static DefaultsRestored DefaultsReset;

        public void SetDefaults()
        {
            Prefs.MasterVolume = 1f;
            Prefs.MusicVolume = 1f;
            Prefs.SFXVolume = 1f;
            if (DefaultsReset != null)
                DefaultsReset();
        }
    }
}

