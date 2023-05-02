using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * This class DOES NOT derive from monobehaviour   instead make it derive from BaseState
 * EnterState()
 *  -is only called at the beginning of your state and each time we make a transition from a different
 *   state to this state  similar to the start() method you already worked with
 *      -Here comes the initialisation of your state e.g check if you have been robbed etc
 *          you can put these variables into Manager.cs or handle them here if they wont have a global impact
 *
 * UpdateState()
 *  -is called everyframe like the Update() method you already worked with
 *      -Here should go your state logic and implementation
 * 
 */
public class TESTsecondState : BaseState
{
    private int testVariable;
    public override void EnterState(StateManager state)
    {

        Debug.Log("You are now in the second state   Nice");
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
