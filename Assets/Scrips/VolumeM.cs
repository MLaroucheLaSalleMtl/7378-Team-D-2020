using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VolumeM : MonoBehaviour
{
    [SerializeField] private AudioMixer audio;         //
    [SerializeField] private string name;   // name of the exposed pitch

    public void volume(float vol)
    {
        Slider slide = GetComponent<Slider>();
        audio.SetFloat(name, vol);
        slide.value = vol;
        PlayerPrefs.SetFloat(name, vol);
        PlayerPrefs.Save();
    }
    void Start()
    {
        Slider slide = GetComponent<Slider>();
        float v = PlayerPrefs.GetFloat(name, 0);
        slide.value = v;
    }

   
}
