using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Alpha.Phases.Geoquest
{
    public class Stage1RockTrigger : MonoBehaviour
    {
        public Stage1TextManager textMan;
       
        public GameObject rock;
        public GameObject rockTriggerBox;
        public GameObject arrow;
        public GameObject chestOnMap;
        public GameObject chests;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Rock"))
            {

                chests.gameObject.SetActive(true);
                Destroy(rock);
                chestOnMap.gameObject.SetActive(true);
                arrow.gameObject.SetActive(false);
                textMan.positionChanged = true;
                textMan.arrayPos = 13;
                MainGameManager.Instance.currentTask = 2;
                MainGameManager.Instance.SaveTaskS1();
                rockTriggerBox.gameObject.SetActive(false);
                Debug.Log("Rock in trigger");
            }
        }
    }
}
