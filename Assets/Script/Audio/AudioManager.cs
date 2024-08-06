using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    // 0 - Stage BGM / 1 - Boss BGM
    [SerializeField] private AudioSO[] music, sfx;

    [SerializeField] private AudioSource musicSource, sfxSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic(music[0].audioName);
    }

    public void PlayMusic(string _name)
    {
        AudioSO audioSO = Array.Find(music, x => x.audioName == _name);

        if (audioSO == null)
        {
            Debug.Log("Music Not Found");
        }
        else
        {
            // Stop the current clip if it's playing
            if (musicSource.isPlaying)
            {
                musicSource.Stop();
            }

            musicSource.clip = audioSO.audioClip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string _name)
    {
        AudioSO audioSO = Array.Find(sfx, x => x.audioName == _name);

        if (audioSO == null)
        {
            Debug.Log("SFX Not Found");
        }
        else
        {
            sfxSource.PlayOneShot(audioSO.audioClip);
        }
    }

    public void EnableMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void EnableSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }

    public void VolumeAdjustMusic(float _volume)
    {
        Debug.Log("Music~");
        musicSource.volume = _volume;
    }
    public void VolumeAdjustSFX(float _volume)
    {
        sfxSource.volume = _volume;
    }
}
