using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace Alpha.Phases.Geoquest
{

    public class Stage1BottleManager : MonoBehaviour
    {
        public int amountOfBottles;
        public int amountOfGems;
        public TextMeshProUGUI onScreenGemValue;
        public Stage1TextManager textMan;
        public bool bottlesCollected;
        public AudioSource gemSFX;

        private void Update()
        {
            onScreenGemValue.text = amountOfGems.ToString();
            if(!bottlesCollected && amountOfBottles >= 5)
            {
                textMan.positionChanged = true;
                textMan.arrayPos = 18;
                bottlesCollected = true;
                amountOfGems += 20;
                gemSFX.Play();
            }
        }

    }
}
