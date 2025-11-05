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

       // public GameObject letterOpen;

        public bool panalOpen;
        public bool runOnce;
        public bool runOnce2;
        public bool submitOnce;
        public GameObject forwardParent;
        public Button forwardButton;
        public Button backwardsButton;

        public Button[] textButtons;
        public bool[] textBools;
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

            StartCoroutine(StartStage1());

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
                    forwardParent.gameObject.SetActive(false);
                    break;
                case 11:
                    break;
                case 12:
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
                if (arrayPos != 4)
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

        public IEnumerator MoveToBlankInvislbePanalUnit17()
        {
            yield return new WaitForSeconds(5);
            //playerMoveScript.enabled = true;
            textPanal.gameObject.SetActive(false);
            arrayPos = 12;
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

