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
        }

    }
}
