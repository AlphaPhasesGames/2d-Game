using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Alpha.Phases.Geoquest
{
    public class Stage2MineralMachine : MonoBehaviour
    {
        public Stage2MineralMan minMan;
        public Stage2TextManager textMan;
        public bool runOnce;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                if(minMan.amountOFMinerals > 4)
                {
                    if (!runOnce)
                    {
                        textMan.positionChanged = true;
                        textMan.arrayPos = 13;
                        runOnce = true;
                    }

                }
                Debug.Log("In machine range");
               
            }
        }
    }
}
