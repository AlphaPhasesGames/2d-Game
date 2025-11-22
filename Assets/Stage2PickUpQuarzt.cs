using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Alpha.Phases.Geoquest
{
    public class Stage2PickUpQuarzt : MonoBehaviour
    {
        public Stage2TextManager textMan;
        public Stage2MineralMan minMan;
        public bool inRange;
        public GameObject quartzIcon;
        public GameObject quartzObj;
        public GameObject quartzOnMap;
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
            minMan.amountOFMinerals += 1;
            quartzOnMap.gameObject.SetActive(false);
            quartzIcon.gameObject.SetActive(true);
            textMan.positionChanged = true;
            textMan.arrayPos = 10;
            quartzObj.gameObject.SetActive(false);
        }
    }
}

