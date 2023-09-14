using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundSettings : MonoBehaviour
{
    [SerializeField] Slider soundSlider;
    //[SerializeField] AudioMixer masterMixer;
    SoundManager soundManager;
    // Start is called before the first frame update
    private void Start()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        SetVolume(PlayerPrefs.GetFloat("SavedMasterVolume", 100));

    }

    public void SetVolume(float _value)
    {
        if (_value < 1)
        {
            _value = .001f;
        }

        RefreshSlider(_value);
        PlayerPrefs.SetFloat("SavedMasterVolume", _value);
        //masterMixer.SetFloat("MasterVolume", Mathf.Log10(_value / 100) * 20f);
        
        for (int index = 0; index < soundManager.sounds.Length; index++)
        {
            //soundManager.sounds[index].volume = Mathf.Log10(_value / 100) * 20f;
            soundManager.sounds[index].volume = Mathf.Log10(_value) * 20f;
        }
    }

    public void SetVolumeFromSlider()
    {
        SetVolume(soundSlider.value);
    }

    public void RefreshSlider(float _value)
    {
        soundSlider.value = _value;
    }
}
