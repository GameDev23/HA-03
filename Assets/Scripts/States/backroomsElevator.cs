using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class backroomsElevator : BaseState
{
    private StateManager stateManager;
    private List<string> options;
    private TextMeshProUGUI textMesh;

    private TextMeshProUGUI SanityNumber;

    private float TimeElapsed = 0f;



    private string Introduction = ("You have Entered a slim shady looking Elevator what to do now ?");

    private string option1Start = ("HELP");
    private string option2Start = ("HELP");  //reduce sanity
    private string option3Start = ("HELP "); //raises Sanity
    private string option4Start = ("HELP");
    private string creditcardshark = ("Merchant: Hail, goodly traveler! I bear tidings of a marvel! 'Tis a portable card for swift exchanges. No more clinking coins! Merchants far and wide doth accept it. Piqued thy interest?");




    public override void EnterState(StateManager state)
    {
        stateManager = state;
        textMesh = Manager.Instance.textMesh;
        SanityNumber = Manager.Instance.SanityNumber;
        SanityNumber.text = state._sanity.ToString();
        options = new List<string>();
        MP3Script.audioSource = AudioManager.Instance.sourceGlobal;
        TimeElapsed = 0f;


        AudioManager.Instance.sourceGlobal.volume = 0.0f;
        AudioManager.Instance.sourceBackrooms.clip = AudioManager.Instance.backroomsElevatorMusic;
        if(!AudioManager.Instance.sourceBackrooms.isPlaying)
        {
            AudioManager.Instance.sourceBackrooms.Play();
        }
        AudioManager.Instance.sourceBackrooms.volume = 0.4f;   

        Manager.Instance.PanelSanity.SetActive(true);     



        options.Add(option1Start);
        options.Add(option2Start);
        options.Add(option3Start);
        options.Add(option4Start);

        stateManager.ShowDialogOptions(this, options);

        Manager.Instance.backgroundImage.sprite = Manager.Instance.backgroundSprites[9];
        textMesh.text = Introduction;



    }

    public override void leaveState(StateManager state)
    {

    }

    public override void OptionClicked(int index, string option)
    {
        if(option.Equals(option1Start))
        {
            textMesh.text = creditcardshark;
            stateManager.ShowDialogOptions(this, options);


        }else if(option.Equals(option2Start)){
            textMesh.text = creditcardshark;
            stateManager.ShowDialogOptions(this, options);

        }else if(option.Equals(option3Start)){
            textMesh.text = creditcardshark;
            stateManager.ShowDialogOptions(this, options);

        }else if(option.Equals(option3Start)){
            textMesh.text = creditcardshark;
            stateManager.ShowDialogOptions(this, options);
            
        }
            

        return;
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


        TimeElapsed += 1 * Time.deltaTime;
        stateManager._sanity = (int)(100f - (100f / 75f * TimeElapsed));
        if(TimeElapsed >= 75f)
        {
            stateManager.SwitchState(stateManager.endingDead);
            Manager.Instance.PanelSanity.SetActive(false);
        }
    }  

}
