using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Alpha.Phases.Geoquest
{
    public class Stage3Switch1CoreHeat : MonoBehaviour
    {
        public AddToGems gems;
        public Stage3TextManager textMan;
        public Stage3SwitchManager switchMan;
        public GameObject switchUp;
        public GameObject switchDown;
        public GameObject switchOnMap;
        public GameObject textPanal;
        public Button pullSwitch;
        public bool inRange;
        private void Awake()
        {
            pullSwitch.onClick.AddListener(PullSwitch);
        }

        private void Update()
        {
            if (inRange)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    PullSwitch();
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                textPanal.gameObject.SetActive(true);
                inRange = true;
            }
        }

      
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                textPanal.gameObject.SetActive(false);
                inRange = false;
            }
        }

        public void PullSwitch()
        {
            switchDown.gameObject.SetActive(true);
            switchUp.gameObject.SetActive(false);
            textMan.positionChanged = true;
            gems.AddGems();
            textMan.arrayPos = 8;
            switchOnMap.gameObject.SetActive(false);
            switchMan.PullSwitch(physicalID: 1, sequenceID: 1);
        }
    }
}
