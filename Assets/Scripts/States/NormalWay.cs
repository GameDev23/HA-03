using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NormalWay : BaseState
{
    private StateManager stateManager;
    private List<string> options;
    private TextMeshProUGUI textMesh;
    private string goToExam = "proceed";
    private string goBackHome = "return home";
    private GameObject Dragon;

    public override void EnterState(StateManager state)
    {
        //Simplificiation in writing
        Dragon = Manager.Instance.Dragon; // reference to the dragon
        Manager.Instance.Dragon.SetActive(true);
        AudioManager.Instance.sourceGlobal.PlayOneShot(AudioManager.Instance.DragonRoar,  2.0f);
        stateManager = state;
        textMesh = Manager.Instance.textMesh;
        options = new List<string>();
        Manager.Instance.backgroundImage.sprite = Manager.Instance.backgroundSprites[1];
        options.Add(goToExam);
        options.Add(goBackHome);
        state.ShowDialogOptions(this, options);
        textMesh.text = "What a lovely day at the RUB today. Is that cloud shaped like a dragon? I better get to my exam";

    }

    public override void leaveState(StateManager state)
    {
        Manager.Instance.Dragon.SetActive(false);
    }

    public override void OptionClicked(int index, string option)
    {
        //  Switchiing state
        if (option.Equals(goToExam))
        {
            stateManager.SwitchState(stateManager.lecturehallEntrance);
            return;
        }

        if (option.Equals(goBackHome)) 
        {
            stateManager.SwitchState(stateManager.leavingHouse);    
            return;
        }


    }

    public override void UpdateState(StateManager state)
    {
        Dragon.transform.position += Vector3.right * Time.deltaTime * 4.0f;
    }
}
