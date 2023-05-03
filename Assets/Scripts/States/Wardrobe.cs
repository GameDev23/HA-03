using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class Wardrobe : BaseState
{

    private StateManager stateManager;
    private AudioSource audioSource;
    private AudioClip audioClip;
    private TextMeshProUGUI textMesh;
    private List<string> options;

    private Sprite backgroundSPrite; 
    
    
    public override void EnterState(StateManager state)
    {
        options = new List<string>();
        stateManager = state;
        if (AudioManager.Instance.sourceGlobal.volume != 0f)
            AudioManager.Instance.sourceGlobal.volume = 0f;
        
        Manager.Instance.backgroundImage.sprite = Manager.Instance.backgroundSprites[2];
        Manager.Instance.textMesh.text = "";
        AudioManager.Instance.source.clip = AudioManager.Instance.fashion;
        AudioManager.Instance.source.Play();
        AudioManager.Instance.source.volume = 0.4f;
        textMesh = Manager.Instance.textMesh;
        
        //create new list which will contain the options listed above
        options = new List<string>();
        //add some options
        if(!stateManager.isWearingBalenciaga)
            options.Add("Put on the BALENCIAGA®'s");
        if(!stateManager.isWearingClothes || stateManager.isWearingBalenciaga)
            options.Add("Decide to put on only some normal clothes");
        options.Add("go back to bedroom...");

        //show these options on the panel
        state.ShowDialogOptions(this, options);
        
    }

    public override void UpdateState(StateManager state)
    {
        if (stateManager.isWearingBalenciaga && !Flash.Instance.flashing && !Flash.Instance.isInvoked)
        {
            float delay = Random.Range(0.02f, 2f);
            Debug.Log("Flash start with delay of " + delay);
            Flash.Instance.doFlashWithDelay(delay);
            
        }

    }

    public override void OptionClicked(int index, string option)
    {
        switch (option)
        {
            case "go back to bedroom...":
                stateManager.SwitchState(stateManager.zuhause);
                break;
            
            case "Put on the BALENCIAGA®'s":
                AudioManager.Instance.source.PlayOneShot(AudioManager.Instance.zipper, 0.5f);
                textMesh.text = "Wow  you're feeling much more confident now. You will ace this exam";
                options[index] = "";
                if (!options.Contains("Decide to put on only some normal clothes"))
                    options[index] = "Decide to put on only some normal clothes";
                stateManager.isWearingClothes = true;
                stateManager.isWearingBalenciaga = true;
                stateManager.ShowDialogOptions(this, options);
                break;
            case "Decide to put on only some normal clothes":
                AudioManager.Instance.source.PlayOneShot(AudioManager.Instance.zipper, 0.5f);
                textMesh.text = "Hmm..  okay i guess.";
                options[index] = "";
                if (!options.Contains("Put on the BALENCIAGA®'s"))
                    options[index] ="Put on the BALENCIAGA®'s";
                stateManager.isWearingClothes = true;
                stateManager.isWearingBalenciaga = false;
                stateManager.ShowDialogOptions(this, options);
                break;

            default:
                break;
        }
        
    }

    public override void leaveState(StateManager state)
    {
        Manager.Instance.backgroundImage.color = Color.white;
        AudioManager.Instance.source.Stop();
        AudioManager.Instance.sourceGlobal.volume = 0.4f;
        
    }
}
