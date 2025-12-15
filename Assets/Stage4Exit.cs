using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LoLSDK;
namespace Alpha.Phases.Geoquest
{
    public class Stage4Exit : MonoBehaviour
    {
        public bool submitOnce;
        public Stage4TextManager textMan;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                if (!submitOnce)
                {
                    LOLSDK.Instance.SubmitProgress(0, 100, 100);
                    LOLSDK.Instance.CompleteGame();
                    submitOnce = true;
                }
                textMan.positionChanged = true;
                textMan.arrayPos = 1;
            }
        }
    }
}
