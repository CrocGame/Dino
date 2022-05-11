using UnityEngine;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _audioMixer;


    public void MusicVolume(float value)
    {
        _audioMixer.audioMixer.SetFloat("MusicVolume",Mathf.Lerp(-80,0,value));
    }
    public void EffectsVolume(float value)
    {
        _audioMixer.audioMixer.SetFloat("EffectsVolume", Mathf.Lerp(-80, 0, value));
    }



}
