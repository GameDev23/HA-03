using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTip : MonoBehaviour
{
    public void OnClick()
    {
        Manager.Instance.PanelTips.SetActive(!Manager.Instance.PanelTips.activeSelf);
    }
}
