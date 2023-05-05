using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Backrooms_Entrance : BaseState
{

    private StateManager stateManager;
    private List<string> options;
    private TextMeshProUGUI textMesh;

    private string Introduction = ("Sussy Baka");

    private string option1 = ("Item 1");
    private string option2 = ("Action0.5");
    private string option3 = ("Action1");
    private string option4 = ("Leave");



    public override void EnterState(StateManager state)
    {
        stateManager = state;
        textMesh = Manager.Instance.textMesh;
        options = new List<string>();

        options.Add(option1);
        options.Add(option2);
        options.Add(option3);
        options.Add(option4);

        stateManager.ShowDialogOptions(this, options);

        Manager.Instance.backgroundImage.sprite = Manager.Instance.backgroundSprites[7];
        textMesh.text = Introduction;



    }

    public override void leaveState(StateManager state)
    {

    }

    public override void OptionClicked(int index, string option)
    {
        if (option.Equals(option1))
        {
            Debug.Log("testSus");
            AudioManager.Instance.sourceGlobal.volume = 0.0f;
            AudioManager.Instance.sourceBackrooms.clip = AudioManager.Instance.backRoomEntrance;
            AudioManager.Instance.sourceBackrooms.Play();
        }

    }

    public override void UpdateState(StateManager state)
    {

    }
}
