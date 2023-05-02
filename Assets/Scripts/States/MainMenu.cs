using System.Collections.Generic;
using UnityEngine;

public class MainMenu : BaseState
{
    private Manager manager;
    private AudioManager audioManager;
    private StateManager stateManager;
    
    public override void EnterState(StateManager state)
    {
        stateManager = state;
        
        manager = Manager.Instance;
        Manager.Instance.test += 1;
        Debug.Log(manager.test + "  " + Manager.Instance.test);
        List<string> options = new List<string>();
        options.Add("Start");
        options.Add("Item 2");
        options.Add("Item 3");
        options.Add("Item 4");
        options.Add("Item 4");
        state.ShowDialogOptions(this, options);
    }

    public override void UpdateState(StateManager state)
    {
        
    }

    public override void OptionClicked(int index, string option)
    {
        if (index >= 0 && option != null)
        {  
            if(index == 0)
                stateManager.SwitchState(stateManager.zuhause);
        }
    }
}
