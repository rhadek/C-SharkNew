using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class SoundManager : MonoBehaviour
{
    public Slider systemvolumeslider;
    public AudioMixer systemsoundmixer;
    public Slider musicvolumeslider;
    public AudioMixer musicsoundmixer;
    private float values;
    private float valuem;

    void Start()
    {
        systemsoundmixer.GetFloat("systemvolume1", out values);
        musicsoundmixer.GetFloat("musicsoundvolume1", out valuem);
        systemvolumeslider.value = values;
        musicvolumeslider.value = valuem;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetVolume()
    {
        systemsoundmixer.SetFloat("systemvolume1", systemvolumeslider.value);
        musicsoundmixer.SetFloat("musicsoundvolume1", musicvolumeslider.value);
    }
}
