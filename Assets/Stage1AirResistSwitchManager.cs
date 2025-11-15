using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Alpha.Phases.Geoquest
{
    public class Stage1AirResistSwitchManager : MonoBehaviour
    {
        public Sprite closedSwitch;  // assign in Inspector
        public Sprite openSwitch;    // assign in Inspector
        private SpriteRenderer sr;
        public GameObject switchPaper;
        public bool inRange;
        public Stage1BottleManager gemMan;
        public Stage1TextManager textMan;
        public GameObject switchToHide;
        public BoxCollider2D disableCollider;
        public bool runOnce;

        void Start()
        {
            sr = GetComponent<SpriteRenderer>();
        }


        private void Update()
        {
            if (inRange)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    OpenChest();
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                switchPaper.gameObject.SetActive(true);
                textMan.ResetBools();
                textMan.positionChanged = true;
                textMan.arrayPos = 40;
                inRange = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                if (!runOnce)
                {
                    switchPaper.gameObject.SetActive(false);
                    textMan.positionChanged = true;
                    textMan.arrayPos = 44;
                    inRange = false;
                }


            }
        }

        public void OpenChest()
        {
            runOnce = true;
            switchToHide.gameObject.SetActive(false);
            switchPaper.gameObject.SetActive(false);
            gemMan.amountOfGems += 10;
            textMan.ResetBools();
            inRange = false;
            textMan.positionChanged = true;
            textMan.arrayPos = 36;
            sr.sprite = openSwitch; // changes to the open chest sprite
            disableCollider.enabled = false;
            Debug.Log("Open Chest Fired");
        }

    }
}

