using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Alpha.Phases.Geoquest
{
    public class Chest5TextPop : MonoBehaviour
    {
        public Stage1TextManager textMan;
        public bool inRange;
        public GameObject meltingScrap;

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
            meltingScrap.gameObject.SetActive(true);
            textMan.positionChanged = true;
            textMan.arrayPos = 23;
        }
    }
}
