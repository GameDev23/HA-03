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
    private bool offeredThemCash = false;
    private GameObject Thug;

    private string goToExam = "Proceed";
    private string goToHell = "Proceed..";

    // Risk it or go back
    private string samwellTarly = "I'm not risking it. Going back";
    private string serBarristanSelmy = " \"With my Balenciaga®  on, I am unstoppable!! Time for a Quick duel before exams...\" ";
    private string serNormal = " \"I may be dressed like a peasant, but I have a knight's heart...\" ";
    private string athena = " \"The Berserker's fought naked, and today you will know why...\" ";


    // options in robbery
    private string bribe = "pay them off";
    private string fight = "my Mama didn't raise a coward";
    private string pray = "summon the gods of the RUB to your aid";

    private string offerCash = "offer Money";
    private string offerBottles = "offer bottles";


    public override void EnterState(StateManager state)
    {
        Thug = Manager.Instance.AlleyThug; // reference to the the robber
        Manager.Instance.AlleyThug.SetActive(true);

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
            // Wearing Balenciaga®
            if (stateManager.isWearingBalenciaga)
            {
                options.Add(serBarristanSelmy);
                options.Add(samwellTarly);
                state.ShowDialogOptions(this, options);
                AudioManager.Instance.sourceSamwel.PlayOneShot(AudioManager.Instance.Gabagoey, 2.0f);
                textMesh.text = " \"Nice outfit lad, shame if something were to happen to them...\" ";
            }

            // Wearing normal clothes
            else if (stateManager.isWearingClothes)
            {
                options.Add(serNormal);
                options.Add(samwellTarly);
                state.ShowDialogOptions(this, options);
                AudioManager.Instance.sourceSamwel.PlayOneShot(AudioManager.Instance.Gabagoey, 2.0f);
                textMesh.text = " \"Hand over your peasant rags and everything you have lad!\" ";
            }

            // Naked
            else 
            {
                options.Add(athena);
                options.Add(samwellTarly);
                state.ShowDialogOptions(this, options);
                AudioManager.Instance.sourceSamwel.PlayOneShot(AudioManager.Instance.Gabagoey, 2.0f);
                textMesh.text = " \"In my years of robbing, this is a first! A naked poor scoundrel...\" ";
            }

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
                if (!stateManager.isWearingClothes && !stateManager.isWearingBalenciaga)
                {
                    options.Add(goToExam);
                    state.ShowDialogOptions(this, options);
                    AudioManager.Instance.sourceSamwel.PlayOneShot(AudioManager.Instance.Holiness, 4.0f);
                    AudioManager.Instance.sourceSamwel.PlayOneShot(AudioManager.Instance.thunder, 4.0f);
                    textMesh.text = " The gods favor you since you embrace your natural form and not cover yourself in abominations. \n The robbers are struck by lightning and die! \n You can proceed to the exam...";
                }

                // Not enough god power
                else if (survivalChance == 1)
                {
                    options.Add(goToHell);
                    state.ShowDialogOptions(this, options);
                    textMesh.text = "The gods abandon you and you perish...It is said, they favor people who embace their natural form...";
                }

                // the góds have heard you
                else
                {
                    options.Add(goToExam);
                    state.ShowDialogOptions(this, options);
                    AudioManager.Instance.sourceSamwel.PlayOneShot(AudioManager.Instance.thunder, 4.0f);
                    textMesh.text = "The gods of the Ruhr have heard you!  \n The robbers are struck by lightning and die \n You can proceed to the exam...";
                }
            }

            // Fighting for your survival
            else if (wantFight)
            {
                // Has no knife
                if (!stateManager.hasKnife)
                {
                    options.Add(goToHell);
                    state.ShowDialogOptions(this, options);
                    AudioManager.Instance.sourceSamwel.PlayOneShot(AudioManager.Instance.beaten, 4.0f);
                    textMesh.text = "Oh no!... you forgot your knife back at home. \n the robbers rob the hell out of you and beat you to death \n Game over!";
                }

                // Has knife
                else
                {
                    if (stateManager.isWearingBalenciaga)
                    {
                        options.Add(goToExam);
                        state.ShowDialogOptions(this, options);
                        AudioManager.Instance.sourceSamwel.PlayOneShot(AudioManager.Instance.StabStab, 4.0f);
                        AudioManager.Instance.sourceSamwel.PlayOneShot(AudioManager.Instance.Scream, 4.0f);
                        stateManager.committedMurder = true;
                        textMesh.text = "You fend off the robbers with your knife and by the help of you magical Balenciaga®. \n They shouldn't have messed with you! ";
                    }

                    else if (stateManager.isWearingClothes)
                    {
                        options.Add(goToExam);
                        state.ShowDialogOptions(this, options);
                        AudioManager.Instance.sourceSamwel.PlayOneShot(AudioManager.Instance.StabStab, 4.0f);
                        AudioManager.Instance.sourceSamwel.PlayOneShot(AudioManager.Instance.Scream, 4.0f);
                        stateManager.committedMurder = true;
                        textMesh.text = "You fend off the robbers with your knife. \n They shouldn't have messed with you! ";
                    }

                    else if (!stateManager.isWearingClothes && !stateManager.isWearingBalenciaga) 
                    {
                        options.Add(goToExam);
                        state.ShowDialogOptions(this, options);
                        AudioManager.Instance.sourceSamwel.PlayOneShot(AudioManager.Instance.StabStab, 4.0f);
                        AudioManager.Instance.sourceSamwel.PlayOneShot(AudioManager.Instance.Scream, 4.0f);
                        AudioManager.Instance.sourceSamwel.PlayOneShot(AudioManager.Instance.Holiness, 4.0f);
                        AudioManager.Instance.sourceSamwel.PlayOneShot(AudioManager.Instance.thunder, 4.0f);
                        stateManager.committedMurder = true;
                        textMesh.text = "You fend off the robbers with your knife and the gods assist you with a thunder strike since you embrace your natural form. \n They shouldn't have messed with you!";
                    }

                }

            }

            // Bribing for your survival
            else if (wantBribe)
            {
                // You habe enough money and bottles
                if (stateManager.cash >= 5.0f && stateManager.pfandFlaschenCount >= 20)
                {
                    options.Add(offerBottles);
                    options.Add(offerCash);
                    state.ShowDialogOptions(this, options);
                    textMesh.text = "You have some merchandise, what do you choose to offer?";
                }

                //  Only enough money
                else if (stateManager.cash >= 5.0f)
                {
                    options.Add(offerCash);
                    state.ShowDialogOptions(this, options);
                    textMesh.text = "You have spare cash to offer a bribe...";
                }

                // Only enough bottles
                else if (stateManager.pfandFlaschenCount >= 20)
                {
                    Debug.Log("Has enought bottles to pay robber of");
                    options.Add(offerBottles);
                    state.ShowDialogOptions(this, options);
                    textMesh.text = "Maybe the robbers have a <color=yellow>Pfandflaschengerät</color>...";
                }

                // Not enough money or bottles
                else
                {
                    options.Add(goToHell);
                    AudioManager.Instance.sourceSamwel.PlayOneShot(AudioManager.Instance.Scream, 4.0f);
                    AudioManager.Instance.sourceSamwel.PlayOneShot(AudioManager.Instance.Holiness, 4.0f);
                    AudioManager.Instance.sourceSamwel.PlayOneShot(AudioManager.Instance.thunder, 4.0f);
                    state.ShowDialogOptions(this, options);
                    AudioManager.Instance.sourceSamwel.PlayOneShot(AudioManager.Instance.beaten, 4.0f);
                    textMesh.text = "You don't have enough money to bribe! \n The robbers bit you and leave you for dead. \n However, the gods like that you embrace your natural form. \n They strike the robbers down with thunder so they die too...bittersweet";
                }

            }

        }


        else if (currentScene == 3)
        {
            if (bottlesOffered)
            {
                options.Add(goToExam);
                state.ShowDialogOptions(this, options);
                textMesh.text = "The robbers happen to have a <color=yellow>Pfandflaschengerät</color> \n and take all your bottles for your life! \n You are free to go to the exam ";
            }

            else if (offeredThemCash)
            {
                options.Add(goToExam);
                state.ShowDialogOptions(this, options);
                textMesh.text = "You bribe the robbers off with the cash you collected from the bottles. \n Thank god for the Pfandgesetzgebung!";
            }

        }


    }

    public override void leaveState(StateManager state)
    {
        AudioManager.Instance.sourceGlobal.volume = 1.0f; //muting the global
        AudioManager.Instance.sourceSamwel.volume = 0; //enabled my speaker 
        Thug.SetActive(false);
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

        if (option.Equals(serNormal))
        {
            currentScene += 1;
            stateManager.SwitchState(stateManager.shadyWay);
            return;
        }

        if (option.Equals(athena))
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
            return;
        }

        if (option.Equals(fight))
        {
            wantFight = true;
            currentScene += 1;
            stateManager.SwitchState(stateManager.shadyWay);
            return;
        }

        if (option.Equals(bribe))
        {
            wantBribe = true;
            currentScene += 1;
            stateManager.SwitchState(stateManager.shadyWay);
            return;
        }

        // Scene 3 options
        if (option.Equals(offerBottles))
        { 
            Debug.Log("Option 6");
            bottlesOffered = true;
            AudioManager.Instance.sourceSamwel.PlayOneShot(AudioManager.Instance.barcodeScanner, 1f);
            AudioManager.Instance.sourceSamwel.PlayOneShot(AudioManager.Instance.cashRegister, 1f);
            currentScene += 1;
            stateManager.SwitchState(stateManager.shadyWay);
            return;
        }

        if (option.Equals(offerCash)) 
        {
            offeredThemCash = true;
            currentScene += 1;
            stateManager.SwitchState(stateManager.shadyWay);
            return;
        }

        // Going to exam
        if (option.Equals(goToExam))
        {
            stateManager.SwitchState(stateManager.lecturehallEntrance);
            return;
        }

        // Dieing
        if (option.Equals(goToHell))
        {
            stateManager.SwitchState(stateManager.endingDead);
            return;
        }


    }

    public override void UpdateState(StateManager state)
    {

    }
}
