using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Alpha.Phases.Geoquest
{
    public class Stage2PickupGoldFlakes : MonoBehaviour
    {
        public AddToGems gems;
        public Stage2TextManager textMan;
        public SedimentManager sediMan;
        public bool inRange;
        public GameObject gFlakesIcon;
        public GameObject gFlakesObj;
        public GameObject gFlakesOnMap;
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
            gFlakesOnMap.gameObject.SetActive(false);
            gFlakesIcon.gameObject.SetActive(true);
            textMan.positionChanged = true;
            gems.AddGems();

            textMan.arrayPos = 33;
            gFlakesObj.gameObject.SetActive(false);
        }
    }
}