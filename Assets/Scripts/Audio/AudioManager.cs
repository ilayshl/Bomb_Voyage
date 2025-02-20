using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] generalSounds;
    public Sound[] hammer;
    public Sound[] cableCutting;
    public Sound[] numberTyping;

    public static AudioManager instance;
    

    void Awake()
    {
        //if (instance == null)
        //    instance = this;
        //else
        //{
        //    Destroy(gameObject);
        //    return;
        //}
        //DontDestroyOnLoad(gameObject);

        foreach (Sound s in generalSounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.audioClip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.audioMixerGroup;
        }

        foreach (Sound s in hammer)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.audioClip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.audioMixerGroup;
        }


        foreach (Sound s in cableCutting)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.audioClip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.audioMixerGroup;
        }
        
        foreach (Sound s in numberTyping)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.audioClip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.audioMixerGroup;
        }

    }

    public void PlaySound(string soundName)
    {
        Sound s = Array.Find(generalSounds, sound => sound.clipName == soundName);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + soundName + " not found");
            return;
        }
        s.source.Play();
    }

    public void PlayKeyNumber(int numKey)
    {
        if (numKey < 0 || numKey >= numberTyping.Length)
        {
            Debug.LogWarning($"index out of array bounds");
        }

        Sound s = numberTyping[numKey];

        if (s == null)
        {
            Debug.LogWarning("Sound: " + numKey + " not found");
            return;
        }
        s.source.Play();
    }

    public void PlayRandomHammer()
    {
        if (hammer.Length == 0)
        {
            Debug.LogWarning("No generalSounds available!");
            return;
        }

        int randomSound = UnityEngine.Random.Range(0, hammer.Length);
        Sound s = hammer[randomSound];

        if (s != null)
        {
            s.source.Play();
        }
    }

    public void PlayRandomCable()
    {
        if (cableCutting.Length == 0)
        {
            Debug.LogWarning("No generalSounds available!");
            return;
        }

        int randomSound = UnityEngine.Random.Range(0, cableCutting.Length);
        Sound s = cableCutting[randomSound];

        if (s != null)
        {
            s.source.Play();
        }
    }



    public void StopSound(string soundName)
    {
        Sound s = Array.Find(generalSounds, sound => sound.clipName == soundName);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + soundName + " not found");
            return;
        }
        s.source.Stop();
    }

}
