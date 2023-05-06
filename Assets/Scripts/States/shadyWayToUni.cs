using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class shadyWayToUni : BaseState
{
    private StateManager stateManager;
    private List<string> options;
    private TextMeshProUGUI textMesh;
    private int currentScene = 0;
    private bool wantPray = false;
    private bool wantBribe = false;
    private bool wantFight = false;
    private bool bottlesOffered = false;

    private string goToExam = "Proceed";
    private string goToHell = "Proceed";

    // Risk it or go back
    private string samwellTarly = "I'm not risking it. Going back";
    private string serBarristanSelmy = "With my Balenciaga®  on, I am unstoppable!! Time for a Quick duel before exams";

    // options in robbery
    private string bribe = "pay them off";
    private string fight = "my Mama didn't raise a coward";
    private string pray = "summon the gods of the RUB to your aid";

    private string offerBottles = "offer bottles";

    public override void EnterState(StateManager state)
    {
        //Simplificiation in writing
        stateManager = state;
        textMesh = Manager.Instance.textMesh;
        options = new List<string>();
        AudioManager.Instance.sourceGlobal.volume = 0; //muting the global
        AudioManager.Instance.sourceSamwel.volume = 0.15f; //enabled my speaker 
        AudioManager.Instance.sourceSamwel.clip = AudioManager.Instance.tenseRob;

        if (!AudioManager.Instance.sourceSamwel.isPlaying) 
        {
            AudioManager.Instance.sourceSamwel.Play();
        }
        
        
        Manager.Instance.backgroundImage.sprite = Manager.Instance.samwelSprites[3];
    

        if (currentScene == 0)
        {
            options.Add(serBarristanSelmy);
            options.Add(samwellTarly);
            state.ShowDialogOptions(this, options);
            textMesh.text = "You notice a shady figure in the far distance.....";
        }

        else if(currentScene == 1) 
        {
            options.Add(pray);
            options.Add(fight);
            options.Add(bribe);
            state.ShowDialogOptions(this, options);
            textMesh.text = "You are getting robbed!";
        }

        else if (currentScene == 2)
        {
            int survivalChance = Random.Range(1, 3);

            // Praying for your survival
            if (wantPray)
            {
                // Not enough god power
                if (survivalChance == 1)
                {
                    options.Add(goToHell);
                    state.ShowDialogOptions(this, options);
                    textMesh.text = "The gods abandon you and you perish...maybe you should sacrifice more often";
                }

                // the góds have heard you
                else
                {
                    options.Add(goToExam);
                    state.ShowDialogOptions(this, options);
                    AudioManager.Instance.sourceSamwel.PlayOneShot(AudioManager.Instance.thunder, 4.0f);
                    textMesh.text = "The gods of the Ruhr have heard you!  \n The robbers are struc by lightning and die \n You can proceed to the exam...";
                }
            }

            // Fighting for your survival
            else if (wantFight)
            {
                if (!stateManager.hasKnife)
                {
                    options.Add(goToHell);
                    state.ShowDialogOptions(this, options);
                    AudioManager.Instance.sourceSamwel.PlayOneShot(AudioManager.Instance.beaten, 4.0f);
                    textMesh.text = "Oh no!... you forgot your knife back at home \n the robbers rob the hell out of you and beat you to death \n Game over!";
                }

                else
                {
                    options.Add(goToExam);
                    state.ShowDialogOptions(this, options);
                    textMesh.text = "You fend off the robbers with your knife and by the help of you magical Balenciaga®\n They shouldn't have messed with you ";
                }

            }

            // Bribing for your survival
            else if (wantBribe)
            {
                // You habe enough money
                if (stateManager.cash >= 20.0f)
                {
                    options.Add(goToExam);
                    state.ShowDialogOptions(this, options);
                    textMesh.text = "You bribe the robbers off with the cash you collected from the bottles\n Thank god for the Pfandgesetzgebung ";
                }

                //No enough money
                else
                {
                    if (stateManager.pfandFlaschenCount >= 25)
                    {
                        // Offer bottles
                        options.Add(offerBottles);
                        state.ShowDialogOptions(this, options);
                        textMesh.text = "Ooops! You didn't collect enough money from the Pfandflaschen \n Maybe the robbers have a <color=yellow>Pfandflaschengerät</color>...";
                    }
                    else
                    {
                        options.Add(goToHell);
                        state.ShowDialogOptions(this, options);
                        AudioManager.Instance.sourceSamwel.PlayOneShot(AudioManager.Instance.beaten, 4.0f);
                        textMesh.text = "The robbers take insult in your offering of such little money \n They rob, bit you and leave you for dead";
                    }
                }

            }

            else if (bottlesOffered) 
            {
                // Chance that robbers have the Pfandflaschengerät
                int rnd = Random.Range(1, 3);

                if (rnd == 1)
                {
                    options.Add(goToExam);
                    state.ShowDialogOptions(this, options);
                    textMesh.text = "The robbers happen to have a Pfandflaschengerät \n offered all your bottles for your life! \n You are free to go to the exam ";
                }
                else 
                {
                    options.Add(goToHell);
                    state.ShowDialogOptions(this, options);
                    AudioManager.Instance.sourceSamwel.PlayOneShot(AudioManager.Instance.beaten, 4.0f);
                    textMesh.text = "What kind of ridiculous question is that?! They're robbers not your friendly neighborhood Bottle collected \n They rob, bit you and leave you for dead";
                }

            }

        }

    }

    public override void leaveState(StateManager state)
    {
        AudioManager.Instance.sourceGlobal.volume = 1.0f; //muting the global
        AudioManager.Instance.sourceSamwel.volume = 0; //enabled my speaker 
    }

    public override void OptionClicked(int index, string option)
    {
        // Scene 1 options
        if (option.Equals(samwellTarly)) 
        {
            stateManager.SwitchState(stateManager.leavingHouse);
            return;
        }

        if (option.Equals(serBarristanSelmy)) 
        {
            currentScene += 1;
            stateManager.SwitchState(stateManager.shadyWay);
            return;
        }

        //Scene 2 options
        if (option.Equals(pray)) 
        {
            wantPray = true;
            currentScene += 1;
            stateManager.SwitchState(stateManager.shadyWay);
        }

        if (option.Equals(fight))
        {
            wantFight = true;
            currentScene += 1;
            stateManager.SwitchState(stateManager.shadyWay);
        }

        if (option.Equals(bribe))
        {
            wantBribe = true;
            currentScene += 1;
            stateManager.SwitchState(stateManager.shadyWay);
        }

        // Going to exam
        if (option.Equals(goToExam))
        {
            stateManager.SwitchState(stateManager.exam);
        }

        // Dieing
        if (option.Equals(goToHell))
        {
            stateManager.SwitchState(stateManager.dead);
        }


    }

    public override void UpdateState(StateManager state)
    {

    }
}
