using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource source;
    public AudioSource sourceGlobal;
    public AudioSource sourceSamwel;
    public AudioSource sourceBackrooms;
    public AudioClip fashion;
    public AudioClip standardBackgroundMusicClip;
    public AudioClip zipper;
    public AudioClip eatApple;
    public AudioClip collectItem;
    public AudioClip lockedDoor;
    public AudioClip unlockDoor;
    public AudioClip camera;
    public AudioClip barcodeScanner;
    public AudioClip usbConnected;
    public AudioClip cashRegister;
    public AudioClip backRoomEntrance;
    public AudioClip tenseRob;
    public AudioClip diceRoll;
    public AudioClip thunder;
    public AudioClip beaten;

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
