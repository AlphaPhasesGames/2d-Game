using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Alpha.Phases.Geoquest
{
    public class Stage2PickUpCalcite : MonoBehaviour
    {
        public AddToGems gems;
        public Stage2TextManager textMan;
        public Stage2MineralMan minMan;
        public bool inRange;
        public GameObject calciteIcon;
        public GameObject calciteObj;
        public GameObject calciteOnMap;
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
            calciteOnMap.gameObject.SetActive(false);
            calciteIcon.gameObject.SetActive(true);
            textMan.positionChanged = true;
            gems.AddGems();
            textMan.arrayPos = 9;
            calciteObj.gameObject.SetActive(false);
        }
    }
}
