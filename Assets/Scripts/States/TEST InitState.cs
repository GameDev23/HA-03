using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * This class MUST NOT derive from monobehaviour   instead make it derive from BaseState and implement these methods:
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
 * you have access to all relevant methods via the "state" variable inside the functions e.g the SwitchState function
 */
public class TESTInitState : BaseState
{
    /* here you can initialize your variables which you need for your state
     * make them public if you need to access them in other states
    */
    private int testVariable;
    

    public override void EnterState(StateManager state)
    {
        testVariable = 0;
        Debug.Log("The State has been initialised with the test variable: " + testVariable);
        Debug.Log("press P to make a transition to the next state");
    }

    /** inside here you can put your logic, which should be called each frame while your state is active
     * 
     */
    public override void UpdateState(StateManager state)
    {
 
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            // To switch to another state you simply call state.Switchstate and pass in state.YOURSTATENAME which
            // got initialized in "StateManager.cs" at (1)
            state.SwitchState(state.secondState);
        }
        

    }
}
