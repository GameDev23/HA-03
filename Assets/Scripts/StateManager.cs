using System;
using System.Collections;
using System.Collections.Generic;
using States;
using UnityEngine;
/**
 * This class manages the States and calls in each frame the UpdateState function of the currentState
 *
 * You dont have to code anything here except the initialization of your own StateScript.
 * Use your own script like the "TESTInitState.cs" or the "TESTsecondState.cs" inside the "State Scripts" folder.
 * To use your script, you have to initialize it at (1) and make it reachable from the initstate
 *
 * To test or debug your script you can temporarily change the currentState in the Start() function to your function name
 * which then makes your script the first one which runs
 */
public class StateManager : MonoBehaviour
{
    public static StateManager Instance;
    BaseState currentState;

    #region State Initialization
    // (1) Initialize your scripts / states here like this  make them public to use them at other locations
    public BaseState initState = new TESTInitState();
    public BaseState secondState = new TESTsecondState();
    public BaseState zuhause = new Zuhause_Bedroom();
    public BaseState bridge = new UniBridge();
    
    /// end of (1)
    #endregion
   

    private void Awake()
    {
        // create singleton
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        currentState = zuhause;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }
    
    public void SwitchState(BaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
