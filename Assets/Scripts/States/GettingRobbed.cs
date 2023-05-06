using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GettingRobbed : BaseState
{
    private StateManager stateManager;
    private List<string> options;
    private TextMeshProUGUI textMesh;



    public override void EnterState(StateManager state)
    {
        //Simplificiation in writing
        stateManager = state;
        textMesh = Manager.Instance.textMesh;
        options = new List<string>();

        Manager.Instance.backgroundImage.sprite = Manager.Instance.backgroundSprites[1];


    }

    public override void leaveState(StateManager state)
    {

    }

    public override void OptionClicked(int index, string option)
    {
 
    }

    public override void UpdateState(StateManager state)
    {

    }
}
