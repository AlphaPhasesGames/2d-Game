

using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
using LoLSDK;

namespace Alpha.Phases.Geoquest
{
    public class Stage1TextManager : MonoBehaviour
    {
        // public PatternQuestMain main;
        //  public PlayerMovement playerMoveScript;
        //  public Stage1LetterManager s1LetterMan;
        public bool hasScrolled;
        public GameObject currentTextSection;
        public int arrayPos;
        public int maxLengthArray;
        public int minLengthArray = 0;

        public bool positionChanged; //= true;

        public GameObject invButton;

        public GameObject[] modelArray;
        public GameObject textPanal;

       // public GameObject basaltDiag;

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
        //public bool inventoryReadToBeOpen;

        private void Awake()
        {
            forwardButton.onClick.AddListener(ProgressTextForward);
            backwardsButton.onClick.AddListener(ProgressTextBack);

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
                    backwardsButton.gameObject.SetActive(false);
                    positionChanged = true;
                    textPanal.gameObject.SetActive(true);

                    MainGameManager.Instance.currentTask = 1;
                    MainGameManager.Instance.SaveTaskS1();
                    StartCoroutine(DelayTextButton());
                    break;
                case 6:
                    break;
                case 7:
                    break;
                case 8:
                 
                    break;
                case 9:
                   
                    break;
                case 10:
                    StartCoroutine(MoveToBlankInvislbePanalUnit17());
                    break;
                case 11:
                    textPanal.gameObject.SetActive(true);
                    StartCoroutine(MoveToBlankInvislbePanalUnit17());
                    break;
                case 12:
                    textPanal.gameObject.SetActive(true);
                    StartCoroutine(MoveToBlankInvislbePanalUnit17());
                    break;
                case 13:
                    textPanal.gameObject.SetActive(true);
                    StartCoroutine(DelayTextButton());
                    //  basaltDiag.gameObject.SetActive(true);
                    break;
                case 14:

                    break;
                case 15:

                    break;
                case 16:

                    break;
                case 17:
                    StartCoroutine(MoveToBlankInvislbePanalUnit17());
                    break;
                case 18: // bottlescollected
                    textPanal.gameObject.SetActive(true);
                    StartCoroutine(MoveToBlankInvislbePanalUnit17());
                    break;
                case 19: // rock cycle steps - 
                    textPanal.gameObject.SetActive(true);
                    StartCoroutine(MoveToBlankInvislbePanalUnit17());
                    break;
                case 20:
                    textPanal.gameObject.SetActive(true);
                    StartCoroutine(MoveToBlankInvislbePanalUnit17());
                    break;
                case 21:
                    textPanal.gameObject.SetActive(true);
                    StartCoroutine(MoveToBlankInvislbePanalUnit17());
                    break;
                case 22:
                    textPanal.gameObject.SetActive(true);
                    StartCoroutine(MoveToBlankInvislbePanalUnit17());
                    break;
                case 23:
                    textPanal.gameObject.SetActive(true);
                    StartCoroutine(MoveToBlankInvislbePanalUnit17());
                    break;
                case 24:
                    textPanal.gameObject.SetActive(true);
                    StartCoroutine(MoveToBlankInvislbePanalUnit17());
                    break;
                case 25:
                    textPanal.gameObject.SetActive(true);
                    StartCoroutine(MoveToBlankInvislbePanalUnit17());
                    break;
                case 26: 
                    textPanal.gameObject.SetActive(true);
                    StartCoroutine(MoveToBlankInvislbePanalUnit17());
                    break;
                case 27:
                    textPanal.gameObject.SetActive(true);
                    StartCoroutine(MoveToBlankInvislbePanalUnit17());
                    break;
                case 28: // diagram text
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
                    diagram.gameObject.SetActive(false );
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
                    textPanal.gameObject.SetActive(true);
                    break;
                case 38:
                    textPanal.gameObject.SetActive(true);
                    break;
                case 39:
                    textPanal.gameObject.SetActive(true);
                    break;
                case 40:
                    textPanal.gameObject.SetActive(true);
                    break;
                case 41:
                    textPanal.gameObject.SetActive(true);
                    StartCoroutine(MoveToBlankInvislbePanalUnit17());               
                    break;
                case 42:
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


        public void ResetBools()
        {
            Array.Fill(textBools, false);
        }

        public IEnumerator DelayTextButton()
        {

            yield return new WaitForSeconds(3);
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
            Debug.Log("This start coRoutine Runs");

        }

        public IEnumerator MoveToBlankInvislbePanalUnit172()
        {
            yield return new WaitForSeconds(5);
            //playerMoveScript.enabled = true;
            textPanal.gameObject.SetActive(false);
            arrayPos = 44;
            Debug.Log("This start coRoutine Runs");

        }


        public IEnumerator StartStage1()
        {
            yield return new WaitForSeconds(4);

            textPanal.gameObject.SetActive(true);

            arrayPos = 0;
            positionChanged = true;      // <-- ensure Update processes arrayPos 0
                                         // textBools[0] = true;      // <-- remove this so case 0 will run
            Debug.Log("This start coRoutine Runs");
        }
    }
}

