using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MP3Script : MonoBehaviour
{

    public List<AudioClip> Clips = new List<AudioClip>();
    public TextMeshProUGUI textMesh;
    public static bool isPlaying;
    public Slider volumeSlider;
    public static AudioSource audioSource;

    
    private int currentIndex = 0;
    private bool isStarted;





    private void Start()
    {
        audioSource = AudioManager.Instance.sourceMP3;
        Debug.Log(audioSource.volume);


        AudioManager.Instance.Mixer.ClearFloat("MP3Vol");


    }

    private void Update()
    {
        if (isStarted)
        {
            volumeSlider.gameObject.SetActive(true);
        }
        else
        {
            volumeSlider.gameObject.SetActive(false);
        }
    }

    public void OnValueChanged()
    {
        float volume = volumeSlider.value;
        AudioManager.Instance.Mixer.SetFloat("MP3Vol", Mathf.Log10(volume) * 40);
    }


    public void setAudioSource(AudioSource source)
    {
        audioSource = source;
    }

    public AudioSource getAudioSource()
    {
        return audioSource;
    }
    
    public void Play()
    {
        Debug.Log("Playing " + currentIndex);
        if (Clips.Count == 0)
            return; // list is empty
        currentIndex = currentIndex % Clips.Count; // check that index is not out of bounds
        
        //play sound at index of clips
        audioSource.clip = Clips[currentIndex];
        string displayText = Clips[currentIndex].name + ".mp3";
        textMesh.text = displayText;
        audioSource.Play();
    }

    public void PlayNext()
    {
        AudioManager.Instance.sourceSFX_DONT_MUTE.PlayOneShot(AudioManager.Instance.Click, 0.2f);
        currentIndex++;
        Play();
    }

    public void PlayPrevious()
    {
        AudioManager.Instance.sourceSFX_DONT_MUTE.PlayOneShot(AudioManager.Instance.Click, 0.2f); 
        currentIndex = (currentIndex - 1) % Clips.Count;
        if (currentIndex < 0)
            currentIndex += Clips.Count;
        
        Play();
    }

    public void PauseOrResume()
    {
        AudioManager.Instance.sourceSFX_DONT_MUTE.PlayOneShot(AudioManager.Instance.Click, 0.2f); 
        if (!isStarted)
        {
            //do something if player is not started etc
            isStarted = true;
        }
        if (isPlaying)
        {
            audioSource.Pause();
            isPlaying = false;
        }
        else
        {
            Play();
            isPlaying = true;
        }
        
    }
    
}
