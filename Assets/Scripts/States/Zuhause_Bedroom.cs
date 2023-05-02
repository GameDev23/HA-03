using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Zuhause_Bedroom : BaseState
{
    public List<string> inventory = new List<string>();
    private StateManager stateManager;
    List<string> options = new List<string>();
    private AudioSource audioSource;
    private AudioClip audioClip;
    private TextMeshProUGUI textMesh;
    private bool isStart = true;
    public override void EnterState(StateManager state)
    {
        stateManager = state;
        if(isStart)
        {
            
            Manager.Instance.backgroundImage.sprite = Manager.Instance.bedroom;
            Manager.Instance.textMesh.text = "Time to get up and put on my BALENCIAGA® and pack my stuff to write todays exam.\n\n" +
                                             "There's a reason why they say that fashion is a form of self-expression – and today, I'm expressing my determination, ambition, and intelligence through my choice to wear BALENCIAGA® to this life-changing exam. ";
            /*AudioManager.Instance.source.clip = AudioManager.Instance.fashion;
            AudioManager.Instance.source.Play();
            AudioManager.Instance.source.volume = 0.1f;*/
            textMesh = Manager.Instance.textMesh;
            isStart = false;
            
            
            options.Add("Head to the wardrobe.");
            state.ShowDialogOptions(this, options);
        }
        else
        {
            Manager.Instance.backgroundImage.sprite = Manager.Instance.bedroom;
            textMesh.text = "";
            if (stateManager.isWearingBalenciaga)
                textMesh.text = "Damn, I fell confident now.";
        }
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
    
    public override void OptionClicked(int index, string option)
    {
        switch (option)
        {
            case "Head to the wardrobe.":
                stateManager.SwitchState(stateManager.wardrobe);
                break;
                
        }
    }
}