using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string clipName;
    public AudioClip audioClip;
    public AudioMixerGroup audioMixerGroup;

    [Range(0f, 1f)]
    public float volume = 1;

    [Range(.1f, 3f)]
    public float pitch = 1;

    [Range(0f, 1f)]
    public float sendReverb;


    public bool loop;
    public bool bypassReverb;



    [HideInInspector]
    public AudioSource source;
}
