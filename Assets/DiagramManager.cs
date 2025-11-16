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

        public GameObject upliftPlaced;
        public GameObject weatheringPlaced;
        public GameObject erosionPlaced;
        public GameObject despoitionPlaced;
        public GameObject crystalIzationPlaced;
        public GameObject metamorphismPlaced;
        public GameObject meltingPlaced;

        public int amountOfCorrectAnswers;
        public Button upliftButton;
        public Button weatheringButton;
        public Button erosionButton;
        public Button depositionButton;
        public Button crystalizationButton;
        public Button metamorhismButton;
        public Button meltingButton;

        public Button evaporationButton;
        public Button frictionBUtton;

        public bool firstAnswerCorrect;
        public bool allAnswersCorrect;

        public GameObject chests;
        private void Awake()
        {
            upliftButton.onClick.AddListener(UpliftCorrect);
            weatheringButton.onClick.AddListener(WeatheringCorrect);
            erosionButton.onClick.AddListener(ErosionCorrect);
            depositionButton.onClick.AddListener(DepositionCorrect);
            crystalizationButton.onClick.AddListener(CrystalisationCorrect);
            metamorhismButton.onClick.AddListener(MetamorphismtCorrect);
            meltingButton.onClick.AddListener(MeltingCorrect);

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
            }
        }

        public void UpliftCorrect()
        {
            amountOfCorrectAnswers +=1;
            upliftPlaced.gameObject.SetActive(true);
            upliftButton.gameObject.SetActive(false);
        }

        public void WeatheringCorrect()
        {
            amountOfCorrectAnswers += 1;
            weatheringPlaced.gameObject.SetActive(true);
            weatheringButton.gameObject.SetActive(false);
        }

        public void ErosionCorrect()
        {
            amountOfCorrectAnswers += 1;
            erosionPlaced.gameObject.SetActive(true);
            erosionButton.gameObject.SetActive(false);
        }

        public void CrystalisationCorrect()
        {
            amountOfCorrectAnswers += 1;
            crystalIzationPlaced.gameObject.SetActive(true);
            crystalizationButton.gameObject.SetActive(false);
        }

        public void DepositionCorrect()
        {
            amountOfCorrectAnswers += 1;
            despoitionPlaced.gameObject.SetActive(true);
            depositionButton.gameObject.SetActive(false);
        }

        public void MetamorphismtCorrect()
        {
            amountOfCorrectAnswers += 1;
            metamorphismPlaced.gameObject.SetActive(true);
            metamorhismButton.gameObject.SetActive(false);
        }

        public void MeltingCorrect()
        {
            amountOfCorrectAnswers += 1;
            meltingPlaced.gameObject.SetActive(true);
            meltingButton.gameObject.SetActive(false);
        }

        public void FrictionPRessed()
        {
            textMan.ResetBools();
            textMan.positionChanged = true;
            textMan.arrayPos = 29; // not 13 - change when text setup
        }
    }
}
