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

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetGeneralVolume()
    {
        // Si no existe, guarda un valor predeterminado
        if (!dataPersistence.HasKey("MasterVolume"))
        {
            SetGeneralVolume(DefaultGeneralVolume);
        }

        // Obtiene el valor guardado
        generalSlider.value = dataPersistence.GetFloat("MasterVolume");
    }

    // Obtiene la opcion MusicVolume
    public void GetMusicVolume()
    {
        // Si no existe, guarda un valor predeterminado
        if (!dataPersistence.HasKey("MusicVolume"))
        {
            SetMusicVolume(DefaultMusicVolume);
        }

        // Obtiene el valor guardado
        musicSlider.value = dataPersistence.GetFloat("MusicVolume");
    }

    // Obtiene la opcion EffectsVolume
    public void GetEffectsVolume()
    {
        // Si no existe, guarda un valor predeterminado
        if (!dataPersistence.HasKey("SFXVolume"))
        {
            SetEffectsVolume(DefaultEffectsVolume);
        }

        // Obtiene el valor guardado
        soundfxSlider.value = dataPersistence.GetFloat("SFXVolume");
    }
    public void SetGeneralVolume(float volume)
    {
        // Cambia el volumen en el AudioMixer
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);

        // Guarda la opcion
        dataPersistence.SetFloat("MasterVolume", volume);
    }

    // Setea la opcion MusicVolume
    public void SetMusicVolume(float volume)
    {
        // Cambia el volumen en el AudioMixer
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);

        // Guarda la opcion
        dataPersistence.SetFloat("MusicVolume", volume);
    }

    // Setea la opcion EffectsVolume
    public void SetEffectsVolume(float volume)
    {
        // Cambia el volumen en el AudioMixer
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);

        // Guarda la opcion
        dataPersistence.SetFloat("SFXVolume", volume);
    }
}
