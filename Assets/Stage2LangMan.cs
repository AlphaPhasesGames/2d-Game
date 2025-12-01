using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using TMPro;

namespace Alpha.Phases.Geoquest
{
    public class Stage2LangMan : MonoBehaviour
    {
        public TextMeshProUGUI journalTitle;
        public TextMeshProUGUI journalPage1Concept1;
        public TextMeshProUGUI journalPage1Concept2;
        public TextMeshProUGUI journalPage1Concept3;
        public TextMeshProUGUI journalPage1Concept4;
        public TextMeshProUGUI journalPage1Concept5;
        public TextMeshProUGUI journalPage1Concept6;
        public TextMeshProUGUI journalPage1Concept7;

        public TextMeshProUGUI journalTitle2;
        public TextMeshProUGUI journalMineralClay;
        public TextMeshProUGUI journalMineralClay2;
        public TextMeshProUGUI journalMineralMica;
        public TextMeshProUGUI journalMineralCalcite;
        public TextMeshProUGUI journalMineralSQuartz;
        public TextMeshProUGUI journalMineralFeldspar;
        public TextMeshProUGUI journalMineralGranite;
        public TextMeshProUGUI journalMineralLimestone;
        public TextMeshProUGUI journalMineralSlate;

        public TextMeshProUGUI journalMineralGraniteName;
        public TextMeshProUGUI journalMineralLimestoneName;
        public TextMeshProUGUI journalMineralSlateName;

        public TextMeshProUGUI journalTitle3;
        public TextMeshProUGUI journal2Clay;
      //  public TextMeshProUGUI journal2GFlakes;
        public TextMeshProUGUI journal2Silt;
        public TextMeshProUGUI journal2Gravel;
        public TextMeshProUGUI journal2Sand;

        public TextMeshProUGUI sidePanal1Clay;
        public TextMeshProUGUI sidePanal1Mica;
        public TextMeshProUGUI sidePanal1Calcite;
        public TextMeshProUGUI sidePanal1Quartz;
        public TextMeshProUGUI sidePanal1Fedlspar;

        public TextMeshProUGUI sidePanal2Clay;
        public TextMeshProUGUI sidePanal2Mica;
        public TextMeshProUGUI sidePanal2Calcite;
        public TextMeshProUGUI sidePanal2Quartz;
        public TextMeshProUGUI sidePanal2Fedlspar;

        public TextMeshProUGUI combinePanal1Clay;
        public TextMeshProUGUI combinePanal1Mica;
        public TextMeshProUGUI combinePanal1Calcite;
        public TextMeshProUGUI combinePanal1Quartz;
        public TextMeshProUGUI combinePanal1Fedlspar;

        public TextMeshProUGUI combinePanal2Clay;
        public TextMeshProUGUI combinePanal2Mica;
        public TextMeshProUGUI combinePanal2Calcite;
        public TextMeshProUGUI combinePanal2Quartz;
        public TextMeshProUGUI combinePanal2Fedlspar;


        public TextMeshProUGUI combineButtonMeta;
        public TextMeshProUGUI combineButtonSedi;
        public TextMeshProUGUI combineButtonIngeous;
        public TextMeshProUGUI combineButtonUnknown;


        public TextMeshProUGUI sidePanal3Sand;
        public TextMeshProUGUI sidePanal3Clay;
        public TextMeshProUGUI sidePanal3Gravel;
        public TextMeshProUGUI sidePanal3GoldFlakes;
        public TextMeshProUGUI sidePanal3Silt;

        public TextMeshProUGUI sidePanal4Sand;
        public TextMeshProUGUI sidePanal4Clay;
        public TextMeshProUGUI sidePanal4Gravel;
        public TextMeshProUGUI sidePanal4GoldFlakes;
        public TextMeshProUGUI sidePanal4Silt;


        public TextMeshProUGUI stage1Text1;
        public TextMeshProUGUI stage1Text2;
        public TextMeshProUGUI stage1Text3;
        public TextMeshProUGUI stage1Text4;
        public TextMeshProUGUI stage1Text5;
        public TextMeshProUGUI stage1Text6;
        public TextMeshProUGUI stage1Text7;
        public TextMeshProUGUI stage1Text8;
        public TextMeshProUGUI stage1Text9;
        public TextMeshProUGUI stage1Text10;
        public TextMeshProUGUI stage1Text11;
        public TextMeshProUGUI stage1Text12;
        public TextMeshProUGUI stage1Text13;
        public TextMeshProUGUI stage1Text14;
        public TextMeshProUGUI stage1Text15;
        public TextMeshProUGUI stage1Text16;
        public TextMeshProUGUI stage1Text17;
        public TextMeshProUGUI stage1Text18;
        public TextMeshProUGUI stage1Text19;
        public TextMeshProUGUI stage1Text20;
        public TextMeshProUGUI stage1Text21;
        public TextMeshProUGUI stage1Text22;
        public TextMeshProUGUI stage1Text23;
        public TextMeshProUGUI stage1Text24;

        public TextMeshProUGUI stage1Step2Text1;
        public TextMeshProUGUI stage1Step2Text2;
        public TextMeshProUGUI stage1Step2Text3;
        public TextMeshProUGUI stage1Step2Text4;
        public TextMeshProUGUI stage1Step2Text5;
        public TextMeshProUGUI stage1Step2Text6;
        public TextMeshProUGUI stage1Step2Text7;
        public TextMeshProUGUI stage1Step2Text8;
        public TextMeshProUGUI stage1Step2Text9;
        public TextMeshProUGUI stage1Step2Text10;
        public TextMeshProUGUI stage1Step2Text11; // all sediaments
        public TextMeshProUGUI stage1Step2Text12;
        public TextMeshProUGUI stage1Step2Text13;
        public TextMeshProUGUI stage1Step2Text14;
        public TextMeshProUGUI stage1Step2Text15;
        public TextMeshProUGUI stage1Step2Text16;
        public TextMeshProUGUI stage1Step2Text17;


        private void Awake()
        {
            JSONNode defs = SharedState.LanguageDefs;

            journalTitle.text = defs["stage2JournalTitle"];
            journalPage1Concept1.text = defs["concept1Process"];
            journalPage1Concept2.text = defs["concept2GeoProcess"];
            journalPage1Concept3.text = defs["concept3Rock"];
            journalPage1Concept4.text = defs["concept4RegionalMeta"];
            journalPage1Concept5.text = defs["concept5Sediment"];
            journalPage1Concept6.text = defs["concept6MetamorphicRock"];
            journalPage1Concept7.text = defs["concept7CombinationMinerals"];

            journalTitle2.text = defs["stage2JournalTitle2"];
            journalMineralClay.text = defs["stage2MineralClay"];
            journalMineralClay2.text = defs["stage2MineralClay"];
            journalMineralMica.text = defs["stage2MineralMica"];
            journalMineralCalcite.text = defs["stage2MineralCalcite"];
            journalMineralSQuartz.text = defs["stage2MineralQuartz"];
            journalMineralFeldspar.text = defs["stage2MineralFeldspar"];
            journalMineralGranite.text = defs["stage2SlateType"];
            journalMineralLimestone.text = defs["stage2LimeStoneType"];
            journalMineralSlate.text = defs["stage2GraniteType"];


            journalMineralGraniteName.text = defs["stage2GraniteName"];
            journalMineralLimestoneName.text = defs["stage2LimestoneName"];
            journalMineralSlateName.text = defs["stage2SlateName"];

            journalTitle3.text = defs["stage2SedimentSandJournalP2"];
            journal2Clay.text = defs["stage2MineralClay"];
            journal2Silt.text = defs["stage2SedimentSilt"];
            journal2Gravel.text = defs["stage2SedimentGravel"];
            journal2Sand.text = defs["stage2SedimentSand"];

            sidePanal1Clay.text = defs["stage2MineralClay"];
            sidePanal1Mica.text = defs["stage2MineralMica"];
            sidePanal1Calcite.text = defs["stage2MineralCalcite"];
            sidePanal1Quartz.text = defs["stage2MineralQuartz"];
            sidePanal1Fedlspar.text = defs["stage2MineralFeldspar"];

            sidePanal2Clay.text = defs["stage2MineralClay"];
            sidePanal2Mica.text = defs["stage2MineralMica"];
            sidePanal2Calcite.text = defs["stage2MineralCalcite"];
            sidePanal2Quartz.text = defs["stage2MineralQuartz"];
            sidePanal2Fedlspar.text = defs["stage2MineralFeldspar"];

            combinePanal1Clay.text = defs["stage2MineralClay"];
            combinePanal1Mica.text = defs["stage2MineralMica"];
            combinePanal1Calcite.text = defs["stage2MineralCalcite"];
            combinePanal1Quartz.text = defs["stage2MineralQuartz"];
            combinePanal1Fedlspar.text = defs["stage2MineralFeldspar"];

            combinePanal2Clay.text = defs["stage2MineralClay"];
            combinePanal2Mica.text = defs["stage2MineralMica"];
            combinePanal2Calcite.text = defs["stage2MineralCalcite"];
            combinePanal2Quartz.text = defs["stage2MineralQuartz"];
            combinePanal2Fedlspar.text = defs["stage2MineralFeldspar"];

            combineButtonMeta.text = defs["stage2CombButtonSlate"];
            combineButtonSedi.text = defs["stage2CombButtonLimestone"];
            combineButtonIngeous.text = defs["stage2CombButtonGranite"];
            combineButtonUnknown.text = defs["stage2UnknownButton"];


           sidePanal3Sand.text = defs["stage2SedimentSand"];
           sidePanal3Clay.text = defs["stage2MineralClay"];
           sidePanal3Gravel.text = defs["stage2SedimentGravel"];
           sidePanal3GoldFlakes.text = defs["stage2SedimentGoldFlakes"];
           sidePanal3Silt.text = defs["stage2SedimentSilt"];

            sidePanal4Sand.text = defs["stage2SedimentSand"];
            sidePanal4Clay.text = defs["stage2MineralClay"];
            sidePanal4Gravel.text = defs["stage2SedimentGravel"];
            sidePanal4GoldFlakes.text = defs["stage2SedimentGoldFlakes"];
            sidePanal4Silt.text = defs["stage2SedimentSilt"];

            stage1Text1.text = defs["stage2RCText1"];
            stage1Text2.text = defs["stage2RCText2"];
            stage1Text3.text = defs["stage2RCText3"];
            stage1Text4.text = defs["stage2RCText4"];
            stage1Text5.text = defs["stage2RCText5"];
            stage1Text6.text = defs["stage2RCText6"];
            stage1Text7.text = defs["stage2RCText7"];
            stage1Text8.text = defs["stage2RCText8"];
            stage1Text9.text = defs["stage2RCText9"];
            stage1Text10.text = defs["stage2RCText10"];
            stage1Text11.text = defs["stage2RCText11"];
            stage1Text12.text = defs["stage2RCText12"];
            stage1Text13.text = defs["stage2RCText13"];
            stage1Text14.text = defs["stage2RCText14"];
            stage1Text15.text = defs["stage2RCText15"];
            stage1Text16.text = defs["stage2RCText16"];
            stage1Text17.text = defs["stage2RCText17"];
            stage1Text18.text = defs["stage2RCText18"];
            stage1Text19.text = defs["stage2RCText19"];
            stage1Text20.text = defs["stage2RCText20"];
            stage1Text21.text = defs["stage2RCText21"];
            stage1Text22.text = defs["stage2RCText22"];
            stage1Text23.text = defs["stage2RCText23"];
            stage1Text24.text = defs["stage2RCText24"];

            stage1Step2Text1.text = defs["stage2RCText25"];
            stage1Step2Text2.text = defs["stage2RCText26"];
            stage1Step2Text3.text = defs["stage2RCText27"];
            stage1Step2Text4.text = defs["stage2RCText28"];
            stage1Step2Text5.text = defs["stage2RCText29"];
            stage1Step2Text6.text = defs["stage2RCText30"];
            stage1Step2Text7.text = defs["stage2RCText31"];
            stage1Step2Text8.text = defs["stage2RCText32"];
            stage1Step2Text9.text = defs["stage2RCText33"];
            stage1Step2Text10.text = defs["stage2RCText34"];
            stage1Step2Text11.text = defs["stage2RCText35"];
            stage1Step2Text12.text = defs["stage2RCText36"];
            stage1Step2Text13.text = defs["stage2RCText37"];
            stage1Step2Text14.text = defs["stage2RCText38"];
            stage1Step2Text15.text = defs["stage2RCText39"];
            stage1Step2Text16.text = defs["stage2RCText40"];
            stage1Step2Text17.text = defs["stage2RCText41"];

        }
    }


}
