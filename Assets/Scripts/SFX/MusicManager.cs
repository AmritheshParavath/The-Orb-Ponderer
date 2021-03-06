using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public List<AudioClip> music = new List<AudioClip>();

    private AudioSource musicSource;
    private static MusicManager instance = null;
    
    
    void Awake()
    {
        musicSource = this.GetComponent<AudioSource>();
        DontDestroyOnLoad(this);
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        if (SoundManager.slowedSound) {
            musicSource.pitch = SoundManager.soundSlowedSpeed;
        } else {
            musicSource.pitch = 1f; 
        }
    }

    public void SetMusic(int trackNum)
    {
        musicSource.Stop();
        switch(trackNum) {
            case 0: // menu music
                musicSource.clip = music[0];
                break;
            case 1: // in-game music
                musicSource.clip = music[1];
                break;
        }
        musicSource.Play();
    }

    public void PlayMusic(bool value)
    {
        if (value) {
            musicSource.Play();
        } else {
            musicSource.Stop();
        }
    }

    public void ChangeMusicSpeed(float speed)
    {
        musicSource.pitch = speed;
        musicSource.outputAudioMixerGroup.audioMixer.SetFloat("Pitch", 1f / speed);
    }

    public void PauseMusic(bool isPaused)
    {
        if (isPaused)
        {
            musicSource.Pause();
        } else if (!isPaused)
        {
            Debug.Log("g");
            musicSource.UnPause();
        }      
    }
}
