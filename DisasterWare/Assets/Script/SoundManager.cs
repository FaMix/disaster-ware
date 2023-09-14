using UnityEngine;
using UnityEngine.Audio;
using System;
using Unity.VisualScripting;

public class SoundManager : MonoBehaviour
{
    public Sound[] sounds;

    public static SoundManager instance;

    void Awake()
    {
        PlayerPrefs.GetFloat("SavedMasterVolume", 100);
        if (instance == null) 
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume/100;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Play("BackgroundMusic");
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();

    }

    // Update is called once per frame
    void Update()
    {
        AudioSource[] audioSources = gameObject.GetComponents<AudioSource>();

        foreach (Sound s in sounds)
        {
            foreach (AudioSource audioSource in audioSources)
            {
                if (audioSource.clip == s.clip)
                {
                    audioSource.volume = s.volume/100;
                    //Debug.Log("Volume set to " + s.volume + " for clip " + s.clip.name);
                }
                else
                {
                    //Debug.Log("No match found for clip " + s.clip.name + " in AudioSource " + audioSource.name);
                }
            } 
        }
    }
}
