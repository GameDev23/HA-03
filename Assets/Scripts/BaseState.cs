using UnityEngine;

/**
 * This class is the blueprint for all states  do not modify anything directly here
 */
public abstract class BaseState
{
    public abstract void EnterState(StateManager state);

    public abstract void UpdateState(StateManager state);


}
