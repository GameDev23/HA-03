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
    public TextMeshProUGUI SanityNumber;
    public Image backgroundImage;
    public Sprite bedroom;
    public Sprite bridge;
    public GameObject key;
    public GameObject layoutObj;
    public GameObject buttonPrefab;
    public GameObject cameraFlash;
    public GameObject PanelSanity;
    public Image SanityBar;
    public List<Sprite> backgroundSprites = new List<Sprite>();
    public List<Sprite> backgroundSpritesDavid = new List<Sprite>();
    public GameObject Panel;
    public GameObject PanelTips;
    public GameObject PanelWalktrough;
    public Slider VolumeSlider;
    public List<Sprite> samwelSprites = new List<Sprite>();
    public TextMeshProUGUI volumeTextMesh;
    public GameObject mp3Player;
    

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

    public void collectKey()
    {
        StartCoroutine(Key());
    }

    IEnumerator Key()
    {
        Image img = key.GetComponent<Image>();
        AudioManager.Instance.sourceGlobal.PlayOneShot(AudioManager.Instance.collectItem, 1f);
        // loop over 1 second backwards
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            // set color with i as alpha
            img.color = new Color(1, 1, 1, i);
            yield return null;
        }

        key.SetActive(false);

    }
    
    
}
