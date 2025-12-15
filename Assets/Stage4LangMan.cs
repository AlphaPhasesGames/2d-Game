using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using TMPro;

namespace Alpha.Phases.Geoquest
{
    public class Stage4LangMan : MonoBehaviour
    {

        public TextMeshProUGUI stage4Text1;
        public TextMeshProUGUI stage4Text2;
        public TextMeshProUGUI stage4Text3;
        public TextMeshProUGUI stage4Text4;
        public TextMeshProUGUI stage4Text5;
        private void Awake()
        {
            JSONNode defs = SharedState.LanguageDefs;

            stage4Text1.text = defs["stage4Text1"];
            stage4Text2.text = defs["stage4Text2"];
            stage4Text3.text = defs["stage4Text3"];
            stage4Text4.text = defs["stage4Text4"];
            stage4Text5.text = defs["stage4Text5"];

        }
    }


}
