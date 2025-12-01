using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Alpha.Phases.Geoquest
{
    public class SetupStage2 : MonoBehaviour
    {
        public int amountOfGems;
        public bool runOnce;
        public OpenJournal journal;
        public TextMeshProUGUI onScreenGemValue;
        public GameObject secondCaveStartPos;
        public GameObject player;
        public GameObject step1;
        public GameObject step2;
        public GameObject step1Map;
        public GameObject step2Map;
        private void Awake()
        {
            if (!runOnce)
            {
                if (MainGameManager.Instance.stage2Part2)
                {
                    journal.pageNo = 3;
                    player.transform.position = secondCaveStartPos.transform.position;
                    step1.gameObject.SetActive(false);
                    step2.gameObject.SetActive(true);
                    MainGameManager.Instance.currentTask = 2;
                    step1Map.gameObject.SetActive(false);
                    step2Map.gameObject.SetActive(true);
                    Debug.Log("Player moved");
                }
                MainGameManager.Instance.currentStagedqwb = 2 ;
                MainGameManager.Instance.SaveS1S2();
                amountOfGems = MainGameManager.Instance.collectedGems;
                onScreenGemValue.text = amountOfGems.ToString();

            }
        }
    }
}