using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI volumeTextMesh;

    public void OnValueChanged(float volume)
    {

            volumeTextMesh.text = "Volume  " + (int) ((volume + 80) * 1.25f) + "%";
            AudioManager.Instance.Mixer.SetFloat("MainVol", volume);

    }
}
