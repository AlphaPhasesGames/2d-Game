using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
using LoLSDK;

namespace Alpha.Phases.Geoquest
{
    public class Stage2TextManager : MonoBehaviour
    {
        public TopDownPlayerController playerCont;
        public Stage2CombinationManager combMan;
        public ArrowPointer arrowMan;
        public OpenJournal openJourn;
        public bool hasScrolled;
        public GameObject currentTextSection;
        public int arrayPos;
        public int maxLengthArray;
        public int minLengthArray = 0;

        public bool positionChanged; //= true;

        private int lastCorrectGuessCount = 0;

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

        public GameObject mineralsOnMap;
        public GameObject mineralsObj;

        public GameObject machineONMap;
        public Transform machineInScene;

        public bool firstCorrectCombination;
        public bool secondCorrectCombination;
        public bool thirdCorrectCombination;
        public GameObject combineMachineUI;
        // public Button ttsButtonForConcept1Process;
        // public Button ttsButtonForConcept2GeoProcess;
        // public Button ttsButtonForConcept3Rock;
        // public Button ttsButtonForConcept4RegMeta;

        // public GameObject taskPanal;
        // public GameObject task1;
        // public GameObject task2;
        // public GameObject task3;

        private void Awake()
        {
            forwardButton.onClick.AddListener(ProgressTextForward);
            backwardsButton.onClick.AddListener(ProgressTextBack);
            /*ttsButtonForAllLitter.onClick.AddListener(SpeakAllLitterText2);
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
*/
            for (int i = 0; i < textButtons.Length; i++)
            {
                int index = i + 1;  // Adjust index to match textButton number
                textButtons[i].onClick.AddListener(() => IntroTTSSpeak(index));
            }
            if (MainGameManager.Instance.currentTask < 1)
            {
                StartCoroutine(StartStage2());
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
            if (combMan.amountOfCorrectGuesses != lastCorrectGuessCount)
            {
                lastCorrectGuessCount = combMan.amountOfCorrectGuesses;

                if (lastCorrectGuessCount == 1 && !firstCorrectCombination)
                {
                    StartCoroutine(FirstCorrectComb());
                    firstCorrectCombination = true;
                }

                if (lastCorrectGuessCount == 2 && !secondCorrectCombination)
                {
                    StartCoroutine(SecondCorrectComb());
                    secondCorrectCombination = true;
                }

                if (lastCorrectGuessCount == 3 && !thirdCorrectCombination)
                {
                    StartCoroutine(ThirdCorrectComb());
                    thirdCorrectCombination = true;
                }
                Debug.Log(" This update runs once" + lastCorrectGuessCount);
            }
        }



        private void HandleArrayPosActions()
        {
            switch (arrayPos)
            {
                case 0:
                    if (!submitOnce)
                    {
                        LOLSDK.Instance.SubmitProgress(0, 40, 100);
                        submitOnce = true;
                    }
                    textPanal.gameObject.SetActive(true);
                    backwardsButton.gameObject.SetActive(false);
                    StartCoroutine(DelayTextButton());
                    Debug.Log("Array pos 0 runs");
                    break;
                case 1:
                    backwardsButton.gameObject.SetActive(true);
                    break;
                case 2:
                    StartCoroutine(MoveToBlankInvislbePanalUnit17());
                    break;
                case 3:
                    backwardsButton.gameObject.SetActive(false);
                    textPanal.gameObject.SetActive(true);
                    openJourn.ToggleJournal();
                    StartCoroutine(DelayTextButton());
                    break;
                case 4:
                    backwardsButton.gameObject.SetActive(true);
                    break;
                case 5:
                    openJourn.ToggleJournal();
                    mineralsOnMap.gameObject.SetActive(true);
                    StartCoroutine(MoveToBlankInvislbePanalUnit17());
                    break;
                case 6:
                    backwardsButton.gameObject.SetActive(false);
                    textPanal.gameObject.SetActive(true);
                    StartCoroutine(DelayTextButton());
                    break;
                case 7:
                    backwardsButton.gameObject.SetActive(true);
                    StartCoroutine(MoveToBlankInvislbePanalUnit17());
                    break;

                case 8: //mica
                    backwardsButton.gameObject.SetActive(false);
                    textPanal.gameObject.SetActive(true);
                    StartCoroutine(MoveToBlankInvislbePanalUnit17());
                    break;
                case 9://Calcite
                    textPanal.gameObject.SetActive(true);
                    backwardsButton.gameObject.SetActive(false);
                    StartCoroutine(MoveToBlankInvislbePanalUnit17());
                    break;
                case 10://Quartz
                    textPanal.gameObject.SetActive(true);
                    backwardsButton.gameObject.SetActive(false);
                    StartCoroutine(MoveToBlankInvislbePanalUnit17());
                    break;
                case 11://Feldspar
                    textPanal.gameObject.SetActive(true);
                    backwardsButton.gameObject.SetActive(false);
                    StartCoroutine(MoveToBlankInvislbePanalUnit17());
                    break;
                case 12:
                    arrowMan.target = machineInScene;
                    machineONMap.gameObject.SetActive(true);
                    textPanal.gameObject.SetActive(true);
                    StartCoroutine(MoveToBlankInvislbePanalUnit17());
                    break;
                case 13:
                    textPanal.gameObject.SetActive(true);
                    StartCoroutine(DelayTextButton());
                    break;
                case 14:
                    combineMachineUI.gameObject.SetActive(true);
                    break;
                case 15:
              
                    break;
                case 16:// igneous
                    textPanal.gameObject.SetActive(true);
                    break;
                case 17: // correct box 1
                    StartCoroutine(MoveToBlankInvislbePanalUnit172());
                    break;
                case 18: // sedimentary
                    textPanal.gameObject.SetActive(true);
                    break;
                case 19: // correct box 2
                    StartCoroutine(MoveToBlankInvislbePanalUnit172());
                    break;
                case 20: // MetaMorphic
                    textPanal.gameObject.SetActive(true);
                    break; 
                case 21: //incorrect
                    textPanal.gameObject.SetActive(true);
                    StartCoroutine(MoveToBlankInvislbePanalUnit17());
                    break;
                case 22:
                    textPanal.gameObject.SetActive(true);
                    StartCoroutine(DelayTextButton());
                    break;
                case 23:
                    StartCoroutine(MoveToBlankInvislbePanalUnit17());
                    combineMachineUI.gameObject.SetActive(false);
                    break;
                case 24: // wrong box
                    textPanal.gameObject.SetActive(true);
                    combineMachineUI.gameObject.SetActive(false);
                    break;
                case 25:
                    textPanal.gameObject.SetActive(false);
                    break;


            }
        }

        public void IntroTTSSpeak(int textIndex)
        {
            string textKey = $"stage2RCText{textIndex}";
            LOLSDK.Instance.SpeakText(textKey);
            Debug.Log($"stage2RCText{textIndex} Button is pressed");
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
                if (arrayPos != 2 && arrayPos != 7 && arrayPos != 8 && arrayPos != 9 && arrayPos != 10 && arrayPos != 11 && arrayPos != 15)
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

        public void ResetBools()
        {
            Array.Fill(textBools, false);
        }

        public IEnumerator DelayTextButton()
        {
            forwardParent.gameObject.SetActive(false);
            forwardButton.gameObject.SetActive(false);
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
            arrayPos = 25;
            playerCont.moveSpeed = 5;
            Debug.Log("This start coRoutine Runs");

        }

        public IEnumerator MoveToBlankInvislbePanalUnit172()
        {
            yield return new WaitForSeconds(2);
            //playerMoveScript.enabled = true;
            textPanal.gameObject.SetActive(false);
            arrayPos = 25;
            playerCont.moveSpeed = 5;
            Debug.Log("This start coRoutine Runs");

        }


        public IEnumerator StartStage2()
        {
            yield return new WaitForSeconds(2);

            textPanal.gameObject.SetActive(true);
            LOLSDK.Instance.SubmitProgress(0, 40, 100);
            arrayPos = 0;
            positionChanged = true;      
            Debug.Log("This start coRoutine Runs");
        }

        public IEnumerator FirstCorrectComb()
        {
            yield return new WaitForSeconds(5);
            positionChanged = true;
            arrayPos = 17;
        }

        public IEnumerator SecondCorrectComb()
        {
            yield return new WaitForSeconds(5);
            positionChanged = true;
            arrayPos = 19;
        }

        public IEnumerator ThirdCorrectComb()
        {
            yield return new WaitForSeconds(5);
            positionChanged = true;
            arrayPos = 22;
        }
    }
}
