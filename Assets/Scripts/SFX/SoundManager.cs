using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    
    public static float soundSlowedSpeed;
    public static float runningSoundSpeed;
    public static bool slowedSound = false;
    
    [SerializeField]
    private float _soundSlowedSpeed = 0.85f;
    [SerializeField]
    private float _runningSoundSpeed = 1.2f;

    public AudioMixerGroup sfxVolMixer;
    public SoundAudioClip[] soundAudioClipArray;
    
    private void Awake()
    {
        if (instance != null) {
            Destroy(this);
        } else {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        soundSlowedSpeed = _soundSlowedSpeed;
        runningSoundSpeed = _runningSoundSpeed;
    }

    public static SoundManager GetSoundManager()
    {
        return instance;
    }
    
    [System.Serializable]
    public class SoundAudioClip
    {
        public Sounds.Sound sound;
        public AudioClip audioClip;
    }
}