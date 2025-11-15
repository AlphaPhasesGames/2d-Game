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
        public GameObject bottles;
        public GameObject rock;
        public GameObject arrowToDisable;
        public GameObject rockOnMap;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                rockOnMap.gameObject.SetActive(true);
                textMan.positionChanged = true;
                textMan.arrayPos = 5;
                arrowToDisable.gameObject.SetActive(false);
                invShow.gameObject.SetActive(true);
                Destroy(bookToDestroy);
                rock.gameObject.SetActive(true);
                bottles.gameObject.SetActive(true);
            }
        }
    }
}
