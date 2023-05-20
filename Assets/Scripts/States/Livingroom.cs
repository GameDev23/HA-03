using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Livingroom : BaseState
{
    private StateManager stateManager;
    private List<string> options;
    private TextMeshProUGUI textMesh;
    private string optionPfand;
    private string optionLeaveToKitchen;
    private string optionLeaveHome = "Get ready to leave to university";
    public override void EnterState(StateManager state)
    {
        textMesh = Manager.Instance.textMesh;
        options = new List<string>();
        stateManager = state;
        optionPfand = "Collect some plastic bottles";
        optionLeaveToKitchen = "Head back to the kitchen";
        options.Add(optionPfand);
        options.Add(optionLeaveToKitchen);
        options.Add(optionLeaveHome);

        Manager.Instance.backgroundImage.sprite = Manager.Instance.backgroundSprites[6];
        textMesh.text = "Ayo,  this looks like a german gold mine in here";
        stateManager.ShowDialogOptions(this, options);
    }

    public override void UpdateState(StateManager state)
    {
        
    }

    public override void OptionClicked(int index, string option)
    {
        if (option.Equals(optionPfand))
        {

                stateManager.pfandFlaschenCount++;
                if(!stateManager.hasCollectedPfandflaschengeraet)
                {
                    textMesh.text = "Nice you now have " + stateManager.pfandFlaschenCount
                                                         + " bottle\\s. Remember your trip to germany last year?\nYou bought that weird thing which was called\n" +
                                                         " <color=yellow>PFANDFLASCHENSCANGERÄT</color>\nfrom the REWE©,\nmaybe it will come in handy now.\nI think you stored in somewhere in the kitchen";
                }
                else
                {
                    textMesh.text = "Nice you now have " + stateManager.pfandFlaschenCount + " bottle\\s";
                }
                stateManager.knowsAboutPfandflaschengeraet = true;
                
            
            
            
        }

        if (option.Equals(optionLeaveToKitchen))
        {
            stateManager.SwitchState(stateManager.kitchen);
        }

        if (option.Equals(optionLeaveHome))
        {
            stateManager.SwitchState(stateManager.leavingHouse);
        }
    }

    public override void leaveState(StateManager state)
    {
        
    }
}
