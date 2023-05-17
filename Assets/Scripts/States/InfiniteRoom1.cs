using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfiniteRoom1 : BaseState
{
    private StateManager stateManager;
    private List<string> options;
    private TextMeshProUGUI textMesh;

    private TextMeshProUGUI SanityNumber;

    private float TimeElapsed = 0f;



    private string Introduction = ("You clipped trough the floor and landed in this Room, it looks twisted and chaotic, I hope there is a way out");

    private string option1Start = ("LEAVE ROOM");
    private string option2Start = ("LEAVE ROOM");  //reduce sanity
    private string option3Start = ("LEAVE ROOM "); //raises Sanity
    private string option4Start = ("LEAVE ROOM");




    public override void EnterState(StateManager state)
    {
        stateManager = state;
        textMesh = Manager.Instance.textMesh;
        SanityNumber = Manager.Instance.SanityNumber;
        SanityNumber.text = state._sanity.ToString();
        options = new List<string>();
        MP3Script.audioSource = AudioManager.Instance.sourceGlobal;



        AudioManager.Instance.sourceGlobal.volume = 0.0f;
        if (!AudioManager.Instance.sourceBackrooms.isPlaying)
        {
            AudioManager.Instance.sourceBackrooms.Play();
        }
        AudioManager.Instance.sourceBackrooms.volume = 0.8f;

        Manager.Instance.PanelSanity.SetActive(true);



        options.Add(option1Start);
        options.Add(option2Start);
        options.Add(option3Start);
        options.Add(option4Start);

        stateManager.ShowDialogOptions(this, options);

        Manager.Instance.backgroundImage.sprite = Manager.Instance.backgroundSprites[12];
        textMesh.text = Introduction;
        if(stateManager.infiniteRoomCount == 0)
        {
            AudioManager.Instance.sourceBackrooms.PlayOneShot(AudioManager.Instance.You, 2f);

        }else if(stateManager.infiniteRoomCount == 2)
        {
            AudioManager.Instance.sourceBackrooms.PlayOneShot(AudioManager.Instance.never, 2f);

        }else if(stateManager.infiniteRoomCount == 4)
        {
            AudioManager.Instance.sourceBackrooms.PlayOneShot(AudioManager.Instance.out_, 2f);

        }else if(stateManager.infiniteRoomCount == 6)
        {
            AudioManager.Instance.sourceBackrooms.PlayOneShot(AudioManager.Instance.here, 2f);

        }
    



    }

    public override void leaveState(StateManager state)
    {
        stateManager.infiniteRoomCount += 1;

    }

    public override void OptionClicked(int index, string option)
    {
        if(option.Equals(option1Start) || option.Equals(option2Start) || option.Equals(option3Start) || option.Equals(option4Start))
        {
            stateManager.SwitchState(stateManager.infinite_Room2);

        }
        Debug.Log(stateManager.infiniteRoomCount);


    }



    public override void UpdateState(StateManager state)
    {
        if (stateManager.isWearingBalenciaga && !Flash.Instance.flashing && !Flash.Instance.isInvoked)
        {
            float delay = Random.Range(3f, 10f);
            Debug.Log("Flash start with delay of " + delay);
            Flash.Instance.doFlashWithDelay(delay);

        }

        if (MP3Script.isPlaying)
        {
            AudioManager.Instance.sourceBackrooms.volume = 0.0f;
        }
        else
        {
            AudioManager.Instance.sourceBackrooms.volume = 0.2f;
        }
        
    }
}
