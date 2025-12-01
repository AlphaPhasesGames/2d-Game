using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Alpha.Phases.Geoquest
{
    public class Stage2PickupSilt : MonoBehaviour
    {
        public Stage2TextManager textMan;
        public SedimentManager sediMan;
        public bool inRange;
        public GameObject siltIcon;
        public GameObject siltObj;
        public GameObject siltOnMap;
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
            siltOnMap.gameObject.SetActive(false);
            siltIcon.gameObject.SetActive(true);
            textMan.positionChanged = true;
            textMan.arrayPos = 31;
            siltObj.gameObject.SetActive(false);
        }
    }
}