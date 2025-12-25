using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
using LoLSDK;

namespace Alpha.Phases.Geoquest
{
    public class Stage2SediementMachine : MonoBehaviour
    {
        public Stage2TextManager textMan;

        [Header("Layer 1")]
        public GameObject layerSand1;
        public GameObject layerGravel1;
        public GameObject layerSilt1;
        public GameObject layerClay1;
        public GameObject layerGoldFlakes1;

        [Header("Layer 2")]
        public GameObject layerSand2;
        public GameObject layerGravel2;
        public GameObject layerSilt2;
        public GameObject layerClay2;
        public GameObject layerGoldFlakes2;

        [Header("Layer 3")]
        public GameObject layerSand3;
        public GameObject layerGravel3;
        public GameObject layerSilt3;
        public GameObject layerClay3;
        public GameObject layerGoldFlakes3;

        [Header("Layer 4")]
        public GameObject layerSand4;
        public GameObject layerGravel4;
        public GameObject layerSilt4;
        public GameObject layerClay4;
        public GameObject layerGoldFlakes4;

        [Header("Buttons")]
        public Button sand;
        public Button clay;
        public Button silt;
        public Button gravel;
        public Button gFlakes;

        public Button reset;
        public Button compress;
        public bool layer1Filled;
        public bool layer2Filled;
        public bool layer3Filled;
        public bool layer4Filled;

        private bool sandUsed;
        private bool gravelUsed;
        private bool siltUsed;
        private bool clayUsed;
        private bool goldUsed;

        public bool goldPlaced;
        public bool placedOnce;
        private void Awake()
        {
            sand.onClick.AddListener(AddSand);
            clay.onClick.AddListener(AddClay);
            silt.onClick.AddListener(AddSilt);
            gravel.onClick.AddListener(AddGravel);
            gFlakes.onClick.AddListener(AddGFlakes);

            reset.onClick.AddListener(ResetLayers);
            compress.onClick.AddListener(Compress);
        }

        private void Update()
        {
            if (layer1Filled)
            {
                if (!placedOnce)
                {
                    textMan.positionChanged = true;
                    textMan.arrayPos = 37;
                    placedOnce = true;
                }

            }

           
        }

        // ------------------------------
        // FIXED VERSIONS
        // ------------------------------

        public void AddSand()
        {
            if (sandUsed)
                return;

            sandUsed = true;
            AddToNextLayer(
                layerSand1,
                layerSand2,
                layerSand3,
                layerSand4
            );
        }

        public void AddGravel()
        {
            if (gravelUsed)
                return;

            gravelUsed = true;
            AddToNextLayer(
                layerGravel1,
                layerGravel2,
                layerGravel3,
                layerGravel4
            );
        }



        public void AddSilt()
        {
            if (siltUsed)
                return;

            siltUsed = true;
            AddToNextLayer(
                layerSilt1,
                layerSilt2,
                layerSilt3,
                layerSilt4
            );
        }

        public void AddClay()
        {
            if (clayUsed)
                return;

            clayUsed = true;
            AddToNextLayer(
                layerClay1,
                layerClay2,
                layerClay3,
                layerClay4
            );
        }

        public void AddGFlakes()
        {
            if (goldUsed)
                return;

            goldUsed = true;
            goldPlaced = true;

            AddToNextLayer(
                layerGoldFlakes1,
                layerGoldFlakes2,
                layerGoldFlakes3,
                layerGoldFlakes4
            );
        }


        public void ResetLayers()
        {
            layer1Filled = layer2Filled = layer3Filled = layer4Filled = false;

            sandUsed = gravelUsed = siltUsed = clayUsed = goldUsed = false;
            goldPlaced = false;
            placedOnce = false;

            // Disable all visuals
            layerSand1.SetActive(false);
            layerSand2.SetActive(false);
            layerSand3.SetActive(false);
            layerSand4.SetActive(false);

            layerGravel1.SetActive(false);
            layerGravel2.SetActive(false);
            layerGravel3.SetActive(false);
            layerGravel4.SetActive(false);

            layerSilt1.SetActive(false);
            layerSilt2.SetActive(false);
            layerSilt3.SetActive(false);
            layerSilt4.SetActive(false);

            layerClay1.SetActive(false);
            layerClay2.SetActive(false);
            layerClay3.SetActive(false);
            layerClay4.SetActive(false);

            layerGoldFlakes1.SetActive(false);
            layerGoldFlakes2.SetActive(false);
            layerGoldFlakes3.SetActive(false);
            layerGoldFlakes4.SetActive(false);
        }


        public void Compress()
        {
            if (layer1Filled && layer2Filled && layer3Filled && layer4Filled)
            {
                if (goldPlaced)
                {
                    textMan.ResetBools();
                    textMan.positionChanged = true;
                    textMan.arrayPos = 38;
                }

                if (!goldPlaced)
                {
                    textMan.positionChanged = true;
                    textMan.arrayPos = 39;
                }
            }
        }

        private void AddToNextLayer(
              GameObject l1,
              GameObject l2,
              GameObject l3,
              GameObject l4)
        {
            if (!layer1Filled)
            {
                l1.SetActive(true);
                layer1Filled = true;
            }
            else if (!layer2Filled)
            {
                l2.SetActive(true);
                layer2Filled = true;
            }
            else if (!layer3Filled)
            {
                l3.SetActive(true);
                layer3Filled = true;
            }
            else if (!layer4Filled)
            {
                l4.SetActive(true);
                layer4Filled = true;
            }
        }

    }

  
}
