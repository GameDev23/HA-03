using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LecturehallEntrance : BaseState
{
    private StateManager stateManager;
    private List<string> options;
    private TextMeshProUGUI textMesh;

    private bool isWearingBalenciaga;
    private bool isDialog;
    private bool isArriving = true;

    
    private int dialogStep = 0;

    private string optionTakeASeat = "Take a seat";
    private string optionGoToToilet = "Go to the toilet to relief yourself once more";
    
    private string optionTalk1 = "...";
    private string optionTalk2 = "confirm it";
    private string optionTalk3 = "Accept the offer and take a seat afterwards";
    private string talkYes = "\"Thank you for noticing! Yes, I am wearing the latest Balenciaga collection,\nand let me tell you, it feels as innovative and daring as it looks." +
                             "\nWith its unique blend of cutting-edge design and timeless elegance, Balenciaga continues to push the boundaries of fashion and redefine what it means to be stylish.\nSo if you want to stay ahead of the curve and make a statement with your wardrobe, there's no better choice than Balenciaga\"  - you answerd";
    public override void EnterState(StateManager state)
    {
        textMesh = Manager.Instance.textMesh;
        options = new List<string>();
        stateManager = state;

        isWearingBalenciaga = state.isWearingBalenciaga;

        Manager.Instance.backgroundImage.sprite = Manager.Instance.backgroundSpritesDavid[0];
        AudioManager.Instance.sourceGlobal.clip = AudioManager.Instance.crowded;
        AudioManager.Instance.sourceGlobal.volume = AudioManager.Instance._Volume / 100;
        AudioManager.Instance.sourceGlobal.Play();

        // Didn't stab robbers
        if (isArriving && !stateManager.committedMurder)
        {
            // You arrive in the hall naked
            if (!stateManager.isWearingBalenciaga && !stateManager.isWearingClothes)
            {
                AudioManager.Instance.sourceGlobal.PlayOneShot(AudioManager.Instance.HallLaughing, 12.0f);
                textMesh.text = "Finally arrived naked infront of a crowd. \n   They laugh at you but you are here on a mission and can't afford to write the Nachreib. \n  Now take a seat and ace this exam";
                options.Add(optionTakeASeat);
                options.Add(optionGoToToilet);
            }

            // You arrive in the hall clothed
            else 
            {
                textMesh.text = "Finally arrived. Now take a seat and ace this exam";
                options.Add(optionTakeASeat);
                options.Add(optionGoToToilet);
            }
        }

        // Stabbed robbers
        else if (isArriving && stateManager.committedMurder)
        {
            // You arrive in the hall naked
            if (!stateManager.isWearingBalenciaga && !stateManager.isWearingClothes)
            {
                AudioManager.Instance.sourceGlobal.PlayOneShot(AudioManager.Instance.HallLaughing, 12.0f);
                AudioManager.Instance.sourceGlobal.PlayOneShot(AudioManager.Instance.HallGasping, 12.0f);
                textMesh.text = "Finally arrived naked infront of a crowd after commiting those atrocities. \n   They laugh at you and some gasp at the blood! \n But you are here on a mission and can't afford to write the Nachreib. \n Now take a seat and ace this exam";
                options.Add(optionTakeASeat);
                options.Add(optionGoToToilet);

            }

            // You arrive in the hall clothed
            else
            {
                AudioManager.Instance.sourceGlobal.PlayOneShot(AudioManager.Instance.HallGasping, 12.0f);
                textMesh.text = "Now after commiting those atrocities,  You are bloodied and people are in awe! \n But you are here on a mission and can't afford to write the Nachreib, \n Now take a seat and ace this exam";
                options.Add(optionTakeASeat);
                options.Add(optionGoToToilet);
            }
        }

        else if (isDialog)
        {
            if (dialogStep == 0)
            {
                textMesh.text = "Suddenly the professor approaches you";
                options.Add(optionTalk1);
            }
            else if (dialogStep == 1)
            {
                textMesh.text = "\"Excuse me, are you wearing the newest BALENCIAGA® collection?\nIt looks amazing!\" he said in a very jealous way";
                AudioManager.Instance.sourceGlobal.PlayOneShot(AudioManager.Instance.gibberish1, 2f);
                options.Add(optionTalk2);
            }
            else if (dialogStep == 2)
            {
                textMesh.text = talkYes;
                options.Add(optionTalk1);
            }
            else if (dialogStep == 3)
            {
                AudioManager.Instance.sourceGlobal.PlayOneShot(AudioManager.Instance.gibberish2, 2f);
                textMesh.text =
                    "He then offers to give you some bonus points for the exam if he can make some photos during the exam";
                options.Add(optionTalk3);
            }
        }
        stateManager.ShowDialogOptions(this, options);
    }

    public override void UpdateState(StateManager state)
    {
    }

    public override void OptionClicked(int index, string option)
    {
        if (option.Equals(optionTakeASeat))
        {
            if (isWearingBalenciaga && isArriving)
            {
                isDialog = true;
                isArriving = false;
                
                //initiate dialog scene
                stateManager.SwitchState(stateManager.lecturehallEntrance);
            }
            else
            {
                isDialog = false;
                stateManager.SwitchState(stateManager.lecturehallSeat);
            }
        } 
        else if (option.Equals(optionGoToToilet))
        {
            stateManager.SwitchState(stateManager.backrooms_entrance);
            return;
        }
        else if (option.Equals(optionTalk1) && dialogStep == 0)
        {
            dialogStep++;
            stateManager.SwitchState(stateManager.lecturehallEntrance);
        }
        else if (option.Equals(optionTalk2))
        {
            dialogStep++;
            stateManager.SwitchState(stateManager.lecturehallEntrance);

        }
        else if (option.Equals(optionTalk1) && dialogStep != 0)
        {
            dialogStep++;
            stateManager.SwitchState(stateManager.lecturehallEntrance);
        }
        else if (option.Equals(optionTalk3))
        {
            isDialog = false;
            stateManager.SwitchState(stateManager.lecturehallSeat);
        }
        
    }

    public override void leaveState(StateManager state)
    {
    }
}
