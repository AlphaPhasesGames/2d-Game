using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Alpha.Phases.Geoquest
{
    public class Level1SignMan : MonoBehaviour
    {
      
        public Stage1TextManager textMan;
        public GameObject sideScraps;
        public bool runOnce;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.CompareTag("Player"))
            {
                if (!runOnce)
                {
                    sideScraps.gameObject.SetActive(false);
                    textMan.positionChanged = true;
                    textMan.arrayPos = 28;
                    runOnce = true;
                }

            }
        }
    }
}
