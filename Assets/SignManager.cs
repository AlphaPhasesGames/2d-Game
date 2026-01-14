using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Alpha.Phases.Geoquest
{
    public class SignManager : MonoBehaviour
    {
        public int amountOfSwitches;
        public Stage1TextManager textMan;
        public Animator moveRock;
        public bool runOnce;
        private void Update()
        {
            if (!runOnce) 
            {
                if (amountOfSwitches >= 2)
                {
                    StartCoroutine(MoveToFinalText());
                    runOnce = true;
                }
            }
           
        }

        public IEnumerator MoveToFinalText()
        {
            yield return new WaitForSeconds(7);
            moveRock.SetBool("moveRock", true);
            textMan.positionChanged = true;
            textMan.arrayPos = 43;
        }
    }
}
