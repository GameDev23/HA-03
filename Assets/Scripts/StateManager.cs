using System;
using System.Collections;
using System.Collections.Generic;
using States;
using TMPro;
using UnityEngine;
/**
 * This class manages the States and calls in each frame the UpdateState function of the currentState
 *
 * You dont have to code anything here except the initialization of your own StateScript.
 * Use your own script like the "TESTInitState.cs" or the "TESTsecondState.cs" inside the "State Scripts" folder.
 * To use your script, you have to initialize it at (1) and make it reachable from the initstate
 *
 * To test or debug your script you can temporarily change the currentState in the Start() function to your function name
 * which then makes your script the first one which runs
 */
public class StateManager : MonoBehaviour
{
    public static StateManager Instance;
    BaseState currentState;

    private List<GameObject> optionList = new List<GameObject>();

    #region State Initialization
    // (1) Initialize your scripts / states here like this  make them public to use them at other locations
    public BaseState initState = new TESTInitState();
    public BaseState secondState = new TESTsecondState();
    public BaseState zuhause = new Zuhause_Bedroom();
    public BaseState bridge = new UniBridge();
    public BaseState mainMenu = new MainMenu();
    public BaseState wardrobe = new Wardrobe();
    public BaseState computer = new Computer();
    public BaseState kitchen = new Kitchen();
    public BaseState livingroom = new Livingroom();
    public BaseState backrooms_entrance = new Backrooms_Entrance();
    public BaseState lecturehallEntrance = new LecturehallEntrance();
    public BaseState lecturehallSeat = new LecturehallSeat();
    public BaseState endingDead = new EndingDead();
    public BaseState endingPassed = new EndingPassed();
    public BaseState leavingHouse = new LeavingHouse();
    public BaseState gettingRobbed = new GettingRobbed();
    public BaseState normalWay = new NormalWay();
    public BaseState shadyWay = new shadyWayToUni();
    public BaseState dead = new Dead();
    public BaseState exam = new Exam();

    public BaseState backrooms_level1 = new backrooms1();
    public BaseState backroomsElevator = new backroomsElevator();
    public BaseState shop = new backroomsShop();
    public BaseState secret_Ending = new SecretEnding();
    public BaseState infinite_Room1 = new InfiniteRoom1();
    public BaseState infinite_Room2 = new InfiniteRoom2();
    
    
    /// end of (1)
    #endregion

    #region Global variables

    // Set here global variables such as isWearingClothes etc
    public bool isWearingClothes = false;
    public bool isWearingBalenciaga = false;
    public bool hasEaten = false;
    public bool hasKey = false;
    public bool wardrobeIsLocked = true;
    public bool hasKnife = false;
    public bool committedMurder = false;
    public int pencilCount = 0;
    public bool knowsAboutPfandflaschengeraet;
    public bool hasCollectedPfandflaschengeraet;
    public bool hasInstalledPfandflaschengeraet;
    public int pfandFlaschenCount = 0;
    public float cash = 0f;
    public int _sanity = 100;
    public bool AmogusKey = false;
    public int infiniteRoomCount = 0;
    public bool hasPidgeon = false;
    public bool hasBingChilling = false;
    public bool lockedInfiniteRoom = false;

    /// 

    #endregion

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
    {   AudioManager.Instance.sourceGlobal.clip = AudioManager.Instance.standardBackgroundMusicClip;
        AudioManager.Instance.sourceGlobal.Play();
        AudioManager.Instance.sourceGlobal.volume = AudioManager.Instance._Volume / 3;
        
        currentState = mainMenu;
        List<string> temp = new List<string>();
        temp.Add("");
        ShowDialogOptions(currentState, temp );
        currentState.EnterState(Instance);

        AmogusKey = false;

    }


    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(Instance);
    }
    
    public void SwitchState(BaseState state)
    {
        //Delete options and switch state
        foreach (GameObject option in optionList)
        {
            Destroy(option);
        }

        optionList = new List<GameObject>();
        
        //Clear dialog window
        Manager.Instance.textMesh.text = "";
        
        currentState.leaveState(Instance);
        currentState = state;
        state.EnterState(Instance);
    }




    

    public void ShowDialogOptions(BaseState state, List<string> options)
    {
        //delete all gameobjects before creating new ones
        //Delete options and switch state
        foreach (GameObject option in optionList)
        {
            Destroy(option);
        }

        optionList = new List<GameObject>();
        
        //create new buttons and add them
        GameObject layout = Manager.Instance.layoutObj;
        GameObject buttonPrefab = Manager.Instance.buttonPrefab;
        int index = 0;
        foreach (string option in options)
        {
            //instatiate new button option and put it into vertical layout grid
            GameObject newButton = Instantiate(buttonPrefab, layout.transform);
            optionList.Add(newButton);
            buttonScript script = newButton.GetComponent<buttonScript>();
            newButton.GetComponent<TextMeshProUGUI>().text = option;
            newButton.transform.SetSiblingIndex(index);
            
            //set button variables to know which button got pressed in which state
            script.index = index;
            script.option = option;
            script.currentState = state;
            index++;
        }
    }
}
