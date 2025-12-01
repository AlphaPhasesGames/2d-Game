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
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                LOLSDK.Instance.SubmitProgress(0, 30, 100);
                MainGameManager.Instance.currentTask = 0;
                MainGameManager.Instance.collectedGems = bMan.amountOfGems;
                MainGameManager.Instance.SaveTaskS1();
                SceneManager.LoadScene("Stage 2");
            }

        }
    }
}
