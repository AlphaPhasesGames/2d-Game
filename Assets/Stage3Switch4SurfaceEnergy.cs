using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Alpha.Phases.Geoquest
{
    public class Stage3Switch4SurfaceEnergy : MonoBehaviour
    {
        public AddToGems gems;
        public Stage3SwitchManager switchMan;
        public GameObject switchUp;
        public GameObject switchDown;
        public GameObject switch4OnMap;
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
            gems.AddGems();
            switch4OnMap.gameObject.SetActive(false);
            switchDown.gameObject.SetActive(true);
            switchUp.gameObject.SetActive(false);
            switchMan.PullSwitch(physicalID: 4, sequenceID: 2);
        }
    }
}
