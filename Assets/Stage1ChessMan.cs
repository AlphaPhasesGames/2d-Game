using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Alpha.Phases.Geoquest
{
    public class Stage1ChessMan : MonoBehaviour
    {

        public int chestCollected;
        public Stage1TextManager textMan;
        public bool runOnce;
        public bool runOnce2;
        public ArrowPointer arrow;
        public GameObject wPArrow;
        public Transform nextObjective;
        public BoxCollider2D boardBox;
        private void Update()
        {

            if (chestCollected >= 1)
            {
                if (!runOnce)
                {
                    StartCoroutine(DelayText1());
                    runOnce = true;
                }

            }


            if (chestCollected >= 7)
            {
                if (!runOnce2)
                {
                    StartCoroutine(DelayText2());
                    wPArrow.gameObject.SetActive(true);
                    arrow.SetTarget(nextObjective);
                    boardBox.enabled = true;
                    runOnce2 = true;
                }
               
            }
        }

        public IEnumerator DelayText1()
        {
            yield return new WaitForSeconds(7);
            textMan.positionChanged = true;
            textMan.arrayPos = 26;
            Debug.Log("This Extra Text Runs");
        }

        public IEnumerator DelayText2()
        {
            yield return new WaitForSeconds(6);
            textMan.positionChanged = true;
            textMan.arrayPos = 27;
            Debug.Log("This Extra Text Runs as well");
        }
    }
}
