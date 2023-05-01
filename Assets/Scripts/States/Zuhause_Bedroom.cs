using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Zuhause_Bedroom : BaseState
{
    public List<string> inventory = new List<string>();
    private AudioSource audioSource;
    private AudioClip audioClip;
    private TextMeshProUGUI textMesh;
    public override void EnterState(StateManager state)
    {
        Manager.Instance.backgroundImage.sprite = Manager.Instance.bedroom;
        Manager.Instance.textMesh.text = "You woke up. Time to pack your things and head to uni to write your exam.";
        AudioManager.Instance.source.clip = AudioManager.Instance.fashion;
        AudioManager.Instance.source.Play();
        AudioManager.Instance.source.volume = 0.1f;
        textMesh = Manager.Instance.textMesh;
    }

    public override void UpdateState(StateManager state)
    {
        if (Input.GetKeyDown(KeyCode.P) && !inventory.Contains("pants"))
        {
            inventory.Add("pants");
            string text = "You have found some pants and decided to wear them.";
            textMesh.text = text;


        }
        if(Input.GetKeyDown(KeyCode.W))
            state.SwitchState(state.bridge);
    }
}
