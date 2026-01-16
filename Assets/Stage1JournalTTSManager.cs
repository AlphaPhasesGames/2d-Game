using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
using LoLSDK;

namespace Alpha.Phases.Geoquest
{
    public class Stage1JournalTTSManager : MonoBehaviour
    {
        public Button concept1buttonProcess;
        public Button concept2buttonGeoProcess;
        public Button concept3buttonRock;
        public Button concept4buttonRegMeta;

        public Button page2SandstoneText1;
        public Button page2SandstoneText2;

        public Button page3SlateText1;
        public Button page3SlateText2;

        public Button page4BasaltText1;
        public Button page4BasaltText2;

        private void Awake()
        {
            concept1buttonProcess.onClick.AddListener(SpeakJournalConcept1Process);
            concept2buttonGeoProcess.onClick.AddListener(SpeakJournalConcept2GeoProcess);
            concept3buttonRock.onClick.AddListener(SpeakJournalConcept3Rock);
            concept4buttonRegMeta.onClick.AddListener(SpeakJournalConcept4RefMeta);

            page2SandstoneText1.onClick.AddListener(SpeakJournalSandstoneText1);
            page2SandstoneText2.onClick.AddListener(SpeakJournalSandstoneText2);

            page3SlateText1.onClick.AddListener(SpeakJournalSlateText1);
            page3SlateText2.onClick.AddListener(SpeakJournalSlateText2);

            page4BasaltText1.onClick.AddListener(SpeakJournalBasaltText1);
            page4BasaltText2.onClick.AddListener(SpeakJournalBasaltText2);
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

        public void SpeakJournalSandstoneText1()
        {
            LOLSDK.Instance.SpeakText("journalSandStone1Text");
        }
        public void SpeakJournalSandstoneText2()
        {
            LOLSDK.Instance.SpeakText("journalSandStone2Text");
        }
        public void SpeakJournalSlateText1()
        {
            LOLSDK.Instance.SpeakText("journalSlate1Text");
        }
        public void SpeakJournalSlateText2()
        {
            LOLSDK.Instance.SpeakText("journalSlate2Text");
        }
        public void SpeakJournalBasaltText1()
        {
            LOLSDK.Instance.SpeakText("journalBasalt1Text");
        }
        public void SpeakJournalBasaltText2()
        {
            LOLSDK.Instance.SpeakText("journalBasalt2Text");
        }

    }
}
