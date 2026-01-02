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

        public bool goldPlaced;
        public bool placedOnce;
        public Animator compressRock;

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
            if (!layer1Filled)
            {
                layerSand1.SetActive(true);
                layer1Filled = true;
            }
            else if (!layer2Filled)
            {
                layerSand2.SetActive(true);
                layer2Filled = true;
            }
            else if (!layer3Filled)
            {
                layerSand3.SetActive(true);
                layer3Filled = true;
            }
            else if (!layer4Filled)
            {
                layerSand4.SetActive(true);
                layer4Filled = true;
            }
        }

        public void AddGravel()
        {
            if (!layer1Filled)
            {
                layerGravel1.SetActive(true);
                layer1Filled = true;
            }
            else if (!layer2Filled)
            {
                layerGravel2.SetActive(true);
                layer2Filled = true;
            }
            else if (!layer3Filled)
            {
                layerGravel3.SetActive(true);
                layer3Filled = true;
            }
            else if (!layer4Filled)
            {
                layerGravel4.SetActive(true);
                layer4Filled = true;
            }
        }

        public void AddSilt()
        {
            if (!layer1Filled)
            {
                layerSilt1.SetActive(true);
                layer1Filled = true;
            }
            else if (!layer2Filled)
            {
                layerSilt2.SetActive(true);
                layer2Filled = true;
            }
            else if (!layer3Filled)
            {
                layerSilt3.SetActive(true);
                layer3Filled = true;
            }
            else if (!layer4Filled)
            {
                layerSilt4.SetActive(true);
                layer4Filled = true;
            }
        }

        public void AddClay()
        {
            if (!layer1Filled)
            {
                layerClay1.SetActive(true);
                layer1Filled = true;
            }
            else if (!layer2Filled)
            {
                layerClay2.SetActive(true);
                layer2Filled = true;
            }
            else if (!layer3Filled)
            {
                layerClay3.SetActive(true);
                layer3Filled = true;
            }
            else if (!layer4Filled)
            {
                layerClay4.SetActive(true);
                layer4Filled = true;
            }
        }

        public void AddGFlakes()
        {
            if (!layer1Filled)
            {
                layerGoldFlakes1.SetActive(true);
                goldPlaced = true;
                layer1Filled = true;
            }
            else if (!layer2Filled)
            {
                layerGoldFlakes2.SetActive(true);
                goldPlaced = true;
                layer2Filled = true;
            }
            else if (!layer3Filled)
            {
                layerGoldFlakes3.SetActive(true);
                goldPlaced = true;
                layer3Filled = true;
            }
            else if (!layer4Filled)
            {
                layerGoldFlakes4.SetActive(true);
                goldPlaced = true;
                layer4Filled = true;
            }
        }

        public void ResetLayers()
        {
            layer1Filled = false;
            layer2Filled = false;
            layer3Filled = false;
            layer4Filled = false;

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
            goldPlaced = false;
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
                    compressRock.SetBool("compress", true);
                }
            }
        }

    }

  
}
