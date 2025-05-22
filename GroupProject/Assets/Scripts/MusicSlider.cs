using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSlider : MonoBehaviour
{
    public AudioSource AudioSource;

    private float musicVolume = .25f;
 
    void Start()
    {
       AudioSource.Play();
    }

  
    void Update()
    {
        AudioSource.volume = musicVolume;
    }

    public void updateVolume( float volume)
    {
        musicVolume = volume;
    }
}
