using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Alpha.Phases.Geoquest
{
    public class Stage3SetupManager : MonoBehaviour
    {
        public int amountOfGems;
        public bool runOnce;
        public TextMeshProUGUI onScreenGemValue;
        private void Awake()
        {
            if (!runOnce)
            {
                MainGameManager.Instance.currentStagedqwb = 3;
                MainGameManager.Instance.SaveS1S3();
                amountOfGems = MainGameManager.Instance.collectedGems;
                onScreenGemValue.text = amountOfGems.ToString();
                runOnce = true;

            }
        }
    }
}
