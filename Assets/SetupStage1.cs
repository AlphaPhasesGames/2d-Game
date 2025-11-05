using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alpha.Phases.Geoquest
{
    public class SetupStage1 : MonoBehaviour
    {

        public bool runonce;
       // public GameObject whiteFlashOut;
      //  public Animator flashAnim;
        private void Awake()
        {
            if (!runonce)
            {
                MainGameManager.Instance.currentStagedqwb = 1;
                MainGameManager.Instance.SaveS1S1();
                runonce = true;
              //  StartCoroutine(RemoveFlash());
            }
        }

       // public IEnumerator RemoveFlash()
       // {
      //      yield return new WaitForSeconds(1);
      //      whiteFlashOut.gameObject.SetActive(false);
     //   }
    }
}