using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using TMPro.EditorUtilities;

public class Computer : BaseState
{ 
    private StateManager stateManager;
    private List<string> options;



    private string backOption;
    
    public override void EnterState(StateManager state)
    {

        options = new List<string>();
        stateManager = state;
        Manager.Instance.backgroundImage.sprite = Manager.Instance.backgroundSprites[3];
        backOption = "leave";
        options.Add(backOption);
        
        state.ShowDialogOptions(this, options);
    }

    public override void UpdateState(StateManager state)
    {

    }

    public override void OptionClicked(int index, string option)
    {
        if (option.Equals(backOption))
        {
            stateManager.SwitchState(stateManager.zuhause);
        }
    }

    public override void leaveState(StateManager state)
    {

    }
}
