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






    public override void EnterState(StateManager state)
    {
        Manager.Instance.backgroundImage.sprite = Manager.Instance.backgroundSprites[8];
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
    
    public override void OptionClicked(int index, string option)
    {
        
    }

    public override void leaveState(StateManager state)
    {
        
    }
}
