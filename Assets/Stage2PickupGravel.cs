using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Alpha.Phases.Geoquest
{
    public class Stage2PickupGravel : MonoBehaviour
    {
        public Stage2TextManager textMan;
        public SedimentManager sediMan;
        public bool inRange;
        public GameObject gravelIcon;
        public GameObject gravelObj;
        public GameObject gravelOnMap;
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
                inRange = true;
            }

        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                inRange = false;
            }

        }

        public void OpenChest()
        {
            sediMan.amountOfSedis += 1;
            gravelOnMap.gameObject.SetActive(false);
            gravelIcon.gameObject.SetActive(true);
            textMan.positionChanged = true;
            textMan.arrayPos = 32;
            gravelObj.gameObject.SetActive(false);
        }
    }
}