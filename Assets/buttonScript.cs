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
        currentState.OptionClicked(index, option);
    }
}
