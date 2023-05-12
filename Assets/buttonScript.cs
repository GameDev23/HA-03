using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class buttonScript : MonoBehaviour
{
    public int index = -1;
    public string option;
    public BaseState currentState;
    public GameObject panel;
    public TextMeshProUGUI textMesh;
    private void Start()
    {
        
        Bounds bounds = textMesh.mesh.bounds;
        float width = bounds.size.x;
        float height = bounds.size.y;
        
        RectTransform panelRectTransform = panel.GetComponent<RectTransform>();
        panelRectTransform.sizeDelta = new Vector2(width, height);
        Debug.Log("Resized window " + option);
        
    }

    public void OnClick()
    {
        AudioManager.Instance.sourceGlobal.PlayOneShot(AudioManager.Instance.Click, 0.1f);
        AudioManager.Instance.source.PlayOneShot(AudioManager.Instance.Click, 0.1f);
        
        currentState.OptionClicked(index, option);
    }
}
