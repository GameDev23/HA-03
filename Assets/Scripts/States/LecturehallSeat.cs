using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LecturehallSeat : BaseState
{
    private StateManager stateManager;
    private List<string> options;
    private TextMeshProUGUI textMesh;

    private bool isWearingBalenciaga;
    private bool isIntro = true;
    private int questionNo = 0;

    private string optionStart = "start";
    
    public override void EnterState(StateManager state)
    {
        textMesh = Manager.Instance.textMesh;
        options = new List<string>();
        stateManager = state;

        isWearingBalenciaga = state.isWearingBalenciaga;
        Manager.Instance.backgroundImage.sprite = Manager.Instance.backgroundSpritesDavid[1];
        AudioManager.Instance.sourceGlobal.clip = AudioManager.Instance.examTheme;
        AudioManager.Instance.sourceGlobal.Play();

        if (isIntro)
        {
            textMesh.text = "Finally, you got the exam. Now start and do smart stuff";
            options.Add(optionStart);
        }
        state.ShowDialogOptions(this, options);
    }

    public override void UpdateState(StateManager state)
    {
        if (isWearingBalenciaga && !Flash.Instance.flashing && !Flash.Instance.isInvoked)
        {
            float delay = Random.Range(2f, 7f);
            Debug.Log("Flash start with delay of " + delay);
            Flash.Instance.doFlashWithDelay(delay);
        }
    }

    public override void OptionClicked(int index, string option)
    {
        if (option.Equals(optionStart) && stateManager.pencilCount < 1)
        {
            textMesh.text =
                "You forgot to take a pen... What a shame ... You cant handle the stress and instantly die on the spot... ";
            options = new List<string>();
            options.Add("die");
            stateManager.ShowDialogOptions(this, options);
        }
    }

    public override void leaveState(StateManager state)
    {
    }
}
