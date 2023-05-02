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
        
        //create new list which will contain the options listed above
        List<string> options = new List<string>();
        //add some options
        options.Add("Start");
        options.Add("Item 2");
        options.Add("Item 3");
        options.Add("Item 4");
        options.Add("Item 4");
        //show these options on the panel
        state.ShowDialogOptions(this, options);
    }

    public override void UpdateState(StateManager state)
    {
        
    }

    public override void OptionClicked(int index, string option)
    {
        switch (index)
        {
            case 0:
                stateManager.SwitchState(stateManager.zuhause);
                break;
            case 1:
                manager.textMesh.text = "Not yet implemented";
                break;            
            case 2:
                manager.textMesh.text = "Not yet implemented";
                break;            
            case 3:
                manager.textMesh.text = "Not yet implemented";
                break;            
            case 4:
                manager.textMesh.text = "Not yet implemented";
                break;
            default:
                manager.textMesh.text = "INDEX OUT OF BOUNDS  THIS SHOULD NOT OCCUR";
                break;
        }
    }
}