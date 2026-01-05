using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Alpha.Phases.Geoquest
{
    public class DiagramManager : MonoBehaviour
    {
        public Stage1TextManager textMan;
        public Stage1BottleManager bMan;

        public bool areWeGrabbingSomething;

        public int amountOfCorrectAnswers;
   

        public Button evaporationButton;
        public Button frictionBUtton;

        public bool firstAnswerCorrect;
        public bool allAnswersCorrect;

        public GameObject chests;
        public GameObject switches;
        private void Awake()
        {
            areWeGrabbingSomething = false;

            frictionBUtton.onClick.AddListener(FrictionPRessed);
            evaporationButton.onClick.AddListener(FrictionPRessed);

        }

        private void Update()
        {
            if(amountOfCorrectAnswers == 1 && !firstAnswerCorrect)
            {
                textMan.positionChanged = true;
                textMan.arrayPos = 30; // not 13 - change when text setup
                firstAnswerCorrect = true;
            }

            if (amountOfCorrectAnswers == 7 && !allAnswersCorrect)
            {
                textMan.positionChanged = true;
                textMan.arrayPos = 31; // not 13 - change when text setup
                allAnswersCorrect = true;
                MainGameManager.Instance.collectedGems = bMan.amountOfGems += 20;
                MainGameManager.Instance.SaveTaskS1();
                chests.gameObject.SetActive(false);
                switches.gameObject.SetActive(true);
            }
        }

        public void UpliftCorrect()
        {
            amountOfCorrectAnswers +=1;
            areWeGrabbingSomething = false;
           // upliftPlaced.gameObject.SetActive(true);
           // upliftButton.gameObject.SetActive(false);
        }

        public void WeatheringCorrect()
        {
            amountOfCorrectAnswers += 1;
            areWeGrabbingSomething = false;

            // weatheringPlaced.gameObject.SetActive(true);
            // weatheringButton.gameObject.SetActive(false);
        }

        public void ErosionCorrect()
        {
            amountOfCorrectAnswers += 1;
            areWeGrabbingSomething = false;

            // erosionPlaced.gameObject.SetActive(true);
            // erosionButton.gameObject.SetActive(false);
        }

        public void CrystalisationCorrect()
        {
            amountOfCorrectAnswers += 1;
            areWeGrabbingSomething = false;

            // crystalIzationPlaced.gameObject.SetActive(true);
            //crystalizationButton.gameObject.SetActive(false);
        }

        public void DepositionCorrect()
        {
            amountOfCorrectAnswers += 1;
            areWeGrabbingSomething = false;

            // despoitionPlaced.gameObject.SetActive(true);
            // depositionButton.gameObject.SetActive(false);
        }

        public void MetamorphismtCorrect()
        {
            amountOfCorrectAnswers += 1;
            areWeGrabbingSomething = false;

            // metamorphismPlaced.gameObject.SetActive(true);
            // metamorhismButton.gameObject.SetActive(false);
        }

        public void MeltingCorrect()
        {
            amountOfCorrectAnswers += 1;
            areWeGrabbingSomething = false;

            // meltingPlaced.gameObject.SetActive(true);
            // meltingButton.gameObject.SetActive(false);
        }

        public void FrictionPRessed()
        {
            textMan.ResetBools();
            textMan.positionChanged = true;
            textMan.arrayPos = 29; // not 13 - change when text setup
        }

      
    }
}
