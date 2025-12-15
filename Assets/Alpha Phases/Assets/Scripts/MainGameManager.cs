using System.Collections;
using System.Collections.Generic;
using System.IO;
using LoLSDK;
using SimpleJSON;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.AI;


namespace Alpha.Phases.Geoquest
{
    [System.Serializable] // serialize this save data
    public class GQSaveData
    {
        [Header("StageProgress")] // header for the save location for the robot
        public int current_stage; // int to hold the level number
        public int current_task;
        public int collected_gems;
        public bool stage_2_part_2;
    }
    public class MainGameManager : MonoBehaviour
    {
        public static MainGameManager Instance { get; private set; }

        #region global code
        [SerializeField, Header("Initial State Data")]
        GQSaveData gqSaveData;
        public int currentStagedqwb;
        public int currentTask;
        public int collectedGems;
        public bool stage2Part2;


        public bool runScriptOnce;

        [SerializeField] Button continueButton, newGameButton;
        public TextMeshProUGUI newGameText;
        public TextMeshProUGUI continueText;
        #endregion

        #region "stage1stufftobecollapsed"
        [SerializeField, Header("Stage 1 Code")]


        #endregion

        JSONNode _langNode;
        public string _langCode = "en";
        string _langCodeSpanish = "es";

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject); // Prevent duplicates
                return;
            }

            Instance = this;
            DontDestroyOnLoad(this.gameObject);
            Application.runInBackground = false;
        }

        void Start()
        {
            newGameButton.onClick.AddListener(RemoveMainMenuUINewGame); // new game button after pressing, hides the button - see script at the bottom of the script
            continueButton.onClick.AddListener(RemoveMainMenuUIContinue); ; // continune saved game button after pressing, hides the button - see script at the bottom of the script

#if UNITY_EDITOR
            ILOLSDK sdk = new LoLSDK.MockWebGL();
#elif UNITY_WEBGL
	    ILOLSDK sdk = new LoLSDK.WebGL();
#endif
            Helper.StateButtonInitialize<GQSaveData>(newGameButton, continueButton, OnLoad); // initialise LOLSDK helper function and attached both new game and continue buttons to it

        }

        private void Update()
        {
            //  gqSaveData.current_stage = currentStagedqwb;






            
           if (Input.GetKeyDown(KeyCode.Alpha1))
           {
               SceneManager.LoadScene("ExitStage");
           }
            /*
             if (Input.GetKeyDown(KeyCode.Alpha2))
             {
                 SceneManager.LoadScene("ParisStudy");

             }
             if (Input.GetKeyDown(KeyCode.Alpha3))
             {
                 SceneManager.LoadScene("Stage2Scene3");
             }
             */
        }

        public void Save()
        {
            LOLSDK.Instance.SaveState(gqSaveData); // save data to cargoSaveData
            Debug.Log("Game Saved");
        }

        /// <summary>
        /// This is the setting of your initial state when the scene loads.
        /// The state can be set from your default editor settings or from the
        /// users saved data after a valid save is called.
        /// </summary>
        /// <param name="loadedGardenData"></param>

        void OnLoad(GQSaveData loadedGardenData)
        {
            JSONNode langs = SharedState.LanguageDefs;
            // Overrides serialized state data or continues with editor serialized values.
            if (loadedGardenData != null)
                gqSaveData = loadedGardenData;
            stage2Part2 = gqSaveData.stage_2_part_2;
            currentStagedqwb = gqSaveData.current_stage;
            collectedGems = gqSaveData.collected_gems;
            if (gqSaveData.current_stage == 1)
            {
                SceneManager.LoadScene("Stage1");
                currentTask = gqSaveData.current_task;
                
                Debug.Log("Loaded Stage 1 Scene 1 Save");
            }

            if (gqSaveData.current_stage == 2)
            {
                SceneManager.LoadScene("Stage 2");
                Debug.Log("Loaded Stage 1 Scene 2 Save");
            }

            if (gqSaveData.current_stage == 3)
            {
                SceneManager.LoadScene("Stage3");
                Debug.Log("Loaded Stage 1 Scene 2 Save");
            }

            Debug.Log("Load Function Called");
        }

        void RemoveMainMenuUINewGame()
        {
            currentStagedqwb = 1;
            SaveS1S1();
        }
        void RemoveMainMenuUIContinue()
        {
            currentStagedqwb = gqSaveData.current_stage;
            collectedGems = gqSaveData.collected_gems;
          Debug.Log("Loaded Save");
        }

        #region global Save stuff

        public void SaveS1S1()
        {
            currentStagedqwb = 1;
            gqSaveData.current_stage = currentStagedqwb;
         
            Save();
        }

        public void SaveS1S2()
        {
            currentStagedqwb = 2;
            gqSaveData.current_stage = currentStagedqwb;
            Save();
        }

        public void SaveS1S3()
        {
            currentStagedqwb = 3;
           gqSaveData.current_stage = currentStagedqwb;
            Save();
        }

        public void SaveTaskS1()
        {
            gqSaveData.current_task = currentTask;
            gqSaveData.collected_gems = collectedGems;
            Save();
        }

        public void SaveTaskS2()
        {
            gqSaveData.current_task = currentTask;
            gqSaveData.collected_gems = collectedGems;
            Save();
        }
        #endregion          

        public void SaveStage2Part2Location()
        {
            stage2Part2 = true;
            gqSaveData.current_task = currentTask;
            gqSaveData.collected_gems = collectedGems;
            gqSaveData.stage_2_part_2 = stage2Part2;
            Save();
        }
    }
}

