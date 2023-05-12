using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmogusScript : MonoBehaviour
{
    public void OnClick()
    {
        StateManager.Instance.AmogusKey = true;

        Manager.Instance.CollectItem(gameObject);
        AudioManager.Instance.sourceBackrooms.PlayOneShot(AudioManager.Instance.collectItem,1f);
    }
}
