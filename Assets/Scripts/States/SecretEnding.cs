using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SecretEnding : BaseState
{

    private StateManager stateManager;
    private List<string> options;
    private TextMeshProUGUI textMesh;

    private TextMeshProUGUI SanityNumber;



    private string Introduction = ("Is this heaven or Am i dead");

    private string option1Start = ("sss");
    private string option2Start = ("sss");  
   




    public override void EnterState(StateManager state)
    {
        stateManager = state;
        textMesh = Manager.Instance.textMesh;
        SanityNumber = Manager.Instance.SanityNumber;
        SanityNumber.text = state._sanity.ToString();
        options = new List<string>();
        MP3Script.audioSource = AudioManager.Instance.sourceGlobal;


        AudioManager.Instance.sourceGlobal.volume = 0.0f;
        AudioManager.Instance.sourceBackrooms.clip = AudioManager.Instance.backroomsbackgroundmusic;
        if(!AudioManager.Instance.sourceBackrooms.isPlaying)
        {
            AudioManager.Instance.sourceBackrooms.Play();
        }
        AudioManager.Instance.sourceBackrooms.volume = 0.4f;   

        Manager.Instance.PanelSanity.SetActive(true);
        


        options.Add(option1Start);
        options.Add(option2Start);


        stateManager.ShowDialogOptions(this, options);

        Manager.Instance.backgroundImage.sprite = Manager.Instance.backgroundSprites[11];
        textMesh.text = Introduction;


    }

    public override void leaveState(StateManager state)
    {


    }

    public override void OptionClicked(int index, string option)
    {


    }



    public override void UpdateState(StateManager state)
    {
        if (stateManager.isWearingBalenciaga && !Flash.Instance.flashing && !Flash.Instance.isInvoked)
        {
            float delay = Random.Range(3f, 10f);
            Debug.Log("Flash start with delay of " + delay);
            Flash.Instance.doFlashWithDelay(delay);
            
        }   

        if(MP3Script.isPlaying){
            AudioManager.Instance.sourceBackrooms.volume = 0.0f;
        }else 
        {
            AudioManager.Instance.sourceBackrooms.volume = 0.2f;
        }


        Manager.Instance.SanityBar.fillAmount = ((float)stateManager._sanity) / 100;

        if(stateManager._sanity <=0 )
            stateManager._sanity = 0;

    }

}