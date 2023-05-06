using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EndingDead : BaseState
{
    public override void EnterState(StateManager state)
    {
        Manager.Instance.backgroundImage.sprite = Manager.Instance.backgroundSpritesDavid[2];
        AudioManager.Instance.sourceGlobal.clip = AudioManager.Instance.endingDead;
        AudioManager.Instance.sourceGlobal.volume = 0.3f;
        AudioManager.Instance.sourceGlobal.Play();
        Manager.Instance.textMesh.text = "At least you wont have to deal with the retry exam next semester now\n\n(THE END)";

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
