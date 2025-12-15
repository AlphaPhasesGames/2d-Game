using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
using LoLSDK;

namespace Alpha.Phases.Geoquest
{
    public class Stage3TextManager : MonoBehaviour
    {
        public TopDownPlayerController playerCont;
        public ArrowPointer arrowMan;
        public Stage3OpenJournal openJourn;
        public GameObject journal;
        public bool hasScrolled;
        public GameObject currentTextSection;
        public int arrayPos;
        public int maxLengthArray;
        public int minLengthArray = 0;

        public bool positionChanged; //= true;

        public Transform magmaBoulder;
        public Transform waterSource;
        public Transform exit;

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

        public GameObject boulder;

        public Button[] textButtons;
        public bool[] textBools;

       // public GameObject switchesOnMap;

       // public GameObject magmaOnMap;
      //  public GameObject magamObj;

      //  public GameObject door;

     
        public GameObject taskBar;
        public GameObject task1PullSwtichesInOrder;
        public GameObject task2CollectMagma;
        public GameObject task3Leave;
        // public GameObject door2;
        //public BoxCollider2D doorCollider;

        private void Awake()
        {
            forwardButton.onClick.AddListener(ProgressTextForward);
            backwardsButton.onClick.AddListener(ProgressTextBack);

            for (int i = 0; i < textButtons.Length; i++)
            {
                int index = i + 1;  // Adjust index to match textButton number
                textButtons[i].onClick.AddListener(() => IntroTTSSpeak(index));
            }

            if (MainGameManager.Instance.currentTask < 1)
            {
                StartCoroutine(StartStage3());
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
                        LOLSDK.Instance.SubmitProgress(0, 80, 100);
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
                    
                    break;
                case 3:
                    //taskBar.gameObject.SetActive(true);
                    // task1MineralsCollect.gameObject.SetActive(true);
                    StartCoroutine(MoveToBlankInvislbePanalUnit17());
                    break;
                case 4:
                    playerCont.moveSpeed = 0;
                    backwardsButton.gameObject.SetActive(false);
                    textPanal.gameObject.SetActive(true);
                    openJourn.ToggleJournal();
                    openJourn.pageNo = 5;
                    StartCoroutine(DelayTextButton());
                    break;
                case 5:

                    backwardsButton.gameObject.SetActive(true);
                   
                    break;
                case 6:
                   
                  
                    break;
                case 7:
                    openJourn.ToggleJournal();
                    StartCoroutine(MoveToBlankInvislbePanalUnit17());
                    break;

                case 8: //Correct Switch
                    forwardButton.gameObject.SetActive(false);
                    forwardParent.gameObject.SetActive(false);
                    backwardsButton.gameObject.SetActive(false);
                    textPanal.gameObject.SetActive(true);
                    StartCoroutine(MoveToBlankInvislbePanalUnit17());
                    break;
                case 9://InCorrect Switch
                    forwardButton.gameObject.SetActive(false);
                    forwardParent.gameObject.SetActive(false);
                    textPanal.gameObject.SetActive(true);
                    backwardsButton.gameObject.SetActive(false);
                    StartCoroutine(MoveToBlankInvislbePanalUnit17());
                    break;
                case 10://All Correct
                    playerCont.moveSpeed = 0;
                    textPanal.gameObject.SetActive(true);
                    StartCoroutine(DelayTextButton());
                    backwardsButton.gameObject.SetActive(false);
                    break;
                case 11://Feldspar

                    backwardsButton.gameObject.SetActive(true);
                    break;
                case 12:

                   
                   
                    break;
                case 13:
                    arrowMan.gameObject.SetActive(true);
                    arrowMan.target = magmaBoulder;
                    StartCoroutine(MoveToBlankInvislbePanalUnit172());
                    break;
                case 14:
                    forwardButton.gameObject.SetActive(false);
                    forwardParent.gameObject.SetActive(false);
                    backwardsButton.gameObject.SetActive(false);
                    textPanal.gameObject.SetActive(true);
                    arrowMan.target = waterSource;
                    StartCoroutine(MoveToBlankInvislbePanalUnit172());
                    break;
                case 15:
                    textPanal.gameObject.SetActive(true);
                    arrowMan.target = exit;
                    StartCoroutine(DelayTextButton());
                    break;
                case 16:// igneous
                    backwardsButton.gameObject.SetActive(true);
                    boulder.gameObject.SetActive(false);
                    StartCoroutine(MoveToBlankInvislbePanalUnit172());
                    break;
                case 17: // correct box 1
                    textPanal.gameObject.SetActive(false);
                    break;
            }
        }

        public void IntroTTSSpeak(int textIndex)
        {
            string textKey = $"stage3Text{textIndex}";
            LOLSDK.Instance.SpeakText(textKey);
            Debug.Log($"stage3Text{textIndex} Button is pressed");
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
                if (arrayPos != 3 && arrayPos != 7 && arrayPos != 8 )
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
            forwardParent.gameObject.SetActive(false);
            forwardButton.gameObject.SetActive(false);
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
            arrayPos = 17;
            Debug.Log("This coRoutine Runs");

        }



        public IEnumerator MoveToBlankInvislbePanalUnit17()
        {
            yield return new WaitForSeconds(5);
            //playerMoveScript.enabled = true;
            textPanal.gameObject.SetActive(false);
            arrayPos = 17;
            playerCont.moveSpeed = 5;
            Debug.Log("This start coRoutine Runs");

        }

        public IEnumerator MoveToBlankInvislbePanalUnit172()
        {
            yield return new WaitForSeconds(2);
            //playerMoveScript.enabled = true;
            textPanal.gameObject.SetActive(false);
            arrayPos = 42;
            playerCont.moveSpeed = 5;
            Debug.Log("This start coRoutine Runs");

        }


        public IEnumerator StartStage3()
        {
            yield return new WaitForSeconds(2);

            textPanal.gameObject.SetActive(true);
            //LOLSDK.Instance.SubmitProgress(0, 40, 100);
            arrayPos = 0;
            positionChanged = true;
            Debug.Log("This start coRoutine Runs");
        }


        public void PlayAlreadyUsed()
        {
            LOLSDK.Instance.SpeakText("stage2RCText24Tried");
        }
    }
}
