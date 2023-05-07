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
    private string option2Start = ("Start Paniccccc");  //reduce panic
    private string option3Start = ("Start Music because you are scared"); //raises Sanity
    private string option4Start = ("You can see a Door APPROACH IT");
    private string openDoor = ("Open Door");
    private string feelings = ("I Feel unconfortable");







    public override void EnterState(StateManager state)
    {
        stateManager = state;
        textMesh = Manager.Instance.textMesh;
        SanityNumber = Manager.Instance.SanityNumber;
        SanityNumber.text = state._sanity.ToString();
        options = new List<string>();


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

        stateManager.ShowDialogOptions(this, options);

        Manager.Instance.backgroundImage.sprite = Manager.Instance.backgroundSprites[7];
        textMesh.text = Introduction;



    }

    public override void leaveState(StateManager state)
    {

    }

    public override void OptionClicked(int index, string option)
    {
        if (option.Equals(option1Start))
        {
            Debug.Log("testSus");
            textMesh.text = "What a strange door, should I really Enter it ? ";




            return;

        }else if (option.Equals(option2Start))
        {
            Debug.Log("testSus2");


            return;
        }else if (option.Equals(option3Start))
        {
            Debug.Log("testSus3");
            AudioManager.Instance.sourceGlobal.volume = 0.0f;
            AudioManager.Instance.sourceBackrooms.clip = AudioManager.Instance.backRoomEntrance;
            AudioManager.Instance.sourceBackrooms.Play();
            AudioManager.Instance.sourceBackrooms.volume = 0.2f;


            return;

        }else if (option.Equals(option4Start))
        {
            Debug.Log("testsus4");
            textMesh.text = "What a strange door, should I really Enter it ? ";
            options.Add(openDoor);
            options.Remove(option4Start);
            stateManager.ShowDialogOptions(this, options);



            return;

        }

    }

    public override void UpdateState(StateManager state)
    {
        if (stateManager.isWearingBalenciaga && !Flash.Instance.flashing && !Flash.Instance.isInvoked)
        {
            float delay = Random.Range(0.02f, 1f);
            Debug.Log("Flash start with delay of " + delay);
            Flash.Instance.doFlashWithDelay(delay);
            
        }        

    }
}
