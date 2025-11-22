using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Alpha.Phases.Geoquest
{
    public class Stage2JournalObject : MonoBehaviour
    {
        public Stage2TextManager textMan;
        public GameObject journalObj;
        public GameObject journalUI;
        public GameObject minObjs;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                journalUI.gameObject.SetActive(true);
                textMan.positionChanged = true;
                textMan.arrayPos = 3;
                minObjs.gameObject.SetActive(true);
                Destroy(journalObj);
            }
        }


    }
}

