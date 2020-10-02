using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioInitializer : MonoBehaviour
{
	void Awake()
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        AudioManager.Initialize(audioSource);
    }
}

