using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace Alpha.Phases.Geoquest
{
    public class AddToGems : MonoBehaviour
    {
      
        public int amountOfGems;
        public TextMeshProUGUI onScreenGemValue;
     

       
        public AudioSource gemSFX;

        private void Awake()
        {
            amountOfGems = MainGameManager.Instance.collectedGems;
        }

        private void Update()
        {
            onScreenGemValue.text = amountOfGems.ToString();
                                       
        }

        public void AddGems()
        {
            MainGameManager.Instance.collectedGems = amountOfGems += 20;
         
            gemSFX.Play();
        }
    }
}

