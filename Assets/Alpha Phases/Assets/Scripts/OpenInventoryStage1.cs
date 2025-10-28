using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LoLSDK;
namespace Alpha.Phases.Destiny.Quest
{
    public class OpenInventoryStage1 : MonoBehaviour
    {
        // this script holds the main meat of the inventory
        // public TUSOMLobby1TextMan tusomTextMan;
        public GameObject invUIPanal; // declare gameobject for UI inventory panal
        public Stage1Scene1LabTextBox textMan;
        public Button openInv;
        public Button closeInv;

        public Button openBook1;
        public Button closeBook1;
       // public Button citation1Button;

        public GameObject book1;

        [SerializeField]
        public bool isInvOpen; // bool to check is the inventory is open 
        public bool stopRepeat;
        public bool stopRepeat2;
        public bool book1Read;
        public bool book1Closed;
        public bool inventoryReadToBeOpen;

        public Button ttsBulletPoint1;
        public Button ttsBulletPoint2;
        public Button ttsBulletPoint3;
        public Button ttsBulletPoint4;
        public Button ttsBulletPoint5;
        public Button ttsBulletPoint6;

        private void Awake()
        {
            openInv.onClick.AddListener(OpenInventory);
            closeInv.onClick.AddListener(OpenInventory);
            openBook1.onClick.AddListener(OpenBook1ManifestDestiny);
            closeBook1.onClick.AddListener(CloseBook1ManifestDestiny);

            ttsBulletPoint1.onClick.AddListener(PlayTTSBulletPoint1);
            ttsBulletPoint2.onClick.AddListener(PlayTTSBulletPoint2);
            ttsBulletPoint3.onClick.AddListener(PlayTTSBulletPoint3);
            ttsBulletPoint4.onClick.AddListener(PlayTTSBulletPoint4);
            ttsBulletPoint5.onClick.AddListener(PlayTTSBulletPoint5);
            ttsBulletPoint6.onClick.AddListener(PlayTTSBulletPoint6);

        }
        // Update is called once per frame
        void Update()
        {

            if (isInvOpen) // if inventory is open
            {
                if (!stopRepeat) // if stopRepeat bool is fasle, execute code
                {
                    invUIPanal.gameObject.SetActive(true); // enable the INV UI
                    Debug.Log("Inv Consta Loading");
                    stopRepeat = true; // set stop repeat true to stop it firing over and over
                    // robCont.StopRobotMoving(); // Stops the robot when inventory is open
                }
            }
            else
            {
                if (!stopRepeat2) // if stopRepeat 2 is false
                {
                    invUIPanal.gameObject.SetActive(false); // hide INV UI
                    Debug.Log("Inv Consta Resetting");
                    stopRepeat2 = true; // set stopRepeat 2 to true to stop it firing over and over
                }
            }
        }

        //Function for opening the inventory
        public void OpenInventory()
        {
            isInvOpen = !isInvOpen; // if inventory is closed, open. If open, then close it
            stopRepeat = false; // Set stopRepeat bool to false
            stopRepeat2 = false; // set stoprepeat bool to true
            if (!textMan.inventoryReadToBeOpen)
            {
                textMan.positionChanged = true;
                textMan.arrayPos = 5;
                textMan.inventoryReadToBeOpen = true;
            }
        }

        public void OpenBook1ManifestDestiny()
        {
            book1.gameObject.SetActive(true);
            if (!book1Read)
            {
                textMan.positionChanged = true;
                textMan.arrayPos = 6;
                book1Read = true;
            }
        }

        public void CloseBook1ManifestDestiny()
        {
            book1.gameObject.SetActive(false);
            if (!book1Closed)
            {
                textMan.positionChanged = true;
                textMan.arrayPos = 7;
                invUIPanal.gameObject.SetActive(false); // hide INV UI
                book1Closed = true;
            }

        }


        public void PlayTTSBulletPoint1()
        {
            LOLSDK.Instance.SpeakText("book1BP1");
            Debug.Log("This TTS Worked");
        }

        public void PlayTTSBulletPoint2()
        {
            LOLSDK.Instance.SpeakText("book1BP2");
            Debug.Log("This TTS Worked");
        }

        public void PlayTTSBulletPoint3()
        {
            LOLSDK.Instance.SpeakText("book1BP3");
            Debug.Log("This TTS Worked");
        }

        public void PlayTTSBulletPoint4()
        {
            LOLSDK.Instance.SpeakText("book1BP4");
            Debug.Log("This TTS Worked");
        }

        public void PlayTTSBulletPoint5()
        {
            LOLSDK.Instance.SpeakText("book1BP5");
            Debug.Log("This TTS Worked");
        }

        public void PlayTTSBulletPoint6()
        {
            LOLSDK.Instance.SpeakText("book1BP6");
            Debug.Log("This TTS Worked");
        }
    }
}