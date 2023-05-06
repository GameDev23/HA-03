using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Exam : BaseState
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
        Manager.Instance.backgroundImage.sprite = Manager.Instance.backgroundSprites[9];
        textMesh.text = "What a lovely day at the RUB today. Is that cloud shaped like a dragon? I better get to my exam";

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
