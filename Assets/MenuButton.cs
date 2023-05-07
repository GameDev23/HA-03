using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    public void OnClick()
    {
        Manager.Instance.Panel.SetActive(!Manager.Instance.Panel.activeSelf);
    }
    
}
