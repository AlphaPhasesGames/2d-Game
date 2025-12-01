using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
using LoLSDK;
using TMPro;

namespace Alpha.Phases.Geoquest
{

    public class Stage2Step2CompressMachine : MonoBehaviour
    {
        public Stage2TextManager textMan;
        public SedimentManager sediMan;
        public GameObject sediGame;
        public bool runOnce;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                if(sediMan.amountOfSedis > 3)
                {
                    if (!runOnce)
                    {
                        sediGame.gameObject.SetActive(true);
                        textMan.positionChanged = true;
                        textMan.arrayPos = 35;
                        runOnce = true;
                    }

                }
            }
        }
    }
}
