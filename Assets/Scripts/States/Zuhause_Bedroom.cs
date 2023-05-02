using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Zuhause_Bedroom : BaseState
{
    public List<string> inventory = new List<string>();
    private StateManager stateManager;
    private List<string> options;
    private AudioSource audioSource;
    private AudioClip audioClip;
    private TextMeshProUGUI textMesh;
    private bool isStart = true;
    
    //options
    private string optionWardrobe;
    private string optionComputer;
    public override void EnterState(StateManager state)
    {
        stateManager = state;
        textMesh = Manager.Instance.textMesh;
        options = new List<string>();
        Manager.Instance.backgroundImage.sprite = Manager.Instance.bedroom;
        if(isStart)
        {
            


            textMesh.text = "Time to get up and put on your BALENCIAGA® and pack your stuff to write todays exam.\n\n" +
                            "There's a reason why they say that fashion is a form of self-expression – and today, You're expressing your determination, ambition, and intelligence through your choice to wear BALENCIAGA® to this life-changing exam. ";
            

            
            /*AudioManager.Instance.source.clip = AudioManager.Instance.fashion;
            AudioManager.Instance.source.Play();
            AudioManager.Instance.source.volume = 0.1f;*/
            textMesh = Manager.Instance.textMesh;
            isStart = false;
            
        }
        else
        {
            textMesh.text = "What now?";
            if (stateManager.isWearingBalenciaga)
                textMesh.text = "Damn, I feel confident now.";
            textMesh.text += "\n";

        }
        optionWardrobe = "Head to the wardrobe.";
        optionComputer = "Go to computer";
        options.Add(optionWardrobe);
        options.Add(optionComputer);
        state.ShowDialogOptions(this, options);
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
        if (option.Equals(optionWardrobe))
        {
            stateManager.SwitchState(stateManager.wardrobe);
        }
        else if (option.Equals(optionComputer))
        {
            stateManager.SwitchState(stateManager.computer);
        }
    }

    public override void leaveState(StateManager state)
    {
        
    }
}
