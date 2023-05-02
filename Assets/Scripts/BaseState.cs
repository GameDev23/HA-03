using UnityEngine;

/**
 * This class is the blueprint for all states  do not modify anything directly here
 */
public abstract class BaseState
{
    /**
     * EnterState runs once everytime your state becomes the active state
     */
    public abstract void EnterState(StateManager state);

    /**
     * UpdateState runs once each frame while your state is the active one
     */
    public abstract void UpdateState(StateManager state);

    /**
     * This method is called when one of your provided options is clicked within the scene
     * it has the parameter of your options list and the stored string of it
     * 
     * Important:
     * if something goes wrong then index will be -1 and option will be null so check for them
     */
    public abstract void OptionClicked(int index, string option);

    /**
     * This method is called once at the end of your state while it transitions to the next one.
     * Use this method to get rid of all global things like background music etc.
     */
    public abstract void leaveState(StateManager state);



}
