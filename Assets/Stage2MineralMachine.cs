using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Alpha.Phases.Geoquest
{
    public class Stage2MineralMachine : MonoBehaviour
    {
        public Stage2MineralMan minMan;
        public Stage2TextManager textMan;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                if(minMan.amountOFMinerals > 4)
                {
                    textMan.positionChanged = true;
                    textMan.arrayPos = 13;
                }
                Debug.Log("In machine range");
               
            }
        }
    }
}
