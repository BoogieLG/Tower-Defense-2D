using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;

public class AudioSingletone : MonoBehaviour
{

    public static AudioSingletone instance { get; private set; }

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource soundSource;
    [TableList]
    public List<AudioData> audioData;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public void SwitchMusic(string music)
    {
        musicSource.clip = null;
        foreach(var mus in audioData)
        {
            if (mus.names == music) musicSource.clip = mus.audioClip;
        }
        if (musicSource) musicSource.Play();
    }

    public void PlaySound(string sou)
    {
        foreach (var sound in audioData)
        {
            if (sound.names == sou) soundSource.clip = sound.audioClip;
        }
        if (soundSource) soundSource.Play();
    }


}

[Serializable]
public class AudioData
{
    public string names;
    public AudioClip audioClip;
}
