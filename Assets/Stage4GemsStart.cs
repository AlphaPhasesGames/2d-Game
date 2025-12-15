using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace Alpha.Phases.Geoquest
{
    public class Stage4GemsStart : MonoBehaviour
    {
        public int amountOfGems;
        public bool runOnce;
        public TextMeshProUGUI onScreenGemValue;
        private void Awake()
        {
            if (!runOnce)
            {
           
                amountOfGems = MainGameManager.Instance.collectedGems;
                onScreenGemValue.text = amountOfGems.ToString();
                runOnce = true;

            }
        }
    }
}
