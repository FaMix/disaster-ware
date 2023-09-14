using UnityEngine;
using UnityEngine.Audio;

 [System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [Range(0f,100f)]
    public float volume;
    [Range(.1f, 100f)]
    public float pitch;
    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
