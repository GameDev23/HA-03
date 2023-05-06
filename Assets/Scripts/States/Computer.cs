using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Computer : BaseState
{ 
    private StateManager stateManager;
    private List<string> options;
    private TextMeshProUGUI textMesh;


    private string optionBack;
    private string optionInstallPfand = "Plug the <color=yellow>Pfandflaschengerät</color> in";
    private string optionPencil;
    private string optionInstallDriver = "Install drivers";
    private string optionWaitForDrivers = "wait for the drivers to install..";
    private string optionPutInPfand = "Put some Pfand into the <color=yellow>Pfandflaschengerät</color>";

    private int installSteps = 0;
    private int waitCount = 0;
    
    public override void EnterState(StateManager state)
    {
        textMesh = Manager.Instance.textMesh;
        options = new List<string>();
        stateManager = state;
        Manager.Instance.backgroundImage.sprite = Manager.Instance.backgroundSprites[3];
        optionPencil = "Take a pen";
        optionBack = "leave";
        if(!(stateManager.pencilCount >= 20))
            options.Add(optionPencil);
        
        if (stateManager.hasCollectedPfandflaschengeraet && !stateManager.hasInstalledPfandflaschengeraet)
        {
            Debug.Log("Reached " + installSteps + "  " + waitCount);
            
            switch (installSteps)
            {
                case 0:
                    options.Add(optionInstallPfand);
                    break;
                case 1:
                    options.Add(optionInstallDriver);
                    break;
            }

            if (installSteps >= 2 && waitCount < 7)
            {
                options.Add(optionWaitForDrivers);
            }
            else if (waitCount >= 7)
            {
                options.Add(optionPutInPfand);
            }
        }
        
        
        if(stateManager.hasInstalledPfandflaschengeraet)
            options.Add(optionPutInPfand);
        options.Add(optionBack);
        
        state.ShowDialogOptions(this, options);
    }

    public override void UpdateState(StateManager state)
    {

    }

    public override void OptionClicked(int index, string option)
    {
        if (option.Equals(optionBack))
        {
            stateManager.SwitchState(stateManager.zuhause);
        }

        if (option.Equals(optionPencil))
        {
            stateManager.pencilCount++;
            switch (stateManager.pencilCount)
            {
                case 1:
                    textMesh.text = "You have a pen now.\nIt would have been a disaster if you forgot the pen.\nBut better be safe than sorry and take another one...\njust in case ya know..";
                    break;
                case 2:
                    textMesh.text =
                        "You now have another pen.\nBut..  what if it lets you down during the exam..?\nhmm..  better take another one";
                    break;
                case 3:
                    textMesh.text = "Hmmmmmm..\nJust in case..  take another pen";
                    break;
            }

            if (stateManager.pencilCount > 3 && stateManager.pencilCount < 20)
            {
                textMesh.text = "You now have " + stateManager.pencilCount + " pens. Maybe take another one";
            }
            else if (stateManager.pencilCount >= 20)
            {
                textMesh.text =
                    "Huh?  Seems like you got \'n\' pencils now | \'n\' e N    \'n\' >= 20,\nthat means you have countably infinite pens,\nI think that should be enough for the exam";
                options[index] = "";
            }

            stateManager.ShowDialogOptions(this, options);
        }

        if (option.Equals(optionInstallPfand) || option.Equals(optionInstallDriver) || option.Equals(optionWaitForDrivers)) 
        {
            if (!stateManager.hasInstalledPfandflaschengeraet)
            {
                if(option.Equals(optionInstallPfand))
                {
                    options[index] = optionInstallDriver;
                    AudioManager.Instance.sourceGlobal.PlayOneShot(AudioManager.Instance.usbConnected, AudioManager.Instance._Volume);
                    textMesh.text = "Nice. It beeps. That sounds good. Now you only need to install the matching drivers";
                    installSteps = 1;
                }else if (option.Equals(optionInstallDriver))
                {
                    options[index] = optionWaitForDrivers;
                    textMesh.text = "Like each BALENCIAGA® piece needs time, so does the installation of the driver";
                    installSteps = 2;
                }
                else if (option.Equals(optionWaitForDrivers))
                {
                    textMesh.text = "Now we have to wait";
                    for (int i = 0; i < waitCount + 1; i++)
                    {
                        textMesh.text += "..";
                    }

                    waitCount++;
                    if (waitCount > 7)
                    {
                        options[index] = optionPutInPfand;
                        stateManager.hasInstalledPfandflaschengeraet = true;
                        textMesh.text = "Nice. It finished. Fast! Scan your bottles";
                    }
                }
            }
            stateManager.ShowDialogOptions(this, options);
        }

        if (option.Equals(optionPutInPfand))
        {
            if(stateManager.pfandFlaschenCount > 0)
            {
                stateManager.cash += 0.25f;
                AudioManager.Instance.sourceGlobal.PlayOneShot(AudioManager.Instance.barcodeScanner, AudioManager.Instance._Volume * 1f);
                AudioManager.Instance.sourceGlobal.PlayOneShot(AudioManager.Instance.cashRegister, AudioManager.Instance._Volume * 0.1f);
                textMesh.text = "You scanned one of your bottles.\nYou got 0.25$ for that. Easy money\nYou now got " + stateManager.cash + "$ to your name";
                stateManager.pfandFlaschenCount--;
            }
            else
            {
                textMesh.text = "You dont have any bottles";
            }

        }
    }

    public override void leaveState(StateManager state)
    {

    }
}
