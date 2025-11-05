using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alpha.Phases.Geoquest
{
    public class PickupBook : MonoBehaviour
    {
        public Stage1TextManager textMan;
        public GameObject bookToDestroy;
        public GameObject invShow;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                textMan.positionChanged = true;
                textMan.arrayPos = 5;
         
                invShow.gameObject.SetActive(true);
                Destroy(bookToDestroy);
            }
        }
    }
}
