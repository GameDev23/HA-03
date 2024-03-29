using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class backroomsShop : BaseState
{
    private StateManager stateManager;
    private List<string> options;
    private TextMeshProUGUI textMesh;

    private TextMeshProUGUI SanityNumber;



    private string Introduction = ("The smell of Bing chilling led you to a Sussy looking ice cream shop, But what is that you can see behind the Counter. Looks like a guy Selling Ice Cream. Should i approach him or not ?");

    private string option1Start = ("Open Shop");
    private string option2Start = ("Leave");  
   




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

        AudioManager.Instance.sourceBackrooms.PlayOneShot(AudioManager.Instance.MerchantSpeech, 1f);
        


        options.Add(option1Start);
        options.Add(option2Start);


        stateManager.ShowDialogOptions(this, options);

        Manager.Instance.backgroundImage.sprite = Manager.Instance.backgroundSprites[10];
        textMesh.text = Introduction;


    }

    public override void leaveState(StateManager state)
    {
        Manager.Instance.ShopPanel.SetActive(false);


    }

    public override void OptionClicked(int index, string option)
    {
        if (option.Equals(option1Start))
        {
            Manager.Instance.ShopPanel.SetActive(true);

            options.Remove(option1Start);
            stateManager.ShowDialogOptions(this, options);


        }else if (option.Equals(option2Start))
        {
            stateManager.SwitchState(stateManager.backrooms_level1);
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

    } 
}
