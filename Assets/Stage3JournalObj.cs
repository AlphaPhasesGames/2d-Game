using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Alpha.Phases.Geoquest
{
    public class Stage3JournalObj : MonoBehaviour
    {
        public Stage3TextManager textMan;
        public Stage3OpenJournal journMan;
        public GameObject journalObj;
        public GameObject journalUI;
       // public GameObject minObjs;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                journMan.pageNo = 5;
                journalUI.gameObject.SetActive(true);
                textMan.positionChanged = true;
                textMan.arrayPos = 4;
                Destroy(journalObj);
            }
        }


    }
}

