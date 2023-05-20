using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NormalWay : BaseState
{
    private StateManager stateManager;
    private List<string> options;
    private TextMeshProUGUI textMesh;
    private string goToExam = "proceed";
    private string goBackHome = "return home";
    private string optionRunFast = "Run as fast as you can to dodge them <color=yellow>Naruto style</color>  <color=red>(Dangerous)</color>";
    private string optionGoArround = "Make a big (real big) sidestep to avoid eye contact  <color=green>(Safe)</color>";
    private string optionProceed = "Uff..";
    private GameObject Dragon;
    private int currentScene = 0;

    public override void EnterState(StateManager state)
    {

        if (currentScene == 0)
        {
            //Simplificiation in writing
            Dragon = Manager.Instance.Dragon; // reference to the dragon
            Manager.Instance.Dragon.SetActive(true);
            AudioManager.Instance.sourceGlobal.PlayOneShot(AudioManager.Instance.DragonRoar,  2.0f);
            stateManager = state;
            textMesh = Manager.Instance.textMesh;
            options = new List<string>();
            Manager.Instance.backgroundImage.sprite = Manager.Instance.backgroundSprites[1];
            options.Add(goToExam);
            options.Add(goBackHome);
            state.ShowDialogOptions(this, options);
            textMesh.text = "What a lovely day at the RUB today. Is that cloud shaped like a dragon? I better get to my exam";
        } else if (currentScene == 1)
        {
            //Shady persons approach you
            Manager.Instance.backgroundImage.sprite = Manager.Instance.backgroundSpritesDavid[5];
            textMesh.text =
                "Suddenly you realize that there is a survey booth on your left\nand there is a person approaching you to collect your money\nAct fast now!";
            options = new List<string>();
            options.Add(optionRunFast);
            options.Add(optionGoArround);
            stateManager.ShowDialogOptions(this, options);

        }

    }

    public override void leaveState(StateManager state)
    {
        Manager.Instance.Dragon.SetActive(false);
    }

    public override void OptionClicked(int index, string option)
    {
        //  Switchiing state
        if (option.Equals(goToExam))
        {
            
            currentScene = 1;
            stateManager.SwitchState(stateManager.normalWay);
            return;
        }

        if (option.Equals(goBackHome))
        {
            currentScene = 0;
            stateManager.SwitchState(stateManager.leavingHouse);    
            return;
        }
        
        if (option.Equals(optionGoArround))
        {
            stateManager.SwitchState(stateManager.lecturehallEntrance);
            return;
        }

        if (option.Equals(optionRunFast))
        {
            textMesh.text =
                "You dodged them like you were the hokage himself,\nUnfortunately you stepped on a sturdy <color=grey>BETONBODENPLATTE©</color> which collapsed and transported you into P7";
            AudioManager.Instance.sourceGlobal.PlayOneShot(AudioManager.Instance.collapse, 1f);
            AudioManager.Instance.sourceGlobal.PlayOneShot(AudioManager.Instance.BodenplattenOST, 5f);
            options = new List<string>();
            options.Add(optionProceed);
            stateManager.ShowDialogOptions(this, options);
            return;
        }

        if (option.Equals(optionProceed))
        {
            stateManager.SwitchState(stateManager.backrooms_entrance);
            return;
        }


    }

    public override void UpdateState(StateManager state)
    {
        Dragon.transform.position += Vector3.right * Time.deltaTime * 4.0f;
    }
}
