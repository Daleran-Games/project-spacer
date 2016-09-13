using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace ProjectSpacer
{
    public class AudioOptions : MonoBehaviour
    {

        public Slider MasterVolume;
        public Slider SFXVolume;
        public Slider MusicVolume;

        public Text MasterVolLabel;
        public Text SFXVolLabel;
        public Text MusicVolLabel;

        // Use this for initialization
        void Start()
        {
            MasterVolume.value = Prefs.MasterVolume;
            MasterVolLabel.text = (MasterVolume.value * 100f).ToString();
            SFXVolume.value = Prefs.SFXVolume;
            SFXVolLabel.text = (SFXVolume.value * 100f).ToString();
            MusicVolume.value = Prefs.MusicVolume;
            MusicVolLabel.text = (MusicVolume.value * 100f).ToString();

            RestoreDefaults.DefaultsReset += OnVolumeSettingUpdate;


        }

        void OnDestroy()
        {
            RestoreDefaults.DefaultsReset -= OnVolumeSettingUpdate;
        }

        void OnVolumeSettingUpdate ()
        {
            MasterVolume.value = Prefs.MasterVolume;
            MasterVolLabel.text = (MasterVolume.value * 100f).ToString();
            SFXVolume.value = Prefs.SFXVolume;
            SFXVolLabel.text = (SFXVolume.value * 100f).ToString();
            MusicVolume.value = Prefs.MusicVolume;
            MusicVolLabel.text = (MusicVolume.value * 100f).ToString();
        }

        public void SetMasterVolume(float f)
        {
            Prefs.MasterVolume = f;
            MasterVolume.value = f;
            MasterVolLabel.text = (f * 100f).ToString();
        }

        public void SetSFXVolume(float f)
        {
            Prefs.SFXVolume = f;
            SFXVolume.value = f;
            SFXVolLabel.text = (f * 100f).ToString();
        }

        public void SetMusicVolume(float f)
        {
            Prefs.MusicVolume = f;
            MusicVolume.value = f;
            MusicVolLabel.text = (f * 100f).ToString();
        }

    }
}
