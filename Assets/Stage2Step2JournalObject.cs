using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Alpha.Phases.Geoquest
{
    public class Stage2Step2JournalObject : MonoBehaviour
    {
        public Stage2TextManager textMan;
        public OpenJournal journMan;
        public GameObject journalObj;
        public GameObject journalUI;
        public GameObject minObjs;
        public GameObject sediSide;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                journMan.pageNo = 3;
                journalUI.gameObject.SetActive(true);
                textMan.positionChanged = true;
                textMan.arrayPos = 28;
                minObjs.gameObject.SetActive(true);
                sediSide.gameObject.SetActive(true);
                Destroy(journalObj);
            }
        }

    }
}
