using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using TMPro;

namespace Alpha.Phases.Geoquest
{
    public class Stage3LangMan : MonoBehaviour
    {
        public TextMeshProUGUI stage3Text1;
        public TextMeshProUGUI stage3Text2;
        public TextMeshProUGUI stage3Text3;
        public TextMeshProUGUI stage3Text4;
        public TextMeshProUGUI stage3Text5;
        public TextMeshProUGUI stage3Text6;
        public TextMeshProUGUI stage3Text7;
        public TextMeshProUGUI stage3Text8;
        public TextMeshProUGUI stage3Text9;
        public TextMeshProUGUI stage3Text10;
        public TextMeshProUGUI stage3Text11;
        public TextMeshProUGUI stage3Text12;
        public TextMeshProUGUI stage3Text13;
        public TextMeshProUGUI stage3Text14;
        public TextMeshProUGUI stage3Text15;
        public TextMeshProUGUI stage3Text16;
        public TextMeshProUGUI stage3Text17;

        public TextMeshProUGUI journalTitle;
        public TextMeshProUGUI journalPage1Concept1;
        public TextMeshProUGUI journalPage1Concept2;
        public TextMeshProUGUI journalPage1Concept3;
        public TextMeshProUGUI journalPage1Concept4;
        public TextMeshProUGUI journalPage1Concept5;
        public TextMeshProUGUI journalPage1Concept6;
        public TextMeshProUGUI journalPage1Concept7;
        public TextMeshProUGUI journalPage1Concept8;
        public TextMeshProUGUI journalPage1Concept9;
        public TextMeshProUGUI journalPage1Concept10;

        public TextMeshProUGUI journalTitle2;
        public TextMeshProUGUI journalMineralClay;
        public TextMeshProUGUI journalMineralClay2;
        public TextMeshProUGUI journalMineralMica;
        public TextMeshProUGUI journalMineralCalcite;
        public TextMeshProUGUI journalMineralSQuartz;
        public TextMeshProUGUI journalMineralFeldspar;


        public TextMeshProUGUI journalMineralGraniteName;
        public TextMeshProUGUI journalMineralLimestoneName;
        public TextMeshProUGUI journalMineralSlateName;

        public TextMeshProUGUI switch1CoreHeat;
        public TextMeshProUGUI swtitch2Magma;
        public TextMeshProUGUI switch3Tectonic;
        public TextMeshProUGUI swtich4Release;

        public TextMeshProUGUI journalTitle3;
        public TextMeshProUGUI journal2Clay;
        public TextMeshProUGUI journal2Silt;
        public TextMeshProUGUI journal2Gravel;
        public TextMeshProUGUI journal2Sand;

        public TextMeshProUGUI journalTitle4;
        public TextMeshProUGUI journalpage5SubTitleCoreHeat;
        public TextMeshProUGUI journalpage5SubTitleCoreHeatDeets;
        public TextMeshProUGUI journalpage5MagmaSubTitle;
        public TextMeshProUGUI journalpage5MagmaSubTitleDeets;
        public TextMeshProUGUI journalpage5MTectonicSubTitle;
        public TextMeshProUGUI journalpage5MTectonicSubTitleDeetys;
        public TextMeshProUGUI journalpage5MSurfaceReleaseSubTitle;
        public TextMeshProUGUI journalpage5MSurfaceReleaseSubTitleDeets;

        private void Awake()
    {
        JSONNode defs = SharedState.LanguageDefs;

        stage3Text1.text = defs["stage3Text1"];
        stage3Text2.text = defs["stage3Text2"];
        stage3Text3.text = defs["stage3Text3"];
        stage3Text4.text = defs["stage3Text4"];
        stage3Text5.text = defs["stage3Text5"];
        stage3Text6.text = defs["stage3Text6"];
        stage3Text7.text = defs["stage3Text7"];
        stage3Text8.text = defs["stage3Text8"];
        stage3Text9.text = defs["stage3Text9"];
        stage3Text10.text = defs["stage3Text10"];
        stage3Text11.text = defs["stage3Text11"];
        stage3Text12.text = defs["stage3Text12"];
        stage3Text13.text = defs["stage3Text13"];
        stage3Text14.text = defs["stage3Text14"];
        stage3Text15.text = defs["stage3Text15"];
        stage3Text16.text = defs["stage3Text16"];
        stage3Text17.text = defs["stage3Text17"];

            journalTitle.text = defs["stage2JournalTitle"];
            journalPage1Concept1.text = defs["concept1Process"];
            journalPage1Concept2.text = defs["concept2GeoProcess"];
            journalPage1Concept3.text = defs["concept3Rock"];
            journalPage1Concept4.text = defs["concept4RegionalMeta"];
            journalPage1Concept5.text = defs["concept5Sediment"];
            journalPage1Concept6.text = defs["concept6MetamorphicRock"];
            journalPage1Concept7.text = defs["concept7CombinationMinerals"];
            journalPage1Concept8.text = defs["concept10RockCycle"];
            journalPage1Concept9.text = defs["concept8FoldingFaulting"];
            journalPage1Concept10.text = defs["concept9IgenousRock"];

            journalTitle2.text = defs["stage2JournalTitle2"];
            journalMineralClay.text = defs["stage2MineralClay"];
            journalMineralClay2.text = defs["stage2MineralClay"];
            journalMineralMica.text = defs["stage2MineralMica"];
            journalMineralCalcite.text = defs["stage2MineralCalcite"];
            journalMineralSQuartz.text = defs["stage2MineralQuartz"];
            journalMineralFeldspar.text = defs["stage2MineralFeldspar"];

            switch1CoreHeat.text = defs["stage3SwitchCoreHeat"];
            swtitch2Magma.text = defs["stage3SwitchMagma"];
            switch3Tectonic.text = defs["stage3SwitchTectonic"]; 
            swtich4Release.text = defs["stage3SwitchEnergyRelease"]; 

        journalMineralGraniteName.text = defs["stage2GraniteName"];
            journalMineralLimestoneName.text = defs["stage2LimestoneName"];
            journalMineralSlateName.text = defs["stage2SlateName"];

            journalTitle3.text = defs["stage2SedimentSandJournalP2"];
            journal2Clay.text = defs["stage2MineralClay"];
            journal2Silt.text = defs["stage2SedimentSilt"];
            journal2Gravel.text = defs["stage2SedimentGravel"];
            journal2Sand.text = defs["stage2SedimentSand"];

            journalTitle4.text = defs["stage3JournalPage5Title"];
            journalpage5SubTitleCoreHeat.text = defs["stage3JournalPage5CoreHeatTitle"];
            journalpage5SubTitleCoreHeatDeets.text = defs["stage3JournalPage5CoreHeatDeets"];
            journalpage5MagmaSubTitle.text = defs["stage3JournalPage5MagmaRegTitle"];
            journalpage5MagmaSubTitleDeets.text = defs["stage3JournalPage5MagmaRegDeets"];
            journalpage5MTectonicSubTitle.text = defs["stage3JournalPage5TectonicTitle"];
            journalpage5MTectonicSubTitleDeetys.text = defs["stage3JournalPage5TectonicDeets"];
            journalpage5MSurfaceReleaseSubTitle.text = defs["stage3JournalPage5SurfaceEnergyTitle"];
            journalpage5MSurfaceReleaseSubTitleDeets.text = defs["stage3JournalPage5SurfaceEnergyDeets"];

        //  task1.text = defs["stage1Task1"];
        //  task2.text = defs["stage1Task2"];
        //  task3.text = defs["stage1Task3"];
    }
    }
}
