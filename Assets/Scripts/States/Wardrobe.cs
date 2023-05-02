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
    List<string> options = new List<string>();
    public override void EnterState(StateManager state)
    {
        stateManager = state;
        Manager.Instance.backgroundImage.sprite = Manager.Instance.backgroundSprites[2];
        Manager.Instance.textMesh.text = "";
        AudioManager.Instance.source.clip = AudioManager.Instance.fashion;
        AudioManager.Instance.source.Play();
        AudioManager.Instance.source.volume = 0.1f;
        textMesh = Manager.Instance.textMesh;
        
        //create new list which will contain the options listed above
        options = new List<string>();
        //add some options
        options.Add("Put on the BALENCIAGA®'s");
        options.Add("Decide to put on only some normal clothes");
        options.Add("go back to bedroom...");

        //show these options on the panel
        state.ShowDialogOptions(this, options);
        
    }

    public override void UpdateState(StateManager state)
    {

    }

    public override void OptionClicked(int index, string option)
    {
        switch (option)
        {
            case "go back to bedroom...":
                stateManager.SwitchState(stateManager.zuhause);
                break;
            
            case "Put on the BALENCIAGA®'s":
                textMesh.text = "Wow  im feeling much more confident now. I will ace this exam";
                options[index] = "";
                if (!options.Contains("Decide to put on only some normal clothes"))
                    options[index] = "Decide to put on only some normal clothes";
                stateManager.isWearingClothes = true;
                stateManager.isWearingBalenciaga = true;
                stateManager.ShowDialogOptions(this, options);
                break;
            case "Decide to put on only some normal clothes":
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
}