using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonScript : MonoBehaviour
{
    public int index = -1;
    public string option;
    public BaseState currentState;
    
    public void OnClick()
    {
        AudioManager.Instance.sourceGlobal.PlayOneShot(AudioManager.Instance.Click, 0.1f);
        AudioManager.Instance.source.PlayOneShot(AudioManager.Instance.Click, 0.1f);
        
        currentState.OptionClicked(index, option);
    }
}
