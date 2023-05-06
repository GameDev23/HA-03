using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingPassed : BaseState
{
    public override void EnterState(StateManager state)
    {
        AudioManager.Instance.sourceGlobal.clip = AudioManager.Instance.endingPassed;
        AudioManager.Instance.sourceGlobal.volume = AudioManager.Instance._Volume * 0.1f;
        AudioManager.Instance.sourceGlobal.Play();

        Manager.Instance.backgroundImage.sprite = Manager.Instance.backgroundSpritesDavid[3];
        Manager.Instance.textMesh.text =
            "Well done, you've successfully proven that you're capable of memorizing random facts and promptly forgetting them the second the exam is over.\n\n(THE END)";
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
