using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Alpha.Phases.Geoquest
{
    public class Stage2MineralMan : MonoBehaviour
    {
        public Stage2TextManager textMan;
        public int amountOFMinerals;
        public bool runOnce;


        private void Update()
        {
            if (!runOnce)
            {
                if (amountOFMinerals > 4)
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
            textMan.arrayPos = 12;
        }
    }
}
