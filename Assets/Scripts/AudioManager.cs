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
    public AudioSource sourceSamwel;
    public AudioSource sourceBackrooms;
    public AudioSource sourceMP3;
    public AudioSource sourceSFX_DONT_MUTE;
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
    public AudioClip DragonRoar;
    public AudioClip StabStab;
    public AudioClip Scream;
    public AudioClip Gabagoey;
    public AudioClip Holiness;
    public AudioClip HallLaughing;
    public AudioClip HallGasping;
    public AudioClip collapse;
    public AudioMixer Mixer;
    public AudioClip tenseRob;
    public AudioClip diceRoll;
    public AudioClip thunder;
    public AudioClip beaten;
    public AudioClip backroomsbackgroundmusic;
    public AudioClip backroomsElevatorMusic;
    public AudioClip You;
    public AudioClip will;
    public AudioClip never;
    public AudioClip get;
    public AudioClip out_;
    public AudioClip of;
    public AudioClip here;
    public AudioClip InfiniteRoomEnding;
    public AudioClip MerchantSpeech;

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

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
