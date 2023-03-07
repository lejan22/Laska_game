using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    [Header("DATE PERSISTENCE")]
    private DataPersistance dataPersistence;

    [Header("AUDIO SETTINGS")]
    public Slider generalSlider;
    public Slider musicSlider;
    public Slider soundfxSlider;

    [Header("AUDIO MIXER")]
    public AudioMixer audioMixer;

    [Header("DEFAULT AUDIO SETTINGS")]
    private float DefaultGeneralVolume = 1f;
    private float DefaultMusicVolume = 0.75f;
    private float DefaultEffectsVolume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        dataPersistence = FindObjectOfType<DataPersistance>();

        GetMusicVolume();
        GetGeneralVolume();
        GetEffectsVolume();
    }

    //
    public void GetGeneralVolume()
    {
        // if it doesn't,saves predetermined value
        if (!dataPersistence.HasKey("MasterVolume"))
        {
            SetGeneralVolume(DefaultGeneralVolume);
        }

        // Gets the saved value
        generalSlider.value = dataPersistence.GetFloat("MasterVolume");
    }

    // Gets the option MusicVolume
    public void GetMusicVolume()
    {
        // if it doesn't,saves predetermined value
        if (!dataPersistence.HasKey("MusicVolume"))
        {
            SetMusicVolume(DefaultMusicVolume);
        }

        // Gets the saved option
        musicSlider.value = dataPersistence.GetFloat("MusicVolume");
    }

    // Gets option EffectsVolume
    public void GetEffectsVolume()
    {
        // if it doesn't,saves predetermined value
        if (!dataPersistence.HasKey("SFXVolume"))
        {
            SetEffectsVolume(DefaultEffectsVolume);
        }

        // Gets the saved option
        soundfxSlider.value = dataPersistence.GetFloat("SFXVolume");
    }
    public void SetGeneralVolume(float volume)
    {
        // Changes volume in AudioMixer
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);

        // Saves option
        dataPersistence.SetFloat("MasterVolume", volume);
    }

    // Setea la opcion MusicVolume
    public void SetMusicVolume(float volume)
    {
        // Changes volume in AudioMixer
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);

        // Saves option
        dataPersistence.SetFloat("MusicVolume", volume);
    }

    // Setea la opcion EffectsVolume
    public void SetEffectsVolume(float volume)
    {
        // Changes volume in AudioMixer
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);

        // Saves option
        dataPersistence.SetFloat("SFXVolume", volume);
    }
}
