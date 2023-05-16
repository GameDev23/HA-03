using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class backrooms1 : BaseState
{



    private StateManager stateManager;
    private List<string> options;
    private TextMeshProUGUI textMesh;

    private TextMeshProUGUI SanityNumber;


    private int runBackCounter;


    private string option1Start = ("Run Back");
    private string option1Start1Text = ("It Seems to be locked, I must find another way");
    private string option2Start = ("Head Towards the Suspicious Looking Elevator ");
    private string option2Start1 = ("Enter the Elevator");  
    private string option3Start = ("Start Mp3 player"); 
    private string option4Start = ("Slowly walk towards the unknown");
    private string option4StartHeadText1 = ("In the back of the Room you see something weird, What could it be ?");
    private string option4Start1 = ("Thats a Funky looking door");
    private string option4StartHeadText2 = ("It smells like Bing chilling in here but why ");
    private string option4Start2 = ("Enter to see if there is a Ice Cream Shop inside ?");
    private string option5start = ("Head left trough the Amogus Door ");
    private string option5StartHeadText1 = ("The Door seems to be looked by something that has the form of an Amogus, maybe you can get it somewhere ?");
    private string option5start1 = ("Open Door");
    private string AmogusDoor = ("Ye need tae find th' Amogus, laddie, or ye'll meet yer demise,In th' depths o' th' Backrooms, where fear fills th' skies.If ye fail tae uncover this elusive mate,Ye'll ne'er escape, doomed tae a dreadful fate.");



    public override void EnterState(StateManager state)
    {
        stateManager = state;
        textMesh = Manager.Instance.textMesh;
        SanityNumber = Manager.Instance.SanityNumber;
        SanityNumber.text = state._sanity.ToString();
        options = new List<string>();
        MP3Script.audioSource = AudioManager.Instance.sourceGlobal;
        textMesh.text = option4StartHeadText1;


        AudioManager.Instance.sourceGlobal.volume = 0.0f;
        AudioManager.Instance.sourceBackrooms.clip = AudioManager.Instance.backroomsbackgroundmusic;
        if(!AudioManager.Instance.sourceBackrooms.isPlaying)
        {
            AudioManager.Instance.sourceBackrooms.Play();
        }
        AudioManager.Instance.sourceBackrooms.volume = 0.4f;        



        options.Add(option1Start);
        options.Add(option2Start);
        options.Add(option3Start);
        options.Add(option4Start);
        options.Add(option5start);

        stateManager.ShowDialogOptions(this, options);

        Manager.Instance.backgroundImage.sprite = Manager.Instance.backgroundSprites[8];

    }

    public override void UpdateState(StateManager state)
    {

        if (stateManager.isWearingBalenciaga && !Flash.Instance.flashing && !Flash.Instance.isInvoked)
        {
            float delay = Random.Range(0.02f, 1f);
            Debug.Log("Flash start with delay of " + delay);
            Flash.Instance.doFlashWithDelay(delay);
            
        }

        if(runBackCounter >= 5)
        {
            stateManager.SwitchState(stateManager.infinite_Room1);
        }
        
    }
    
    public override void OptionClicked(int index, string option)
    {
        if (option.Equals(option1Start))//Run back
        {
            Debug.Log("testSus");
            textMesh.text = option1Start1Text;
            runBackCounter += 1;

            return;


        }else if (option.Equals(option2Start)) //Head Towards the Suspicious Looking Elevator
        {
            Debug.Log("testSus2");
            options.Insert(2,option2Start1);
            options.Remove(option2Start);
            stateManager.ShowDialogOptions(this, options);

            return;

        }else if (option.Equals(option2Start1)) //Enter the Elevator
        {
            stateManager.SwitchState(stateManager.backroomsElevator);  



            return;
        
        }else if (option.Equals(option3Start)) //Start Mp3 player
        {
            Debug.Log("testSus3");
            Manager.Instance.mp3Player.SetActive(true);


            return;

        }else if (option.Equals(option4Start)) //Slowly walk towards the unknown"
        {
            Debug.Log("testsus4");
            textMesh.text = option4StartHeadText2;
            options.Insert(4,option4Start1);
            options.Remove(option4Start);
            stateManager.ShowDialogOptions(this, options);

            return;

        }else if(option.Equals(option4Start1)){
            options.Insert(4,option4Start2);
            options.Remove(option4Start1);
            stateManager.ShowDialogOptions(this, options);



            return;
        }else if (option.Equals(option4Start2)){

            stateManager.SwitchState(stateManager.shop);

            return;
        }else if (option.Equals(option5start)) // head left trough amogus door
        {
            textMesh.text = option5StartHeadText1;
            options.Insert(5, option5start1);
            options.Remove(option5start);

            stateManager.ShowDialogOptions(this, options);

            return;

        }else if (option.Equals(option5start1)) // open door
        {
            if (!stateManager.AmogusKey)
            {
                textMesh.text = AmogusDoor;
                return;

            }

            stateManager.SwitchState(stateManager.secret_Ending);
            return;

        }




    }

    public override void leaveState(StateManager state)
    {
        if(option1Start.Equals(option2Start1)){
            stateManager.SwitchState(stateManager.backroomsElevator);           
        }
        
    }  
}
