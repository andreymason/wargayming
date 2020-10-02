using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioManager
{
    static AudioSource audioSource;
    static Dictionary<AudioClipName, AudioClip> audioClips =
        new Dictionary<AudioClipName, AudioClip>();

    public static void Initialize(AudioSource source)
    {
        audioSource = source;
        audioClips.Add(AudioClipName.background_music, 
            Resources.Load<AudioClip>("background_menu"));
        audioClips.Add(AudioClipName.chip, 
            Resources.Load<AudioClip>("chip"));
    }

    public static void Play(AudioClipName name)
    {
        audioSource.PlayOneShot(audioClips[name]);
    }

    /* can play only one looped track at a once */
    public static void PlayLooped(AudioClipName name)
    {
        audioSource.clip = audioClips[name];
        audioSource.loop = true;
        audioSource.Play(0);
    }

    // in current implementetion stops all clips
    public static void StopPlying(){
        audioSource.Stop();
    }
    
};
