using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LoLSDK;
namespace Alpha.Phases.Geoquest
{
    public class ExitStage3 : MonoBehaviour
    {
        public bool submitOnce;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                if (!submitOnce)
                {
                    LOLSDK.Instance.SubmitProgress(0, 90, 100);
                    submitOnce = true;
                }

                MainGameManager.Instance.currentTask = 0;
                MainGameManager.Instance.SaveTaskS2();
                SceneManager.LoadScene("ExitStage");
            }
        }
    }
}
