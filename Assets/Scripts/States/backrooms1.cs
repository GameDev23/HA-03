using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class backrooms1 : BaseState
{



    private StateManager stateManager;
    private List<string> options;
    private TextMeshProUGUI textMesh;



    public override void EnterState(StateManager state)
    {
        stateManager = state;

    }

    public override void UpdateState(StateManager state)
    {
        
    }
    
    public override void OptionClicked(int index, string option)
    {
        
    }

    public override void leaveState(StateManager state)
    {
        
    }  
}
