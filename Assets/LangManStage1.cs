using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using TMPro;

namespace Alpha.Phases.Geoquest
{
    public class LangManStage1 : MonoBehaviour
    {
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
        public TextMeshProUGUI stage1Text25;
        public TextMeshProUGUI stage1Text26;
        public TextMeshProUGUI stage1Text27;
        public TextMeshProUGUI stage1Text28;
        public TextMeshProUGUI stage1Text29;
        public TextMeshProUGUI stage1Text30;
        public TextMeshProUGUI stage1Text31;
        public TextMeshProUGUI stage1Text32;
        public TextMeshProUGUI stage1Text33;
        public TextMeshProUGUI stage1Text34;
        public TextMeshProUGUI stage1Text35;
        public TextMeshProUGUI stage1Text36;

        public TextMeshProUGUI allBottlesCollected;
        public TextMeshProUGUI stepUplift;
        public TextMeshProUGUI stepWeathering;
        public TextMeshProUGUI stepErosion;
        public TextMeshProUGUI stepDeposition;
        public TextMeshProUGUI stepMelting;
        public TextMeshProUGUI stepCrystallization;
        public TextMeshProUGUI stepMetamorphism;
        public TextMeshProUGUI stepUpliftName;
        public TextMeshProUGUI stepWeatheringName;
        public TextMeshProUGUI stepErosionName;
        public TextMeshProUGUI stepDepositionName;
        public TextMeshProUGUI stepMeltingName;
        public TextMeshProUGUI stepCrystallizationName;
        public TextMeshProUGUI stepMetamorphismName;
        public TextMeshProUGUI stepUpliftName2;
        public TextMeshProUGUI stepWeatheringName2;
        public TextMeshProUGUI stepErosionName2;
        public TextMeshProUGUI stepDepositionName2;
        public TextMeshProUGUI stepMeltingName2;
        public TextMeshProUGUI stepCrystallizationName2;
        public TextMeshProUGUI stepMetamorphismName2;
        public TextMeshProUGUI stepUpliftName3;
        public TextMeshProUGUI stepWeatheringName3;
        public TextMeshProUGUI stepErosionName3;
        public TextMeshProUGUI stepDepositionName3;
        public TextMeshProUGUI stepMeltingName3;
        public TextMeshProUGUI stepCrystallizationName3;
        public TextMeshProUGUI stepMetamorphismName3;
        public TextMeshProUGUI stepUpliftName4;
        public TextMeshProUGUI stepWeatheringName4;
        public TextMeshProUGUI stepErosionName4;
        public TextMeshProUGUI stepDepositionName4;
        public TextMeshProUGUI stepMeltingName4;
        public TextMeshProUGUI stepCrystallizationName4;
        public TextMeshProUGUI stepMetamorphismName4;
        public TextMeshProUGUI stepUpliftName5;
        public TextMeshProUGUI stepWeatheringName5;
        public TextMeshProUGUI stepErosionName5;
        public TextMeshProUGUI stepDepositionName5;
        public TextMeshProUGUI stepMeltingName5;
        public TextMeshProUGUI stepCrystallizationName5;
        public TextMeshProUGUI stepMetamorphismName5;

        public TextMeshProUGUI sedimentaryRock;
        public TextMeshProUGUI metamorphicRock;
        public TextMeshProUGUI igenousRock;

        public TextMeshProUGUI sedimentaryRock2;
        public TextMeshProUGUI metamorphicRock2;
        public TextMeshProUGUI igenousRock2;

        public TextMeshProUGUI compaction;
        public TextMeshProUGUI compaction2;

        public TextMeshProUGUI matter;
        public TextMeshProUGUI energy;
        public TextMeshProUGUI friction;
        public TextMeshProUGUI airResist;

        public TextMeshProUGUI evapLabel;

        public TextMeshProUGUI concept1Process;
        public TextMeshProUGUI concept2GeoProcess;
        public TextMeshProUGUI concept3Rock;
        public TextMeshProUGUI concept4RegMeta;
        private void Awake()
        {
            JSONNode defs = SharedState.LanguageDefs;

            stage1Text1.text = defs["stage1Text1"];
            stage1Text2.text = defs["stage1Text2"];
            stage1Text3.text = defs["stage1Text3"];
            stage1Text4.text = defs["stage1Text4"];
            stage1Text5.text = defs["stage1Text5"];
            stage1Text6.text = defs["stage1Text6"];
            stage1Text7.text = defs["stage1Text7"];
            stage1Text8.text = defs["stage1Text8"];
            stage1Text9.text = defs["stage1Text9"];
            stage1Text10.text = defs["stage1Text10"];
            stage1Text11.text = defs["stage1Text11"];
            stage1Text12.text = defs["stage1Text12"];
            stage1Text13.text = defs["stage1Text13"];
            stage1Text14.text = defs["stage1Text14"];
            stage1Text15.text = defs["stage1Text15"];
            stage1Text16.text = defs["stage1Text16"];
            stage1Text17.text = defs["stage1Text17"];
            stage1Text18.text = defs["stage1Text18"];
            allBottlesCollected.text = defs["stage1TextAllBottlesCollected"];
            stage1Text19.text = defs["stage1Text19"];
            stage1Text20.text = defs["stage1Text20"];
            stage1Text21.text = defs["stage1Text21"];
            stage1Text22.text = defs["stage1Text22"];
            stage1Text23.text = defs["stage1Text23"];
            stage1Text24.text = defs["stage1Text24"];
            stage1Text25.text = defs["stage1Text25"];
            stage1Text26.text = defs["stage1Text26"];
            stage1Text27.text = defs["stage1Text27"];
            stage1Text28.text = defs["stage1Text28"];
            stage1Text29.text = defs["stage1Text29"];
            stage1Text30.text = defs["stage1Text30"];
            stage1Text31.text = defs["stage1Text31"];
            stage1Text32.text = defs["stage1Text32"];
            stage1Text33.text = defs["stage1Text33"];
            stage1Text34.text = defs["stage1Text34"];
            stage1Text35.text = defs["stage1Text35"];
            stage1Text36.text = defs["stage1Text36"];

            stepUplift.text = defs["stage1RCStep1"];
            stepWeathering.text = defs["stage1RCStep2"];
            stepErosion.text = defs["stage1RCStep3"];
            stepDeposition.text = defs["stage1RCStep4"];
            stepMelting.text = defs["stage1RCStep5"];
            stepCrystallization.text = defs["stage1RCStep6"];
            stepMetamorphism.text = defs["stage1RCStep7"];
            stepUpliftName.text = defs["stage1RCStep1Name"];
            stepWeatheringName.text = defs["stage1RCStep2Name"];
            stepErosionName.text = defs["stage1RCStep3Name"];
            stepDepositionName.text = defs["stage1RCStep4Name"];
            stepMeltingName.text = defs["stage1RCStep5Name"];
            stepCrystallizationName.text = defs["stage1RCStep6Name"];
            stepMetamorphismName.text = defs["stage1RCStep7Name"];
            stepUpliftName2.text = defs["stage1RCStep1Name"];
            stepWeatheringName2.text = defs["stage1RCStep2Name"];
            stepErosionName2.text = defs["stage1RCStep3Name"];
            stepDepositionName2.text = defs["stage1RCStep4Name"];
            stepMeltingName2.text = defs["stage1RCStep5Name"];
            stepCrystallizationName2.text = defs["stage1RCStep6Name"];
            stepMetamorphismName2.text = defs["stage1RCStep7Name"];
            stepUpliftName3.text = defs["stage1RCStep1Name"];
            stepWeatheringName3.text = defs["stage1RCStep2Name"];
            stepErosionName3.text = defs["stage1RCStep3Name"];
            stepDepositionName3.text = defs["stage1RCStep4Name"];
            stepMeltingName3.text = defs["stage1RCStep5Name"];
            stepCrystallizationName3.text = defs["stage1RCStep6Name"];
            stepMetamorphismName3.text = defs["stage1RCStep7Name"];
            stepUpliftName4.text = defs["stage1RCStep1Name"];
            stepWeatheringName4.text = defs["stage1RCStep2Name"];
            stepErosionName4.text = defs["stage1RCStep3Name"];
            stepDepositionName4.text = defs["stage1RCStep4Name"];
            stepMeltingName4.text = defs["stage1RCStep5Name"];
            stepCrystallizationName4.text = defs["stage1RCStep6Name"];
            stepMetamorphismName4.text = defs["stage1RCStep7Name"];
            stepUpliftName5.text = defs["stage1RCStep1Name"];
            stepWeatheringName5.text = defs["stage1RCStep2Name"];
            stepErosionName5.text = defs["stage1RCStep3Name"];
            stepDepositionName5.text = defs["stage1RCStep4Name"];
            stepMeltingName5.text = defs["stage1RCStep5Name"];
            stepCrystallizationName5.text = defs["stage1RCStep6Name"];
            stepMetamorphismName5.text = defs["stage1RCStep7Name"];

            sedimentaryRock.text = defs["stage1RCSedimentary"];
            metamorphicRock.text = defs["stage1RCMetamorphic"];
            igenousRock.text = defs["stage1RCIgneous"];

            sedimentaryRock2.text = defs["stage1RCSedimentary"];
            metamorphicRock2.text = defs["stage1RCMetamorphic"];
            igenousRock2.text = defs["stage1RCIgneous"];

            compaction.text = defs["stage1RCCompaction"];
            compaction2.text = defs["stage1RCCompaction"];

            matter.text = defs["stage1RCswitchMatter"];
            energy.text = defs["stage1RCswitchEnergy"];
            friction.text = defs["stage1RCswitchFriction"];
            airResist.text = defs["stage1RCswitchAirResistance"];

            evapLabel.text = defs["stage1RCEvaporation"];



            concept1Process.text = defs["concept1Process"];
            concept2GeoProcess.text = defs["concept2GeoProcess"];

            concept3Rock.text = defs["concept3Rock"];
            concept4RegMeta.text = defs["concept4RegionalMeta"];
    }

    }
}
