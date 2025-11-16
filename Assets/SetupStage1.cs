using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Alpha.Phases.Geoquest
{
    public class SetupStage1 : MonoBehaviour
    {

        public bool runonce;
        // public GameObject whiteFlashOut;
        //  public Animator flashAnim;
        public Stage1TextManager textMan;
        public ArrowPointer arrow;
        public GameObject wPArrow;
        public GameObject rockOnMap;
        public GameObject bottles;
        public Transform nextObjective;

        public GameObject chests;
        public GameObject chestsOnMap;

        public GameObject switchesOnmap;
        public GameObject switches;

        public CameraMan camera;
        public GameObject rockToShow;
        public GameObject journal;
        public GameObject player;
        public GameObject boat;
        public TextMeshProUGUI amountOfGems;

        public GameObject concept1Rock;
        public GameObject concept2RegMeta;

        public GameObject concept3Process;
        public GameObject concept4GeoProcess;

        private void Awake()
        {
            if (!runonce)
            {
                MainGameManager.Instance.currentStagedqwb = 1;
                MainGameManager.Instance.SaveS1S1();
              

                if (MainGameManager.Instance.currentTask == 1)
                {
                    concept1Rock.gameObject.SetActive(true);
                    concept2RegMeta.gameObject.SetActive(true);
                    camera.MoveToPlayer();
                    bottles.gameObject.SetActive(true);
                    journal.gameObject.SetActive(false);
                    rockOnMap.gameObject.SetActive(true);
                    rockToShow.gameObject.SetActive(true);
                    player.gameObject.SetActive(true);
                    boat.gameObject.SetActive(false);
                    textMan.positionChanged = true;
                    wPArrow.gameObject.SetActive(true);
                    arrow.SetTarget(nextObjective);
                    textMan.arrayPos = 5;
                }
               
                //  StartCoroutine(RemoveFlash());

                if (MainGameManager.Instance.currentTask == 2)
                {
                    concept1Rock.gameObject.SetActive(true);
                    concept2RegMeta.gameObject.SetActive(true);
                    concept3Process.gameObject.SetActive(true);
                    amountOfGems.text = MainGameManager.Instance.collectedGems.ToString();
                    camera.MoveToPlayer();
                    player.gameObject.SetActive(true);
                    textMan.positionChanged = true;
                    textMan.arrayPos = 13;
                    journal.gameObject.SetActive(false);
                    wPArrow.gameObject.SetActive(false);
                    chests.gameObject.SetActive(true);
                    chestsOnMap.gameObject.SetActive(true);
                    boat.gameObject.SetActive(false);
                }

                if (MainGameManager.Instance.currentTask == 3)
                {
                    concept1Rock.gameObject.SetActive(true);
                    concept2RegMeta.gameObject.SetActive(true);
                    concept3Process.gameObject.SetActive(true);
                    concept4GeoProcess.gameObject.SetActive(true);
                    camera.MoveToPlayer();
                    player.gameObject.SetActive(true);
                    textMan.positionChanged = true;
                    textMan.arrayPos = 32;
                    journal.gameObject.SetActive(false);
                    wPArrow.gameObject.SetActive(false);
                    //switches.gameObject.SetActive(false);
                    switchesOnmap.gameObject.SetActive(true);
                    boat.gameObject.SetActive(false);
                }
                runonce = true;
            }

            // public IEnumerator RemoveFlash()
            // {
            //      yield return new WaitForSeconds(1);
            //      whiteFlashOut.gameObject.SetActive(false);
            //   }
        }
    }
}