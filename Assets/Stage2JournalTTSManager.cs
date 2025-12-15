using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
using LoLSDK;

namespace Alpha.Phases.Geoquest
{
    public class Stage2JournalTTSManager : MonoBehaviour
    {
        public Button concept1buttonProcess;
        public Button concept2buttonGeoProcess;
        public Button concept3buttonRock;
        public Button concept4buttonRegMeta;
        public Button concept5buttonSediment;
        public Button concept6etamorphicRock;
        public Button concept7CombinationMinerals;
        private void Awake()
        {
            concept1buttonProcess.onClick.AddListener(SpeakJournalConcept1Process);
            concept2buttonGeoProcess.onClick.AddListener(SpeakJournalConcept2GeoProcess);
            concept3buttonRock.onClick.AddListener(SpeakJournalConcept3Rock);
            concept4buttonRegMeta.onClick.AddListener(SpeakJournalConcept4RefMeta);
            concept5buttonSediment.onClick.AddListener(SpeakJournalConcept5Sediment);
            concept6etamorphicRock.onClick.AddListener(SpeakJournalConcept6MetamorphicRock);
            concept7CombinationMinerals.onClick.AddListener(SpeakJournalConcept7CombinationMinerals);
        }


        public void SpeakJournalConcept1Process()
        {
            LOLSDK.Instance.SpeakText("concept1Process");
        }

        public void SpeakJournalConcept2GeoProcess()
        {
            LOLSDK.Instance.SpeakText("concept2GeoProcess");
        }

        public void SpeakJournalConcept3Rock()
        {
            LOLSDK.Instance.SpeakText("concept3Rock");
        }

        public void SpeakJournalConcept4RefMeta()
        {
            LOLSDK.Instance.SpeakText("concept4RegionalMeta");
        }

        public void SpeakJournalConcept5Sediment()
        {
            LOLSDK.Instance.SpeakText("concept5Sediment");
        }

        public void SpeakJournalConcept6MetamorphicRock()
        {
            LOLSDK.Instance.SpeakText("concept6MetamorphicRock");
        }

        public void SpeakJournalConcept7CombinationMinerals()
        {
            LOLSDK.Instance.SpeakText("concept7CombinationMinerals");
        }

    }
}
