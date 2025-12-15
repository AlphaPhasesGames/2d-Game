using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LoLSDK;
namespace Alpha.Phases.Geoquest
{
    public class Stage1EndOfLevel : MonoBehaviour
    {
        public Stage1BottleManager bMan;
        public bool runOnce;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                if (!runOnce)
                {
                    LOLSDK.Instance.SubmitProgress(0, 30, 100);
                    runOnce = true;
                }
            
                MainGameManager.Instance.currentTask = 0;
                MainGameManager.Instance.collectedGems = bMan.amountOfGems;
                MainGameManager.Instance.SaveTaskS1();
                SceneManager.LoadScene("Stage 2");
            }

        }
    }
}
