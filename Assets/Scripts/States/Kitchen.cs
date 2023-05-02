using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Kitchen : BaseState
{    
    private StateManager stateManager;
    private AudioSource audioSource;
    private AudioClip audioClip;
    private TextMeshProUGUI textMesh;
    private List<string> options;


    private bool isVisited = false;
    private string optionEat = "Eat some fruits";
    private string optionBackToBedroom = "Head back to the bedroom";
    private string optionTakeKey = "Take the key";

    
    public override void EnterState(StateManager state)
    {
        stateManager = state;
        audioSource = AudioManager.Instance.source;
        textMesh = Manager.Instance.textMesh;
        options = new List<string>();
        if (stateManager.hasEaten)
        {
            if(!stateManager.hasKey)
                Manager.Instance.key.SetActive(true);
            else
                Manager.Instance.key.SetActive(false);
            
            Manager.Instance.backgroundImage.sprite = Manager.Instance.backgroundSprites[4];
        }
        else
        {
            Manager.Instance.backgroundImage.sprite = Manager.Instance.backgroundSprites[5];
        }

        if (!isVisited)
        {
            textMesh.text =
                "Ayo, what happened to the Kitchen?\nNevermind, just focus on the exam you don't have time for this.";
            isVisited = true;
        }
        else
        {
            textMesh.text =
                "It's still weird that the kitchen looks this cartoonish. Maybe you didn't got enough sleep last night...";
        }
        
        if(!stateManager.hasEaten)
            options.Add(optionEat);
        if(stateManager.hasEaten && !stateManager.hasKey)
            options.Add(optionTakeKey);
        options.Add(optionBackToBedroom);
        
        stateManager.ShowDialogOptions(this, options);

    }

    public override void UpdateState(StateManager state)
    {

    }

    public override void OptionClicked(int index, string option)
    {
        if (option.Equals(optionBackToBedroom))
        {
            stateManager.SwitchState(stateManager.zuhause);
        }
        else if (option.Equals(optionEat))
        {
            if(!stateManager.hasKey)
                Manager.Instance.key.SetActive(true);
            stateManager.hasEaten = true;
            audioSource.PlayOneShot(AudioManager.Instance.eatApple, 0.5f);
            textMesh.text = "Yummy, that was healthy compared to the usual stuff you were eating the last days.\nYou even ate the cutlery. There should be nice weather tomorrow.\n\nBy the way, is this the closet <color=yellow>key</color>?";
            Manager.Instance.backgroundImage.sprite = Manager.Instance.backgroundSprites[4];
            options.Remove(option);
            options.Add(optionTakeKey);
            options.Sort();
            stateManager.ShowDialogOptions(this, options);
        }

        if (option.Equals(optionTakeKey))
        {
            Manager.Instance.collectKey();
            options.Remove(option);
            stateManager.hasKey = true;
            stateManager.ShowDialogOptions(this, options);
        }
    }

    public override void leaveState(StateManager state)
    {
        Manager.Instance.key.SetActive(false);
    }
}
