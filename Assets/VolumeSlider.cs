using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSlider : MonoBehaviour
{
    public void OnValueChanged(float volume)
    {
        AudioManager.Instance.Mixer.SetFloat("MainVol", volume);
    }
}
