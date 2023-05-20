using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Backrooms_Entrance : BaseState
{

    private StateManager stateManager;
    private List<string> options;
    private TextMeshProUGUI textMesh;
    private TextMeshProUGUI SanityNumber;






    private string Introduction = ("You somehow entered the Backrooms But how ? ");

    private string option1Start = ("Look around");
    private string option2Start = ("Start Paniccccc");  //reduce sanity
    private string option3Start = ("Start Mp3 player because You are scared "); //raises Sanity
    private string option4Start = ("You can see a Door APPROACH IT");
    private string openDoor = ("Open Door");
    private string feelings = ("I Feel unconfortable");
    private string paradise = ("I know this Banger calles Paradise by Cozmoe & Wonderland, I think i will play it");
    private string stopSongParadise = ("Pls Stop this song"); //Reduces Sanity per click



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
        options.Add(option3Start);
        options.Add(option4Start);

        stateManager.ShowDialogOptions(this, options);

        Manager.Instance.backgroundImage.sprite = Manager.Instance.backgroundSprites[7];
        textMesh.text = Introduction;



    }

    public override void leaveState(StateManager state)
    {

    }

    public override void OptionClicked(int index, string option)
    {
        if (option.Equals(option1Start))//look around option 1
        {
            Debug.Log("testSus");
            textMesh.text = "I hear a strange noise and sound I wish i could hear something else instead  ";
            options.Insert(1,feelings);
            options.Remove(option1Start);
            stateManager.ShowDialogOptions(this, options);
            return;



        }else if(option.Equals(feelings))
        {
            Debug.Log("Feelings");
            options.Insert(1,paradise);
            options.Remove(feelings);
            stateManager.ShowDialogOptions(this, options);

        }else if (option.Equals(paradise))
        {
            options.Remove(paradise);
            options.Insert(1,stopSongParadise);
            stateManager.ShowDialogOptions(this, options);

            AudioManager.Instance.sourceGlobal.volume = 0.0f;
            AudioManager.Instance.sourceBackrooms.clip = AudioManager.Instance.backRoomEntrance;
            AudioManager.Instance.sourceBackrooms.Play();
            AudioManager.Instance.sourceBackrooms.volume = 0.2f;
    
        }else if(option.Equals(stopSongParadise))
        {
            //implement Reduction of Sanity per click which will lead to death
            stateManager._sanity -= 10;
            SanityNumber.text = stateManager._sanity.ToString();



        
        }else if (option.Equals(option2Start))//panicccc option 2
        {
            Debug.Log("testSus2");
            //SanityNumber.text = SanityNumber.text - ToString(ReduceSanity);
            //Implement Reduce Sanity by Random number between 5-10
            stateManager._sanity -= 10;
            SanityNumber.text = stateManager._sanity.ToString();




            return;
        }else if (option.Equals(option3Start))//start mp3 player option 3
        {
            Debug.Log("testSus3");
            Manager.Instance.mp3Player.SetActive(true);



            return;

        }else if (option.Equals(option4Start))//Approach the door option 4
        {
            Debug.Log("testsus4");
            textMesh.text = "What a strange door, should I really Enter it ? ";
            options.Insert(4,openDoor);
            options.Remove(option4Start);
            stateManager.ShowDialogOptions(this, options);
            return;

        }else if(option.Equals(openDoor))//open door
        {
            stateManager.SwitchState(stateManager.backrooms_level1);

            return;
        }

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

        if(stateManager._sanity <= 0){
            stateManager.SwitchState(stateManager.infinite_Room1);
            Manager.Instance.PanelSanity.SetActive(false);
        }

    }
}
