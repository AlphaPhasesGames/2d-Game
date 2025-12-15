using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Alpha.Phases.Geoquest
{
    public class Stage2PickUpMica : MonoBehaviour
    {
        public AddToGems gems;
        public Stage2TextManager textMan;
        public Stage2MineralMan minMan;
        public bool inRange;
        public GameObject micaIcon;
        public GameObject micaObj;
        public GameObject micaOnMap;
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
            micaOnMap.gameObject.SetActive(false);
            micaIcon.gameObject.SetActive(true);
            textMan.positionChanged = true;
            gems.AddGems();
            textMan.arrayPos = 8;
            micaObj.gameObject.SetActive(false);
        }
    }
}
