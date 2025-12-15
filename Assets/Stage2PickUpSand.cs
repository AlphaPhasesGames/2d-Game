using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Alpha.Phases.Geoquest
{
    public class Stage2PickUpSand : MonoBehaviour
    {
        public AddToGems gems;
        public Stage2TextManager textMan;
        public SedimentManager sediMan;
        public bool inRange;
        public GameObject sandIcon;
        public GameObject sandObj;
        public GameObject sandOnMap;
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
            sandOnMap.gameObject.SetActive(false);
            sandIcon.gameObject.SetActive(true);
            textMan.positionChanged = true;
            gems.AddGems();
            textMan.arrayPos = 30;
            sandObj.gameObject.SetActive(false);
        }
    }
}
