using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Manager : MonoBehaviour
{
    public static Manager Instance;
    public Canvas canvas;
    public TextMeshProUGUI textMesh;
    public Image backgroundImage;
    public Sprite bedroom;
    public Sprite bridge;
    public GameObject layoutObj;
    public GameObject buttonPrefab;

    public int test = 0;

    private void Awake()
    {
        // create singleton
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
