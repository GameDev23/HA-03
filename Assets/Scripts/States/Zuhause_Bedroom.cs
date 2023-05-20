using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Zuhause_Bedroom : BaseState
{
    public List<string> inventory = new List<string>();
    private StateManager stateManager;
    private List<string> options;
    private AudioSource audioSource;
    private AudioClip audioClip;
    private TextMeshProUGUI textMesh;
    private bool isStart = true;
    
    //options
    private string optionWardrobe;
    private string optionComputer;
    private string optionKitchen;
    public override void EnterState(StateManager state)
    {
        stateManager = state;
        textMesh = Manager.Instance.textMesh;
        options = new List<string>();
        Manager.Instance.backgroundImage.sprite = Manager.Instance.bedroom;
        if(isStart)
        {
            


            textMesh.text = "Time to get up and put on your BALENCIAGA® and pack your stuff to write todays exam.\n\n" +
                            "There's a reason why they say that fashion is a form of self-expression – and today, You're expressing your determination, ambition, and intelligence through your choice to wear BALENCIAGA® to this life-changing exam. ";
            

            
            /*AudioManager.Instance.source.clip = AudioManager.Instance.fashion;
            AudioManager.Instance.source.Play();
            AudioManager.Instance.source.volume = 0.1f;*/
            textMesh = Manager.Instance.textMesh;
            isStart = false;
            
        }
        else
        {
            textMesh.text = "What now?";
            if (stateManager.isWearingBalenciaga)
                textMesh.text = "Damn, look at you and your BALENCIAGA®'s ";
            else if (!stateManager.isWearingBalenciaga && stateManager.isWearingClothes)
                textMesh.text = "Hmmm";
            textMesh.text += "\n";

        }
        optionWardrobe = "Head to the wardrobe.";
        optionComputer = "Go to your desk";
        optionKitchen = "Head to the kitchen";
        options.Add(optionWardrobe);
        options.Add(optionKitchen);
        options.Add(optionComputer);
        state.ShowDialogOptions(this, options);
    }

    public override void UpdateState(StateManager state)
    {
        /* COMMENTED OUT DEBUG RELATED STUFF
        if(Input.GetKeyDown(KeyCode.W))
            state.SwitchState(state.lecturehallEntrance);
            */
    }
    
    public override void OptionClicked(int index, string option)
    {
        if (option.Equals(optionWardrobe))
        {
            //check if wardrobe is Locked
            if(!stateManager.wardrobeIsLocked)
                stateManager.SwitchState(stateManager.wardrobe);
            //check if is locked, but can be unlocked
            else if (stateManager.wardrobeIsLocked && stateManager.hasKey)
            {
                stateManager.wardrobeIsLocked = false;
                AudioManager.Instance.source.PlayOneShot(AudioManager.Instance.unlockDoor, 1f);
                stateManager.SwitchState(stateManager.wardrobe);
            }
            else
            {
                textMesh.text = "Hmm  seems locked. The key should be somewhere...";
                AudioManager.Instance.sourceGlobal.PlayOneShot(AudioManager.Instance.lockedDoor, 1f);

            }
        }
        else if (option.Equals(optionComputer))
        {
            stateManager.SwitchState(stateManager.computer);
        }
        else if (option.Equals(optionKitchen))
        {
            stateManager.SwitchState(stateManager.kitchen);
        }
    }

    public override void leaveState(StateManager state)
    {
        
    }
}
