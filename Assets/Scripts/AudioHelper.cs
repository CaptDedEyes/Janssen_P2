using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public static class AudioHelper
//Note that this is a static class, & does not inherit from MonoBehaviour – 
//meaning, this class ‘always exists’ and does not need to be attached to a gameObject.
//This script file can techincally be called from anywherew as long as it exists!
{
    public static AudioSource PlayClip2D
        (AudioClip clip, float volume)
    {
        //create new AudioSource
        GameObject audioObject
            = new GameObject("Audio2D");
        AudioSource audioSource
            = audioObject.AddComponent<AudioSource>();

        //configure to be 2D
        audioSource.clip = clip;
        audioSource.volume = volume;

        //activate it
        audioSource.Play();
        Object.Destroy(audioObject, clip.length);

        //return in case the call wants to do other things
        return audioSource;
    }

}
