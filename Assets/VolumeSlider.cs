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

        volumeTextMesh.text = "Volume " + (int)(volume * 100) + "%";
        Debug.Log("Test " + (Mathf.Log10(volume) * 40));
        AudioManager.Instance.Mixer.SetFloat("MainVol", Mathf.Log10(volume) * 40);
        PlayerPrefs.SetFloat("MainVol", volume);

    }

    void Start()
    {
        float savedValue = PlayerPrefs.GetFloat("MainVol", 1f);
        Manager.Instance.VolumeSlider.value = savedValue;
        Manager.Instance.volumeTextMesh.text = "Volume " + (int)(savedValue * 100) + "%";
        AudioManager.Instance.Mixer.SetFloat("MainVol", Mathf.Log10(savedValue) * 40);
        
    }
}
