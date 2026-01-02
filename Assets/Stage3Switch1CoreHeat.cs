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

        private void Awake()
        {
            pullSwitch.onClick.AddListener(PullSwitch);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                textPanal.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    PullSwitch();
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                textPanal.gameObject.SetActive(false);
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
