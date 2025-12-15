using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
using LoLSDK;

namespace Alpha.Phases.Geoquest
{
    public class Stage3JournalTTSManager : MonoBehaviour
    {
        public Button concept1buttonProcess;
        public Button concept2buttonGeoProcess;
        public Button concept3buttonRock;
        public Button concept4buttonRegMeta;
        public Button concept5buttonSediment;
        public Button concept6etamorphicRock;
        public Button concept7CombinationMinerals;
        public Button concept8FoldingFaulting;
        public Button concept9IgenousRock;
        public Button concept10RockCycle;

        public Button journalSwitch1;
        public Button journalSwitch2;
        public Button journalSwitch3;
        public Button journalSwitch4;
        private void Awake()
        {
            concept1buttonProcess.onClick.AddListener(SpeakJournalConcept1Process);
            concept2buttonGeoProcess.onClick.AddListener(SpeakJournalConcept2GeoProcess);
            concept3buttonRock.onClick.AddListener(SpeakJournalConcept3Rock);
            concept4buttonRegMeta.onClick.AddListener(SpeakJournalConcept4RefMeta);
            concept5buttonSediment.onClick.AddListener(SpeakJournalConcept5Sediment);
            concept6etamorphicRock.onClick.AddListener(SpeakJournalConcept6MetamorphicRock);
            concept7CombinationMinerals.onClick.AddListener(SpeakJournalConcept7CombinationMinerals);
            concept8FoldingFaulting.onClick.AddListener(SpeakJournalConcept8FoldingFaulting);
            concept9IgenousRock.onClick.AddListener(SpeakJournalConcept9IgenousRock);
            concept10RockCycle.onClick.AddListener(SpeakJournalConcept10RockCycle);
            journalSwitch1.onClick.AddListener(SpeakJournalSwitch1);
            journalSwitch2.onClick.AddListener(SpeakJournalSwitch2);
            journalSwitch3.onClick.AddListener(SpeakJournalSwitch3);
            journalSwitch4.onClick.AddListener(SpeakJournalSwitch4);
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

        public void SpeakJournalConcept8FoldingFaulting()
        {
            LOLSDK.Instance.SpeakText("concept8FoldingFaulting");
        }

        public void SpeakJournalConcept9IgenousRock()
        {
            LOLSDK.Instance.SpeakText("concept9IgenousRock");
        }

        public void SpeakJournalConcept10RockCycle()
        {
            LOLSDK.Instance.SpeakText("concept10RockCycle");
        }

        public void SpeakJournalSwitch1()
        {
            LOLSDK.Instance.SpeakText("journalSwitchOrder1");
        }

        public void SpeakJournalSwitch2()
        {
            LOLSDK.Instance.SpeakText("journalSwitchOrder2");
        }

        public void SpeakJournalSwitch3()
        {
            LOLSDK.Instance.SpeakText("journalSwitchOrder3");
        }
        public void SpeakJournalSwitch4()
        {
            LOLSDK.Instance.SpeakText("journalSwitchOrder4");
        }

    }
}