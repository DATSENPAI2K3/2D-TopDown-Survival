using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] private AudioSource MusicSource;
    [SerializeField] private AudioSource SfxSource;

    public AudioClip MusicClip;
    public AudioClip GunClip;
    public AudioClip ButtonClip;

    [Range(0f, 1f)]
    [SerializeField] private float gunVolume = 1f;

    [Range(0f, 1f)]
    [SerializeField] private float buttonVolume = 1f;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlayMusic()
    {
        this.MusicSource.Play();
    }
    public void PlaySfx(AudioClip audioClip, float volume)
    {
        this.SfxSource.PlayOneShot(audioClip, volume);
    }
    public void PlayGunSound()
    {
        this.SfxSource.PlayOneShot(this.GunClip, this.gunVolume);
    }
    public void PlayButtonSound()
    {
        this.SfxSource.PlayOneShot(this.ButtonClip, this.buttonVolume);
    }
}
