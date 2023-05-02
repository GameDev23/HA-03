namespace States
{
    public class UniBridge : BaseState
    {
        public override void EnterState(StateManager state)
        {
            Manager.Instance.backgroundImage.sprite = Manager.Instance.bridge;
            Manager.Instance.textMesh.text = "Thats some ugly looking bridge btw.  Lets hussle to HZ0 40 asap!";
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
}