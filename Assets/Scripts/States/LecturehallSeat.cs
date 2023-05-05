using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LecturehallSeat : BaseState
{
    private StateManager stateManager;
    private List<string> options;
    private TextMeshProUGUI textMesh;

    private bool isWearingBalenciaga;
    private bool isIntro = true;
    private bool isPencilWindow = false;
    private bool isExamOver = false;
    private int questionNo = 0;
    private int examPoints = 0;
    private int pointsToPass = 76;

    private string optionStart = "start";

    private string question1 = "What is the dog doin?\na)\nb)\nc)\nd)";
    private string question2 = "What was the dog doin?\na)\nb)\nc)\nd)";
    private string question3 = "Tell me Y";
    private string question4 = "question4";
    private string question5 = "question5";
    private string question6 = "question6";
    private string question7 = "question7";
    
    public override void EnterState(StateManager state)
    {
        textMesh = Manager.Instance.textMesh;
        options = new List<string>();
        stateManager = state;

        isWearingBalenciaga = state.isWearingBalenciaga;
        Manager.Instance.backgroundImage.sprite = Manager.Instance.backgroundSpritesDavid[1];
        if(AudioManager.Instance.sourceGlobal.clip != AudioManager.Instance.examTheme)
        {
            AudioManager.Instance.sourceGlobal.clip = AudioManager.Instance.examTheme;
            AudioManager.Instance.sourceGlobal.Play();
        }

        if (!isExamOver)
        {
            if (isIntro)
            {
                textMesh.text = "Finally, you got the exam. Now start and do smart stuff";
                options.Add(optionStart);
            }
            else if (stateManager.pencilCount <= 0)
            {
                textMesh.text =  "Oh no.. you ran out of pens and you cant finish your exam..\nWhat a shame ... You cant handle the stress and instantly die on the spot...";
                options.Add("Q.Q");
            }
            else if (isPencilWindow)
            {
                options.Add("uff");
                decreasePencils();
                stateManager.ShowDialogOptions(this, options);
            }
            else if (questionNo == 0)
            {
                addOptions();
            }       
            else if (questionNo == 1)
            {
                textMesh.text = question2;
                addOptions();
            }
            else if (questionNo == 2)
            {
                textMesh.text = question3;
                addOptions();
            }        
            else if (questionNo == 3)
            {
                textMesh.text = question4;
                addOptions();
            }        
            else if (questionNo == 4)
            {
                textMesh.text = question5;
                addOptions();
            }
            else if (questionNo == 5)
            {
                textMesh.text = question6;
                addOptions();
            }
            else if (questionNo == 6)
            {
                textMesh.text = question7;
                addOptions();
            }
        }
        else
        {
            textMesh.text = "You achieved " + examPoints + " points\n";
            if (stateManager.isWearingBalenciaga)
            {
                examPoints += 10;
                textMesh.text +=
                    "Gladly you decided to wear your BALENCIAGA® so you got 10 bonus points, resulting in " +
                    (examPoints) + " points of 122";
            }

            if (examPoints < pointsToPass)
            {
                textMesh.text +=
                    "\nYou did not get enough points to pass this exam.\nWhat a shame ... You cant handle the stress and instantly die on the spot...";
                options.Add("die");
            }
            else
            {
                textMesh.text +=
                    "\nYou got enough points to pass this exam. Now go and live a happy life..\n\n (till the next exam)";
                options.Add("touch grass");
            }
        }
        
        state.ShowDialogOptions(this, options);
    }

    private void decreasePencils()
    {
        int pencilCount = stateManager.pencilCount;
        int rand = Random.Range(2, 7);
        if (pencilCount >= 20)
        {
            textMesh.text = "Oh no " + rand +
                            " of your pens just gave up..\nBut you still have countably infinite pens";
            return;
        }

        if (rand > pencilCount)
        {
            rand = pencilCount;
        }

        pencilCount -= rand;

            if (pencilCount == 0)
            {
                textMesh.text =
                    "Oh no.. you ran out of pens and you cant finish your exam..\nWhat a shame ... You cant handle the stress and instantly die on the spot...";
                options = new List<string>();
                options.Add("Q.Q");
                stateManager.ShowDialogOptions(this, options);
            }
            else
            {
                stateManager.pencilCount -= rand;
                textMesh.text = "Oh no.. " + rand + " of your pens just gave up.\nLucky you, you still have " +
                                pencilCount + " pens";
            }
        

    }
    

    public override void UpdateState(StateManager state)
    {
        if (isWearingBalenciaga && !Flash.Instance.flashing && !Flash.Instance.isInvoked)
        {
            float delay = Random.Range(2f, 7f);
            Debug.Log("Flash start with delay of " + delay);
            Flash.Instance.doFlashWithDelay(delay);
        }
    }

    public override void OptionClicked(int index, string option)
    {
        if (option.Equals("die"))
        {
            stateManager.SwitchState(stateManager.endingDead);
            return;
        }
        
        if (option.Equals("Q.Q"))
        {
            Debug.Log("Arrived here");
            stateManager.SwitchState(stateManager.endingDead);
            return;
        }
        if (isPencilWindow)
        {
            isPencilWindow = false;
            stateManager.SwitchState(stateManager.lecturehallSeat);
            return;
        }

        if (option.Equals("touch grass"))
        {
            Debug.Log("Implement win screen here");
            //TODO
        }

        if (isIntro)
        {
            if (option.Equals(optionStart) && stateManager.pencilCount < 1)
            {
                textMesh.text = "You forgot to take a pen... What a shame ... You cant handle the stress and instantly die on the spot...";
                options = new List<string>();
                options.Add("die");
                stateManager.ShowDialogOptions(this, options);
            }
            else if (option.Equals(optionStart))
            {
                isIntro = false;
                options = new List<string>();
                Manager.Instance.textMesh.text = question1;
                addOptions();
            }
        }
        else if(questionNo == 0)
        {
            if (option.Equals("a)"))
            {
                examPoints += 16;
            }

            questionNo++;
            isPencilWindow = true;
            stateManager.SwitchState(stateManager.lecturehallSeat);
            return;
        }        
        else if(questionNo == 1)
        {
            if (option.Equals("a)"))
            {
                examPoints += 16;
            }

            questionNo++;
            isPencilWindow = true;
            stateManager.SwitchState(stateManager.lecturehallSeat);
            return;
        }
        else if(questionNo == 2)
        {
            if (option.Equals("a)"))
            {
                examPoints += 16;
            }

            questionNo++;
            isPencilWindow = true;
            stateManager.SwitchState(stateManager.lecturehallSeat);
            return;
        }
        else if(questionNo == 3)
        {
            if (option.Equals("a)"))
            {
                examPoints += 16;
            }

            questionNo++;
            isPencilWindow = true;
            stateManager.SwitchState(stateManager.lecturehallSeat);
            return;
        }
        else if(questionNo == 4)
        {
            if (option.Equals("a)"))
            {
                examPoints += 16;
            }

            questionNo++;
            isPencilWindow = true;
            stateManager.SwitchState(stateManager.lecturehallSeat);
            return;
        }
        else if(questionNo == 5)
        {
            if (option.Equals("a)"))
            {
                examPoints += 16;
            }

            questionNo++;
            isPencilWindow = true;
            stateManager.SwitchState(stateManager.lecturehallSeat);
            return;
        }
        else if(questionNo == 6)
        {
            if (option.Equals("a)"))
            {
                examPoints += 16;
            }

            //TODO tell points and make end screen
            isExamOver = true;
            stateManager.SwitchState(stateManager.lecturehallSeat);
            return;
        }

        if (option.Equals("uff"))
        {
            isPencilWindow = false;
            stateManager.SwitchState(stateManager.lecturehallSeat);
            return;
        }
        stateManager.ShowDialogOptions(this, options);
    }

    public override void leaveState(StateManager state)
    {
    }

    private void addOptions()
    {
        options.Add("a)");
        options.Add("b)");
        options.Add("c)");
        options.Add("d)");
    }
}
