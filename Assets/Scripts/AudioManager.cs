using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource source;
    public AudioSource sourceGlobal;
    public AudioSource sourceBackrooms;
    public AudioClip fashion;
    public AudioClip standardBackgroundMusicClip;
    public AudioClip zipper;
    public AudioClip eatApple;
    public AudioClip collectItem;
    public AudioClip lockedDoor;
    public AudioClip unlockDoor;
    public AudioClip cameraFlash;
    public AudioClip barcodeScanner;
    public AudioClip usbConnected;
    public AudioClip cashRegister;
    public AudioClip backRoomEntrance;
    public AudioClip crowded;
    public AudioClip gibberish1;
    public AudioClip gibberish2;
    public AudioClip gibberish3;
    public AudioClip examTheme;
    public AudioClip endingDead;
    public AudioClip wrongChoice;
    public AudioClip rightChoice;
    public AudioClip endingPassed;
    public AudioClip Click;
    public AudioMixer Mixer;



    public float _Volume = 1f;

    private void Awake()
    {
        // create singleton
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        float vol;
        Mixer.GetFloat("MainVol", out vol);
        Manager.Instance.VolumeSlider.value = vol;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
