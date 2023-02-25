
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public static AudioManager Instance { get { return instance; } }
    [SerializeField]
    private Sounds[] sounds;
    [SerializeField]
    private AudioSource audioBg;
    public AudioSource audioSfx;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
        PlayBackgroundMusic();
    }

    private void PlayBackgroundMusic()
    {
        Sounds sound = Array.Find(sounds, s => s.soundType == SoundType.BakgroundMusic);
        if (sound == null)
            return;
        audioBg.clip = sound.audioClip;
        audioBg.loop = sound.loop;
        audioBg.Play();
    }

    public void PlaySfxMusic(SoundType soundType)
    {
        Sounds sound = Array.Find(sounds, s => s.soundType == soundType);
        if (sound == null)
            return;
        audioSfx.clip = sound.audioClip;
        audioSfx.loop = sound.loop;
        audioSfx.Play();
    }
}
