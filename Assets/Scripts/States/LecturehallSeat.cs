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
    private float examPoints = 0;
    private float pointsToPass = 80f;
    private float pointsPerCorrectAnswer = 8.5f;

    private string optionStart = "start";

    private string question1 = "If a tree falls in the forest and no one is around to hear it, does it make a sound?\na) Yes\nb) No\nc) Only if a squirrel is there to witness it\nd) It depends on the type of tree";
    private string question2 = "Which of the following is NOT a type of cheese?\na) Cheddar\nb) Gouda\nc) Pikachu\nd) Brie";
    private string question3 = "What is the most important key on a keyboard?\na) The space bar\nb) The delete key\nc) The shift key\nd) The any key";
    private string question4 = "What is the best way to solve a difficult math problem?\na) Crying\nb) Giving up\nc) Asking for help\nd) Taking a nap";
    private string question5 = "A discrete random variable can take on which type of values?\na) Only integer values\nb) Only real values\nc) Both integer and real values\nd) None of the above";
    private string question6 = "What is the expected value of a discrete random variable X?\na) The square root of the sum of all possible values of X\nb) The sum of all possible values of X divided by the number of values\nc) The maximum value of X\nd) The minimum value of X";
    private string question7 = "What is the formula for Bayes' Theorem?\na) P(A|B) = P(A) + P(B) - P(A and B)\nb) P(A|B) = P(B|A) * P(A) / P(B)\nc) P(A and B) = P(A) * P(B)\nd) P(A and B) = P(A) + P(B) - P(A|B)";
    private string question8 = "How many slaps does it take to cook a chicken?\na) 1,230,121\nb) 69,420\nc) 23,034\nd) 24";

    private string question9 = "What is the airspeed velocity of an unladen swallow?\na) African or European?\nb) 42\nc) 3.14\nd) None of the above";

    private string question10 = "When the code finally works after hours of debugging, what do you do?\na) Celebrate with a victory dance\nb) Take a screenshot and post it on social media\nc) Keep quiet and move on to the next task\nd) Go home and take a nap";

    private string question11 =
        "If you shuffle a deck of cards, what is the probability that the cards are in the exact same order as they were before shuffling?\na) 1 in 52!\nb) 1 in 52\nc) 1 in 2\nd) 1 in 1,235,786,432";

    private string question12 = "What is the best way to impress your computer science professor?\na) Use complex terminology and buzzwords\nb) Code a project from scratch\nc) Bring them coffee every day\nd) Use memes in your presentations";
    
    
    
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
            AudioManager.Instance.sourceGlobal.volume = 0.2f;
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
            else if (questionNo == 7)
            {
                textMesh.text = question8;
                addOptions();
            }           
            else if (questionNo == 8)
            {
                textMesh.text = question9;
                addOptions();
            }            
            else if (questionNo == 9)
            {
                textMesh.text = question10;
                addOptions();
            }            
            else if (questionNo == 10)
            {
                textMesh.text = question11;
                addOptions();
            }            
            else if (questionNo == 11)
            {
                textMesh.text = question12;
                addOptions();
            }            

            
        }
        else
        {
            textMesh.text = "You achieved " + examPoints + " points of 102 (112 with bonus points)\n";
            if (stateManager.isWearingBalenciaga)
            {
                examPoints += 10;
                textMesh.text +=
                    "Gladly you decided to wear your BALENCIAGA® so you got 10 bonus points, resulting in " +
                    (examPoints);
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
        int rand = Random.Range(1, 4);
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
            //
            stateManager.SwitchState(stateManager.endingPassed);

            return;
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
            if (option.Equals("d)"))
            {
                examPoints += pointsPerCorrectAnswer;
                AudioManager.Instance.sourceGlobal.PlayOneShot(AudioManager.Instance.rightChoice, AudioManager.Instance._Volume);
            }
            else
            {
                AudioManager.Instance.sourceGlobal.PlayOneShot(AudioManager.Instance.wrongChoice, AudioManager.Instance._Volume);
            }

            questionNo++;
            isPencilWindow = true;
            stateManager.SwitchState(stateManager.lecturehallSeat);
            return;
        }        
        else if(questionNo == 1)
        {
            if (option.Equals("c)"))
            {
                examPoints += pointsPerCorrectAnswer;
                AudioManager.Instance.sourceGlobal.PlayOneShot(AudioManager.Instance.rightChoice, AudioManager.Instance._Volume);
            }
            else
            {
                AudioManager.Instance.sourceGlobal.PlayOneShot(AudioManager.Instance.wrongChoice, AudioManager.Instance._Volume);
            }

            questionNo++;
            isPencilWindow = true;
            stateManager.SwitchState(stateManager.lecturehallSeat);
            return;
        }
        else if(questionNo == 2)
        {
            if (option.Equals("d)"))
            {
                examPoints += pointsPerCorrectAnswer;
                AudioManager.Instance.sourceGlobal.PlayOneShot(AudioManager.Instance.rightChoice, AudioManager.Instance._Volume);
            }
            else
            {
                AudioManager.Instance.sourceGlobal.PlayOneShot(AudioManager.Instance.wrongChoice, AudioManager.Instance._Volume);
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
                examPoints += pointsPerCorrectAnswer;
                AudioManager.Instance.sourceGlobal.PlayOneShot(AudioManager.Instance.rightChoice, AudioManager.Instance._Volume);
            }
            else
            {
                AudioManager.Instance.sourceGlobal.PlayOneShot(AudioManager.Instance.wrongChoice, AudioManager.Instance._Volume);
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
                examPoints += pointsPerCorrectAnswer;
                AudioManager.Instance.sourceGlobal.PlayOneShot(AudioManager.Instance.rightChoice, AudioManager.Instance._Volume);
            }
            else
            {
                AudioManager.Instance.sourceGlobal.PlayOneShot(AudioManager.Instance.wrongChoice, AudioManager.Instance._Volume);
            }

            questionNo++;
            isPencilWindow = true;
            stateManager.SwitchState(stateManager.lecturehallSeat);
            return;
        }
        else if(questionNo == 5)
        {
            if (option.Equals("b)"))
            {
                examPoints += pointsPerCorrectAnswer;
                AudioManager.Instance.sourceGlobal.PlayOneShot(AudioManager.Instance.rightChoice, AudioManager.Instance._Volume);
            }
            else
            {
                AudioManager.Instance.sourceGlobal.PlayOneShot(AudioManager.Instance.wrongChoice, AudioManager.Instance._Volume);
            }

            questionNo++;
            isPencilWindow = true;
            stateManager.SwitchState(stateManager.lecturehallSeat);
            return;
        }
        else if(questionNo == 6)
        {
            if (option.Equals("b)"))
            {
                examPoints += pointsPerCorrectAnswer;
                AudioManager.Instance.sourceGlobal.PlayOneShot(AudioManager.Instance.rightChoice, AudioManager.Instance._Volume);
            }
            else
            {
                AudioManager.Instance.sourceGlobal.PlayOneShot(AudioManager.Instance.wrongChoice, AudioManager.Instance._Volume);
            }
            questionNo++;
            isPencilWindow = true;
            stateManager.SwitchState(stateManager.lecturehallSeat);
            return;
        }        
        else if(questionNo == 7)
        {
            if (option.Equals("c)"))
            {
                examPoints += pointsPerCorrectAnswer;
                AudioManager.Instance.sourceGlobal.PlayOneShot(AudioManager.Instance.rightChoice, AudioManager.Instance._Volume);
            }
            else
            {
                AudioManager.Instance.sourceGlobal.PlayOneShot(AudioManager.Instance.wrongChoice, AudioManager.Instance._Volume);
            }

            questionNo++;
            isPencilWindow = true;
            stateManager.SwitchState(stateManager.lecturehallSeat);
            return;
        }         
        else if(questionNo == 8)
        {
            if (option.Equals("a)"))
            {
                examPoints += pointsPerCorrectAnswer;
                AudioManager.Instance.sourceGlobal.PlayOneShot(AudioManager.Instance.rightChoice, AudioManager.Instance._Volume);
            }
            else
            {
                AudioManager.Instance.sourceGlobal.PlayOneShot(AudioManager.Instance.wrongChoice, AudioManager.Instance._Volume);
            }

            questionNo++;
            isPencilWindow = true;
            stateManager.SwitchState(stateManager.lecturehallSeat);
            return;
        }           
        else if(questionNo == 9)
        {
            if (option.Equals("c)"))
            {
                examPoints += pointsPerCorrectAnswer;
                AudioManager.Instance.sourceGlobal.PlayOneShot(AudioManager.Instance.rightChoice, AudioManager.Instance._Volume);
            }
            else
            {
                AudioManager.Instance.sourceGlobal.PlayOneShot(AudioManager.Instance.wrongChoice, AudioManager.Instance._Volume);
            }

            questionNo++;
            isPencilWindow = true;
            stateManager.SwitchState(stateManager.lecturehallSeat);
            return;
        }   
        
        else if(questionNo == 10)
        {
            if (option.Equals("a)"))
            {
                examPoints += pointsPerCorrectAnswer;
                AudioManager.Instance.sourceGlobal.PlayOneShot(AudioManager.Instance.rightChoice, AudioManager.Instance._Volume);
            }
            else
            {
                AudioManager.Instance.sourceGlobal.PlayOneShot(AudioManager.Instance.wrongChoice, AudioManager.Instance._Volume);
            }

            questionNo++;
            isPencilWindow = true;
            stateManager.SwitchState(stateManager.lecturehallSeat);
            return;
        }        
        else if(questionNo == 11)
        {
            if (option.Equals("d)"))
            {
                examPoints += pointsPerCorrectAnswer;
                AudioManager.Instance.sourceGlobal.PlayOneShot(AudioManager.Instance.rightChoice, AudioManager.Instance._Volume);
            }
            else
            {
                AudioManager.Instance.sourceGlobal.PlayOneShot(AudioManager.Instance.wrongChoice, AudioManager.Instance._Volume);
            }

            //tell points and make end screen
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
