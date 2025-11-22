

using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
using LoLSDK;

namespace Alpha.Phases.Geoquest
{
    public class Stage1TextManager : MonoBehaviour
    {
        public TopDownPlayerController playerCont;
        public bool hasScrolled;
        public GameObject currentTextSection;
        public int arrayPos;
        public int maxLengthArray;
        public int minLengthArray = 0;

        public bool positionChanged; //= true;

        public GameObject invButton;

        public GameObject[] modelArray;
        public GameObject textPanal;
        public ArrowPointer arrow;

        public bool panalOpen;
        public bool runOnce;
        public bool runOnce2;
        public bool submitOnce;
        public GameObject forwardParent;
        public Button forwardButton;
        public Button backwardsButton;

        public Button[] textButtons;
        public bool[] textBools;

        public GameObject diagram;
        public GameObject switchParent;

        public Button ttsButtonForAllLitter;
        public Button ttsButtonForPaper1;
        public Button ttsButtonForPaper2;
        public Button ttsButtonForPaper3;
        public Button ttsButtonForPaper4;
        public Button ttsButtonForPaper5;
        public Button ttsButtonForPaper6;
        public Button ttsButtonForPaper7;

        public GameObject concept1Process;
        public GameObject concept2GeoProcess;
        public GameObject concept3Rock;
        public GameObject concept4RegMeta;

        public Button ttsButtonForConcept1Process;
        public Button ttsButtonForConcept2GeoProcess;
        public Button ttsButtonForConcept3Rock;
        public Button ttsButtonForConcept4RegMeta;

        public GameObject taskPanal;
        public GameObject task1;
        public GameObject task2;
        public GameObject task3;
        //public bool inventoryReadToBeOpen;

        private void Awake()
        {
            forwardButton.onClick.AddListener(ProgressTextForward);
            backwardsButton.onClick.AddListener(ProgressTextBack);
            ttsButtonForAllLitter.onClick.AddListener(SpeakAllLitterText2);
            ttsButtonForPaper1.onClick.AddListener(SpeakPaper1);
            ttsButtonForPaper2.onClick.AddListener(SpeakPaper2);
            ttsButtonForPaper3.onClick.AddListener(SpeakPaper3);
            ttsButtonForPaper4.onClick.AddListener(SpeakPaper4);
            ttsButtonForPaper5.onClick.AddListener(SpeakPaper5);
            ttsButtonForPaper6.onClick.AddListener(SpeakPaper6);
            ttsButtonForPaper7.onClick.AddListener(SpeakPaper7);

            ttsButtonForConcept1Process.onClick.AddListener(SpeakJournal1Process);
            ttsButtonForConcept2GeoProcess.onClick.AddListener(SpeakJournal2GeoProcess);
            ttsButtonForConcept3Rock.onClick.AddListener(SpeakJournal3Rock);
            ttsButtonForConcept4RegMeta.onClick.AddListener(SpeakJournal4RegMeta);

            for (int i = 0; i < textButtons.Length; i++)
            {
                int index = i + 1;  // Adjust index to match textButton number
                textButtons[i].onClick.AddListener(() => IntroTTSSpeak(index));
            }
            if(MainGameManager.Instance.currentTask < 1)
            {
                StartCoroutine(StartStage1());
            }
            

        }

        // Start is called before the first frame update
        void Start()
        {
            maxLengthArray = modelArray.Length;
            textBools = new bool[maxLengthArray];
        }

        void Update()
        {


            // Only process if the position has changed
            if (positionChanged)
            {
                positionChanged = false; // Reset flag after processing


                // Deactivate all text objects, activate only the current one
                for (int i = 0; i < modelArray.Length; i++)
                {
                    modelArray[i].SetActive(i == arrayPos);
                }

                // Handle the current array position if not yet processed
                if (!textBools[arrayPos])
                {
                    HandleArrayPosActions();
                    textBools[arrayPos] = true;
                }
            }
        }

        private void HandleArrayPosActions()
        {
            switch (arrayPos)
            {
                case 0:
                    if (!submitOnce)
                    {
                        LOLSDK.Instance.SubmitProgress(0, 0, 100);
                        submitOnce = true;
                    }
                    //playerMoveScript.enabled = false;
                    textPanal.gameObject.SetActive(true);
                    backwardsButton.gameObject.SetActive(false);
                    Debug.Log("Array pos 0 runs");
                   // Array.Fill(textBools, false);
                    // forwardParent.gameObject.SetActive(true);
                    break;
                case 1:
                    backwardsButton.gameObject.SetActive(true);
                    //StartCoroutine(DelayTextButton());
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                  
                    StartCoroutine(MoveToBlankInvislbePanalUnit17());
                   
                    break;
                case 5:
                    playerCont.moveSpeed = 0;
                    backwardsButton.gameObject.SetActive(false);
                    positionChanged = true;
                    textPanal.gameObject.SetActive(true);
                    LOLSDK.Instance.SubmitProgress(0, 10, 100);
                    concept3Rock.gameObject.SetActive(true);
                    concept4RegMeta.gameObject.SetActive(true);
                    MainGameManager.Instance.currentTask = 1;
                    MainGameManager.Instance.SaveTaskS1();
                    StartCoroutine(DelayTextButton());
                    break;
                case 6:
                    backwardsButton.gameObject.SetActive(true);
                    break;
                case 7:
                    taskPanal.gameObject.SetActive(true);
                    task1.gameObject.SetActive(true);
                    break;
                case 8:
                 
                    break;
                case 9:
                   
                    break;
                case 10:
               
                    StartCoroutine(MoveToBlankInvislbePanalUnit17());
                    break;
                case 11:
                    playerCont.moveSpeed = 0;
                    backwardsButton.gameObject.SetActive(false);
                    textPanal.gameObject.SetActive(true);
                    StartCoroutine(MoveToBlankInvislbePanalUnit17());
                    break;
                case 12:
                    playerCont.moveSpeed = 0;
                    textPanal.gameObject.SetActive(true);
                    StartCoroutine(MoveToBlankInvislbePanalUnit17());
                    break;
                case 13:
                    playerCont.moveSpeed = 0;
                    backwardsButton.gameObject.SetActive(false);
                    textPanal.gameObject.SetActive(true);
                    StartCoroutine(DelayTextButton());
                    //  basaltDiag.gameObject.SetActive(true);
                    break;
                case 14:
                    backwardsButton.gameObject.SetActive(true);
                    break;
                case 15:
                    task1.gameObject.SetActive(false);
                    StartCoroutine(DelayTextButton());
                    break;
                case 16:
                   
                    task2.gameObject.SetActive(true);
                    concept1Process.gameObject.SetActive(true);
                    break;
                case 17:
                 
                    StartCoroutine(MoveToBlankInvislbePanalUnit17());
                    break;
                case 18: // bottlescollected
                    playerCont.moveSpeed = 0;
                    textPanal.gameObject.SetActive(true);
                    StartCoroutine(MoveToBlankInvislbePanalUnit17());
                    break;
                case 19: // rock cycle steps -
                    playerCont.moveSpeed = 0;
                    backwardsButton.gameObject.SetActive(false);
                    textPanal.gameObject.SetActive(true);
                    StartCoroutine(MoveToBlankInvislbePanalUnit17());
                    break;
                case 20:
                    playerCont.moveSpeed = 0;
                    backwardsButton.gameObject.SetActive(false);
                    textPanal.gameObject.SetActive(true);
                    StartCoroutine(MoveToBlankInvislbePanalUnit17());
                    break;
                case 21:
                    playerCont.moveSpeed = 0;
                    backwardsButton.gameObject.SetActive(false);
                    textPanal.gameObject.SetActive(true);
                    StartCoroutine(MoveToBlankInvislbePanalUnit17());
                    break;
                case 22:
                    playerCont.moveSpeed = 0;
                    backwardsButton.gameObject.SetActive(false);
                    textPanal.gameObject.SetActive(true);
                    StartCoroutine(MoveToBlankInvislbePanalUnit17());
                    break;
                case 23:
                    playerCont.moveSpeed = 0;
                    backwardsButton.gameObject.SetActive(false);
                    textPanal.gameObject.SetActive(true);
                    StartCoroutine(MoveToBlankInvislbePanalUnit17());
                    break;
                case 24:
                    playerCont.moveSpeed = 0;
                    backwardsButton.gameObject.SetActive(false);
                    textPanal.gameObject.SetActive(true);
                    StartCoroutine(MoveToBlankInvislbePanalUnit17());
                    break;
                case 25:
                    playerCont.moveSpeed = 0;
                    backwardsButton.gameObject.SetActive(false);
                    textPanal.gameObject.SetActive(true);
                    StartCoroutine(MoveToBlankInvislbePanalUnit17());
                    break;
                case 26:
                    playerCont.moveSpeed = 0;
                    backwardsButton.gameObject.SetActive(false);
                    textPanal.gameObject.SetActive(true);
                    StartCoroutine(MoveToBlankInvislbePanalUnit17());
                    break;
                case 27:
                    playerCont.moveSpeed = 0;
                    taskPanal.gameObject.SetActive(false);
                    task2.gameObject.SetActive(false);
                    backwardsButton.gameObject.SetActive(false);
                    textPanal.gameObject.SetActive(true);
                    StartCoroutine(MoveToBlankInvislbePanalUnit17());
                    break;
                case 28: // diagram text
                    playerCont.moveSpeed = 0;
                    concept2GeoProcess.gameObject.SetActive(true);
                    backwardsButton.gameObject.SetActive(false);
                    textPanal.gameObject.SetActive(true);
                    diagram.gameObject.SetActive(true);
                   // StartCoroutine(MoveToBlankInvislbePanalUnit172());
                    break;
                case 29: // incorrect
                    StartCoroutine(MoveToQuestion());
                    textPanal.gameObject.SetActive(true);
                    //StartCoroutine(MoveToBlankInvislbePanalUnit17());
                    break;
                case 30: // correct first
                    textPanal.gameObject.SetActive(true);
                    break;
                case 31: // all correct
                    StartCoroutine(DelayTextButton());
                    textPanal.gameObject.SetActive(true);
                    break;
                case 32:
                    backwardsButton.gameObject.SetActive(true);
                    arrow.gameObject.SetActive(false);
                    diagram.gameObject.SetActive(false );
                    taskPanal.gameObject.SetActive(true);
                    task3.gameObject.SetActive(true);
                    LOLSDK.Instance.SubmitProgress(0, 20, 100);
                    MainGameManager.Instance.currentTask = 3;
                    MainGameManager.Instance.SaveTaskS1();
                    textPanal.gameObject.SetActive(true);
                    break;
                case 33:

                    break;
                case 34:

                    break;
                case 35:
                    switchParent.gameObject.SetActive(true);
                    
            
                    StartCoroutine(MoveToBlankInvislbePanalUnit17());
                    break;
                case 36: // wrong
                    textPanal.gameObject.SetActive(true);
                    StartCoroutine(MoveToBlankInvislbePanalUnit17());
                    break;
                case 37:
                    backwardsButton.gameObject.SetActive(false);
                    textPanal.gameObject.SetActive(true);
                    break;
                case 38:
                    backwardsButton.gameObject.SetActive(false);

                    textPanal.gameObject.SetActive(true);
                    break;
                case 39:
                    backwardsButton.gameObject.SetActive(false);

                    textPanal.gameObject.SetActive(true);
                    break;
                case 40:
                    backwardsButton.gameObject.SetActive(false);

                    textPanal.gameObject.SetActive(true);
                    break;
                case 41:
                    backwardsButton.gameObject.SetActive(false);

                    textPanal.gameObject.SetActive(true);
                    StartCoroutine(MoveToBlankInvislbePanalUnit17());               
                    break;
                case 42:
                    backwardsButton.gameObject.SetActive(false);

                    StartCoroutine(MoveToBlankInvislbePanalUnit17());
                    textPanal.gameObject.SetActive(true);
                    break;
                case 43:
                    textPanal.gameObject.SetActive(true);
                    break;
                case 44:
                    textPanal.gameObject.SetActive(false);
                    break;




            }
        }

        public void IntroTTSSpeak(int textIndex)
        {
            string textKey = $"stage1Text{textIndex}";
            LOLSDK.Instance.SpeakText(textKey);
            Debug.Log($"stage1Text{textIndex} Button is pressed");
        }


        public void ProgressTextForward()
        {
            if (arrayPos < maxLengthArray - 1)
            {
                arrayPos++;
                positionChanged = true;
                hasScrolled = false;
                forwardButton.gameObject.SetActive(false);
               
                // Only run DelayTextButton if the next arrayPos is not 2
                if (arrayPos != 4 && arrayPos != 10 && arrayPos != 11 && arrayPos != 12 && arrayPos != 17 && arrayPos != 18
                    && arrayPos != 19 && arrayPos != 20 && arrayPos != 21 && arrayPos != 22 && arrayPos != 23 
                    && arrayPos != 24 && arrayPos != 25 && arrayPos != 27 && arrayPos != 28 && arrayPos != 29 && arrayPos != 30 && arrayPos != 35 && arrayPos != 37 && arrayPos != 36 && arrayPos != 38 && arrayPos != 39 && arrayPos != 40)
                {
                    StartCoroutine(DelayTextButton());
                }
            }
        }


        public void ProgressTextBack()
        {

            if (arrayPos > minLengthArray)
            {
                arrayPos--;
                positionChanged = true; // Mark position as changed
                hasScrolled = false;
                Array.Fill(textBools, false);
            }
        }

        public void ResetPositionFlags()
        {
            Array.Fill(textBools, false); // Reset all boolean flags for text
            positionChanged = true;       // Mark position as changed for Update() processing
        }


        private void SpeakText(string textKey)
        {
            LOLSDK.Instance.SpeakText(textKey);
        }
        public void SpeakAllLitterText2()
        {
            LOLSDK.Instance.SpeakText("stage1TextAllBottlesCollected");
        }

        public void SpeakPaper1()
        {
            LOLSDK.Instance.SpeakText("stage1RCStep1");
        }

        public void SpeakPaper2()
        {
            LOLSDK.Instance.SpeakText("stage1RCStep2");
        }

        public void SpeakPaper3()
        {
            LOLSDK.Instance.SpeakText("stage1RCStep3");
        }

        public void SpeakPaper4()
        {
            LOLSDK.Instance.SpeakText("stage1RCStep4");
        }

        public void SpeakPaper5()
        {
            LOLSDK.Instance.SpeakText("stage1RCStep5");
        }

        public void SpeakPaper6()
        {
            LOLSDK.Instance.SpeakText("stage1RCStep6");
        }

        public void SpeakPaper7()
        {
            LOLSDK.Instance.SpeakText("stage1RCStep7");
        }

        public void SpeakJournal1Process()
        {
            LOLSDK.Instance.SpeakText("concept1Process");
        }

        public void SpeakJournal2GeoProcess()
        {
            LOLSDK.Instance.SpeakText("concept2GeoProcess");
        }

        public void SpeakJournal3Rock()
        {
            LOLSDK.Instance.SpeakText("concept3Rock");
        }

        public void SpeakJournal4RegMeta()
        {
            LOLSDK.Instance.SpeakText("concept4RegionalMeta");
        }

        public void ResetBools()
        {
            Array.Fill(textBools, false);
        }

        public IEnumerator DelayTextButton()
        {

            yield return new WaitForSeconds(5);
            forwardParent.gameObject.SetActive(true);
            forwardButton.gameObject.SetActive(true);

            Debug.Log("This coRoutine Runs");

        }

        public IEnumerator MoveToQuestion()
        {

            yield return new WaitForSeconds(3);
            positionChanged = true;
            ResetBools();
            arrayPos = 28;
            Debug.Log("This coRoutine Runs");

        }

     

        public IEnumerator MoveToBlankInvislbePanalUnit17()
        {
            yield return new WaitForSeconds(5);
            //playerMoveScript.enabled = true;
            textPanal.gameObject.SetActive(false);
            arrayPos = 44;
            playerCont.moveSpeed = 5;
            Debug.Log("This start coRoutine Runs");

        }

        public IEnumerator MoveToBlankInvislbePanalUnit172()
        {
            yield return new WaitForSeconds(5);
            //playerMoveScript.enabled = true;
            textPanal.gameObject.SetActive(false);
            arrayPos = 44;
            playerCont.moveSpeed = 5;
            Debug.Log("This start coRoutine Runs");

        }


        public IEnumerator StartStage1()
        {
            yield return new WaitForSeconds(4);

            textPanal.gameObject.SetActive(true);
            LOLSDK.Instance.SubmitProgress(0, 0, 100);
            arrayPos = 0;
            positionChanged = true;      // <-- ensure Update processes arrayPos 0
                                         // textBools[0] = true;      // <-- remove this so case 0 will run
            Debug.Log("This start coRoutine Runs");
        }
    }
}

