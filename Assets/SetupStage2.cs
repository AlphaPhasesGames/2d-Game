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
        public TextMeshProUGUI onScreenGemValue;
        private void Awake()
        {
            if (!runOnce)
            {
                MainGameManager.Instance.currentStagedqwb = 2 ;
                MainGameManager.Instance.SaveS1S2();
                amountOfGems = MainGameManager.Instance.collectedGems;
                onScreenGemValue.text = amountOfGems.ToString();

            }
        }
    }
}