using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeavingHouse : BaseState
{
    private StateManager stateManager;
    private List<string> options;
    private TextMeshProUGUI textMesh;

    #region Options
    private string option_normal_way = "Take usual way to Uni";
    private string option_shady_fast_way = "Take the fast but shady way to Uni";
    #endregion

    public override void EnterState(StateManager state)
    {
        //Simplificiation in writing
        stateManager = state;
        textMesh = Manager.Instance.textMesh;
        options = new List<string>();
        Manager.Instance.backgroundImage.sprite = Manager.Instance.samwelSprites[1];
        options.Add(option_normal_way);
        options.Add(option_shady_fast_way);
        state.ShowDialogOptions(this, options);
        textMesh.text = "That's it! You're all set to face the exam. Choose a route to school";
    }

    public override void leaveState(StateManager state)
    {

    }

    public override void OptionClicked(int index, string option)
    {
        //  Switchiing state
        if (option.Equals(option_normal_way)) {
            stateManager.SwitchState(stateManager.normalWay);
            return;
        }

        if (option.Equals(option_shady_fast_way))
        {
            stateManager.SwitchState(stateManager.shadyWay);
            return;
        }
    }

    public override void UpdateState(StateManager state)
    {

    }
}
