using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class shadyWayToUni : BaseState
{
    private StateManager stateManager;
    private List<string> options;
    private TextMeshProUGUI textMesh;

    private string samwellTarly = "I'm not risking it. Going back";
    private string serBarristanSelmy = "With my Balenciaga®  on, I am unstoppable!! Time for a Quick duel before exams";

    public override void EnterState(StateManager state)
    {
        //Simplificiation in writing
        stateManager = state;
        textMesh = Manager.Instance.textMesh;
        options = new List<string>();
        Manager.Instance.backgroundImage.sprite = Manager.Instance.backgroundSprites[9];
        options.Add(serBarristanSelmy);
        options.Add(samwellTarly);
        state.ShowDialogOptions(this, options);
        textMesh.text = "You notice a shady figure in the far distance.....";

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
