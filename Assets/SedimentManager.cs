using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Alpha.Phases.Geoquest
{
    public class SedimentManager : MonoBehaviour
    {
        public Stage2TextManager textMan;
        public int amountOfSedis;
        public bool runOnce;


        private void Update()
        {
            if (!runOnce)
            {
                if (amountOfSedis > 3)
                {
                    StartCoroutine(DelayTextAllMins());
                    runOnce = true;
                }
            }

        }


        public IEnumerator DelayTextAllMins()
        {
            yield return new WaitForSeconds(6);
            textMan.positionChanged = true;
            textMan.arrayPos = 34;
        }
    }
}
