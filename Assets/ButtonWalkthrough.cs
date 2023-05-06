using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonWalkthrough : MonoBehaviour
{
    public void OnClick()
    {
        Manager.Instance.PanelWalktrough.SetActive(!Manager.Instance.PanelWalktrough.activeSelf);
    }
}
