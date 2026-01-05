using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alpha.Phases.Geoquest
{
    public class Stage3SwitchManager : MonoBehaviour
    {
        public Stage3TextManager textMan;

        // --- SWITCH UI OBJECTS ---
        public GameObject switchUp1CoreHeat;
        public GameObject switchDown1CoreHeat;

        public GameObject switchUp2MagmaFlow;
        public GameObject switchDown2MagmaFlow;

        public GameObject switchUp3TectonicPressure;
        public GameObject switchDown3TectonicPressure;

        public GameObject switchUp4SurfaceEnergyRelease;
        public GameObject switchDown4SurfaceEnergyRelease;

        public GameObject lavaStones;
        public ParticleSystem smoke1;

        public AudioSource wrongSFX;
        public AudioSource correctSFX;
        public AudioSource rumble;
        // --- PUZZLE ORDER SYSTEM ---
        public int[] correctOrder = { 1, 3, 4, 2 };   // <-- Set your required order here
        private int currentIndex = 0;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.B))
                ResetSwitches();
        }

        // ----------------------------------------------------------
        //  Call this from your UI button or OnClick event:
        //      e.g. switchButton.onClick.AddListener(() => PullSwitch(1));
        // ----------------------------------------------------------
        public void PullSwitch(int physicalID, int sequenceID)
        {

            if (currentIndex >= correctOrder.Length)
            {
                Debug.LogWarning("PullSwitch called but puzzle already complete.");
                return;
            }
            Debug.Log($"Switch pulled. Physical ID = {physicalID}, Sequence ID = {sequenceID}");

            if (currentIndex < correctOrder.Length)
            {
                Debug.Log($"Expected sequence: {correctOrder[currentIndex]}");
            }

            // Check sequence first
            if (sequenceID == correctOrder[currentIndex])
            {
                Debug.Log("Correct sequence step!");
                ActivateSwitch(physicalID);
                currentIndex++;
                correctSFX.Play();
                if (currentIndex >= correctOrder.Length)
                {
                    Debug.Log("PUZZLE COMPLETE!");
                    PuzzleComplete();
                }
            }
            else
            {
                Debug.Log("Wrong sequence, resetting puzzle.");
                ResetSwitches();
            }
        }

        // Switch animation (UP  DOWN)
        private void ActivateSwitch(int id)
        {
            switch (id)
            {
                case 1:
                    switchUp1CoreHeat.SetActive(false);
                    switchDown1CoreHeat.SetActive(true);
                    break;

                case 2:
                    switchUp2MagmaFlow.SetActive(false);
                    switchDown2MagmaFlow.SetActive(true);
                    break;

                case 3:
                    switchUp3TectonicPressure.SetActive(false);
                    switchDown3TectonicPressure.SetActive(true);
                    break;

                case 4:
                    switchUp4SurfaceEnergyRelease.SetActive(false);
                    switchDown4SurfaceEnergyRelease.SetActive(true);
                    break;
            }
        }

        // Reset puzzle
        public void ResetSwitches()
        {
            currentIndex = 0;

            switchUp1CoreHeat.SetActive(true);
            switchDown1CoreHeat.SetActive(false);

            switchUp2MagmaFlow.SetActive(true);
            switchDown2MagmaFlow.SetActive(false);

            switchUp3TectonicPressure.SetActive(true);
            switchDown3TectonicPressure.SetActive(false);

            switchUp4SurfaceEnergyRelease.SetActive(true);
            switchDown4SurfaceEnergyRelease.SetActive(false);

            wrongSFX.Play();

            textMan.ResetBools();
            textMan.positionChanged = true;
            textMan.arrayPos = 9;
        }

        public void PuzzleComplete()
        {
            Debug.Log("Puzzle logic triggers here!");
            lavaStones.gameObject.SetActive(true);
            smoke1.Play();
            rumble.Play();
            textMan.positionChanged = true;
            textMan.arrayPos = 10;
            // Open door, continue text, activate machine, whatever you need
        }
    }
}
