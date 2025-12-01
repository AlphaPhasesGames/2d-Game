using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Alpha.Phases.Geoquest
{
    public class Stage2CombinationManager : MonoBehaviour
    {

        public Stage2TextManager textMan;
        public int amountOfCorrectGuesses;

        public Button clayButton;

        public Button clayButtonPlaced1;
        public GameObject clayPlaced1;
        public Button clayButtonPlaced2;
        public GameObject clayPlaced2;
       public bool clayIsPlaced;


        public Button micaButton;

        public Button micaButtonPlaced1;
        public GameObject micaPlaced1;
        public Button micaButtonPlaced2;
        public GameObject micaPlaced2;
        public bool micaIsPlaced;

        public Button calciteButton;

        public Button calciteButtonPlaced1;
        public GameObject calcitePlaced1;
        public Button calciteButtonPlaced2;
        public GameObject calcitePlaced2;
        public bool calciteIsPlaced;


        public Button quartzButton;

        public Button quartzButtonPlaced1;
        public GameObject quartzPlaced1;
        public Button quartzButtonPlaced2;
        public GameObject quartzPlaced2;
        public bool quartzIsPlaced;

        public Button feldsparButton;

        public Button feldsparButtonPlaced1;
        public GameObject feldsparPlaced1;
        public Button feldsparButtonPlaced2;
        public GameObject feldsparPlaced2;
        public bool feldsparIsPlaced;

        public bool amountOFCorrectAnswers;
        public bool boxOneFilled;
        public bool boxTwoFilled;

        public bool metamorphicUsed;   // slate (mica + clay)
        public bool sedimentaryUsed;   // limestone (calcite + clay)
        public bool igneousUsed;       // granite (feldspar + quartz)

        // Tracks if the current failed combo is one you've already used
        private bool comboAlreadyUsed;

        public GameObject slate;
        public bool slatePlaced;

        public GameObject limeStone;
        public bool limeStonePlaced;

        public GameObject graniteStone;
        public bool granitePlaced;

        public Button metaCombineButton;
        public Button igneousCombineButton;
        public Button sedimentaryCombineButton;
        public Button invalidCombineButton;

        private void Awake()
        {
            clayButton.onClick.AddListener(PlaceClay);
            clayButtonPlaced1.onClick.AddListener(RemoveClayFromBox1);
            clayButtonPlaced2.onClick.AddListener(RemoveClayFromBox2);

            micaButton.onClick.AddListener(PlaceMica);
            micaButtonPlaced1.onClick.AddListener(RemoveMicaFromBox1);
            micaButtonPlaced2.onClick.AddListener(RemoveMicaFromBox2);

            calciteButton.onClick.AddListener(PlaceCalcite);
            calciteButtonPlaced1.onClick.AddListener(RemoveCalciteFromBox1);
            calciteButtonPlaced2.onClick.AddListener(RemoveCalciteFromBox2);

            quartzButton.onClick.AddListener(PlaceQuartz);
            quartzButtonPlaced1.onClick.AddListener(RemoveQuartzFromBox1);
            quartzButtonPlaced2.onClick.AddListener(RemoveQuartzFromBox2);

            feldsparButton.onClick.AddListener(PlaceFeldspar);
            feldsparButtonPlaced1.onClick.AddListener(RemoveFeldsparFromBox1);
            feldsparButtonPlaced2.onClick.AddListener(RemoveFeldsparFromBox2);

            metaCombineButton.onClick.AddListener(AcceptMetaComb);
            igneousCombineButton.onClick.AddListener(AcceptIgenousComb);
            sedimentaryCombineButton.onClick.AddListener(AcceptSedimentaryComb);
            invalidCombineButton.onClick.AddListener(AcceptInvalidComb);
        }

        public void PlaceClay()
        {
            if (!clayIsPlaced)
            {
                if (!boxOneFilled)
                {
                    clayButton.gameObject.SetActive(false);
                    clayPlaced1.gameObject.SetActive(true);
                    clayIsPlaced = true;
                    boxOneFilled = true;
                }
                else if (boxOneFilled)
                {
                    clayButton.gameObject.SetActive(false);
                    clayPlaced2.gameObject.SetActive(true);
                    clayIsPlaced = true;
                    boxTwoFilled = true;
                }

            }

            ShowFinalRock();
        }



        public void RemoveClayFromBox1()
        {
            clayPlaced1.gameObject.SetActive(false);
            clayButton.gameObject.SetActive(true);
            boxOneFilled = false;
            clayIsPlaced = false; // still true if clay in box2
            ShowFinalRock();
        }

        public void RemoveClayFromBox2()
        {
            clayPlaced2.gameObject.SetActive(false);
            clayButton.gameObject.SetActive(true);
            boxTwoFilled = false;
            clayIsPlaced = false; // still true if clay in box1
            ShowFinalRock();
        }



        public void PlaceMica()
        {
            if (!micaIsPlaced)
            {
                if (!boxOneFilled)
                {
                    micaButton.gameObject.SetActive(false);
                    micaPlaced1.gameObject.SetActive(true);
                    micaIsPlaced = true;
                    boxOneFilled = true;
                }
               else if (boxOneFilled)
                {
                    micaButton.gameObject.SetActive(false);
                    micaPlaced2.gameObject.SetActive(true);
                    micaIsPlaced = true;
                    boxTwoFilled = true;
                }

            }
            ShowFinalRock();

        }


        public void RemoveMicaFromBox1()
        {
            micaPlaced1.gameObject.SetActive(false);
            micaButton.gameObject.SetActive(true);
            boxOneFilled = false;
            micaIsPlaced = false; // still true if clay in box2
            ShowFinalRock();
        }

        public void RemoveMicaFromBox2()
        {
            micaPlaced2.gameObject.SetActive(false);
            micaButton.gameObject.SetActive(true);
            boxTwoFilled = false;
            micaIsPlaced = false; // still true if clay in box1
            ShowFinalRock();
        }

        public void PlaceCalcite()
        {
            if (!calciteIsPlaced)
            {
                if (!boxOneFilled)
                {
                    calciteButton.gameObject.SetActive(false);
                    calcitePlaced1.gameObject.SetActive(true);
                    calciteIsPlaced = true;
                    boxOneFilled = true;
                }
                else if (boxOneFilled)
                {
                    calciteButton.gameObject.SetActive(false);
                    calcitePlaced2.gameObject.SetActive(true);
                    calciteIsPlaced = true;
                    boxTwoFilled = true;

                }

            }

            ShowFinalRock();
        }


        public void RemoveCalciteFromBox1()
        {
            calcitePlaced1.gameObject.SetActive(false);
            calciteButton.gameObject.SetActive(true);
            boxOneFilled = false;
            calciteIsPlaced = false; // still true if clay in box2
            ShowFinalRock();
        }

        public void RemoveCalciteFromBox2()
        {
            calcitePlaced2.gameObject.SetActive(false);
            calciteButton.gameObject.SetActive(true);
            boxTwoFilled = false;
            calciteIsPlaced = false; // still true if clay in box1
            ShowFinalRock();
        }

        public void PlaceQuartz()
        {
            if (!quartzIsPlaced)
            {
                if (!boxOneFilled)
                {
                    quartzButton.gameObject.SetActive(false);
                    quartzPlaced1.gameObject.SetActive(true);
                    quartzIsPlaced = true;
                    boxOneFilled = true;
                }
                else if (boxOneFilled)
                {
                    quartzButton.gameObject.SetActive(false);
                    quartzPlaced2.gameObject.SetActive(true);
                    quartzIsPlaced = true;
                    boxTwoFilled = true;
                }

                ShowFinalRock();
            }

        }


        public void RemoveQuartzFromBox1()
        {
            quartzPlaced1.gameObject.SetActive(false);
            quartzButton.gameObject.SetActive(true);
            boxOneFilled = false;
            quartzIsPlaced = false; // still true if clay in box2
            ShowFinalRock();
        }

        public void RemoveQuartzFromBox2()
        {
            quartzPlaced2.gameObject.SetActive(false);
            quartzButton.gameObject.SetActive(true);
            boxTwoFilled = false;
            quartzIsPlaced = false; // still true if clay in box1
            ShowFinalRock();
        }

        public void PlaceFeldspar()
        {
            if (!feldsparIsPlaced)
            {
                if (!boxOneFilled)
                {
                    feldsparButton.gameObject.SetActive(false);
                    feldsparPlaced1.gameObject.SetActive(true);
                    feldsparIsPlaced = true;
                    boxOneFilled = true;
                }
                else if (boxOneFilled)
                {
                    feldsparButton.gameObject.SetActive(false);
                    feldsparPlaced2.gameObject.SetActive(true);
                    feldsparIsPlaced = true;
                    boxTwoFilled = true;
                }

                ShowFinalRock();
            }

        }


        public void RemoveFeldsparFromBox1()
        {
            feldsparPlaced1.gameObject.SetActive(false);
            feldsparButton.gameObject.SetActive(true);
            boxOneFilled = false;
            feldsparIsPlaced = false; // still true if clay in box2
            ShowFinalRock();
        }

        public void RemoveFeldsparFromBox2()
        {
            feldsparPlaced2.gameObject.SetActive(false);
            feldsparButton.gameObject.SetActive(true);
            boxTwoFilled = false;
            feldsparIsPlaced = false; // still true if clay in box1
            ShowFinalRock();
        }
        /*
        public void ShowFinalRock()
        {
            // Turn all off by default
            slatePlaced = false;
            limeStonePlaced = false;
            granitePlaced = false;

            slate.gameObject.SetActive(false);
            limeStone.gameObject.SetActive(false);
            graniteStone.gameObject.SetActive(false);

            metaCombineButton.gameObject.SetActive(false);
            sedimentaryCombineButton.gameObject.SetActive(false);
            igneousCombineButton.gameObject.SetActive(false);
            invalidCombineButton.gameObject.SetActive(false);

            // Only evaluate when BOTH boxes are filled
            if (boxOneFilled && boxTwoFilled)
            {
                if (micaIsPlaced && clayIsPlaced)
                {
                    slatePlaced = true;
                    slate.gameObject.SetActive(true);
                    metaCombineButton.gameObject.SetActive(true);
                }
                else if (calciteIsPlaced && clayIsPlaced)
                {
                    limeStonePlaced = true;
                    limeStone.gameObject.SetActive(true);
                    sedimentaryCombineButton.gameObject.SetActive(true);
                }
                else if (feldsparIsPlaced && quartzIsPlaced)
                {
                    granitePlaced = true;
                    graniteStone.gameObject.SetActive(true);
                    igneousCombineButton.gameObject.SetActive(true);
                }
                else
                {
                    //  INVALID COMBINATION 
                    invalidCombineButton.gameObject.SetActive(true);
                    Debug.Log("Invalid combination created");
                }
            }
        }
        

        public void ShowFinalRock()
        {
            // Turn all off by default
            slatePlaced = false;
            limeStonePlaced = false;
            granitePlaced = false;

            slate.gameObject.SetActive(false);
            limeStone.gameObject.SetActive(false);
            graniteStone.gameObject.SetActive(false);

            metaCombineButton.gameObject.SetActive(false);
            sedimentaryCombineButton.gameObject.SetActive(false);
            igneousCombineButton.gameObject.SetActive(false);
            invalidCombineButton.gameObject.SetActive(false);

            // Only evaluate when BOTH boxes are filled
            if (boxOneFilled && boxTwoFilled)
            {
                // Mica + Clay -> Slate (Metamorphic)
                if (micaIsPlaced && clayIsPlaced && !metamorphicUsed)
                {
                    slatePlaced = true;
                    slate.gameObject.SetActive(true);
                    metaCombineButton.gameObject.SetActive(true);
                }
                // Calcite + Clay -> Limestone (Sedimentary)
                else if (calciteIsPlaced && clayIsPlaced && !sedimentaryUsed)
                {
                    limeStonePlaced = true;
                    limeStone.gameObject.SetActive(true);
                    sedimentaryCombineButton.gameObject.SetActive(true);
                }
                // Feldspar + Quartz -> Granite (Igneous)
                else if (feldsparIsPlaced && quartzIsPlaced && !igneousUsed)
                {
                    granitePlaced = true;
                    graniteStone.gameObject.SetActive(true);
                    igneousCombineButton.gameObject.SetActive(true);
                }
                else
                {
                    // Either an invalid pair, or a pair that has already been used.
                    invalidCombineButton.gameObject.SetActive(true);
                    Debug.Log("Invalid or already-used combination created");
                }
            }
        }
*/

        public void ShowFinalRock()
        {
            // Reset rock visuals
            slatePlaced = false;
            limeStonePlaced = false;
            granitePlaced = false;

            slate.gameObject.SetActive(false);
            limeStone.gameObject.SetActive(false);
            graniteStone.gameObject.SetActive(false);

            metaCombineButton.gameObject.SetActive(false);
            sedimentaryCombineButton.gameObject.SetActive(false);
            igneousCombineButton.gameObject.SetActive(false);
            invalidCombineButton.gameObject.SetActive(false);

            comboAlreadyUsed = false;  // reset for this evaluation

            // Only evaluate when BOTH boxes are filled
            if (boxOneFilled && boxTwoFilled)
            {
                // Mica + Clay -> Slate (Metamorphic)
                if (micaIsPlaced && clayIsPlaced)
                {
                    if (!metamorphicUsed)
                    {
                        slatePlaced = true;
                        slate.gameObject.SetActive(true);
                        metaCombineButton.gameObject.SetActive(true);
                    }
                    else
                    {
                        comboAlreadyUsed = true;
                        invalidCombineButton.gameObject.SetActive(true);
                    }
                }
                // Calcite + Clay -> Limestone (Sedimentary)
                else if (calciteIsPlaced && clayIsPlaced)
                {
                    if (!sedimentaryUsed)
                    {
                        limeStonePlaced = true;
                        limeStone.gameObject.SetActive(true);
                        sedimentaryCombineButton.gameObject.SetActive(true);
                    }
                    else
                    {
                        comboAlreadyUsed = true;
                        invalidCombineButton.gameObject.SetActive(true);
                    }
                }
                // Feldspar + Quartz -> Granite (Igneous)
                else if (feldsparIsPlaced && quartzIsPlaced)
                {
                    if (!igneousUsed)
                    {
                        granitePlaced = true;
                        graniteStone.gameObject.SetActive(true);
                        igneousCombineButton.gameObject.SetActive(true);
                    }
                    else
                    {
                        comboAlreadyUsed = true;
                        invalidCombineButton.gameObject.SetActive(true);
                    }
                }
                else
                {
                    // Completely invalid combination (never a correct one)
                    comboAlreadyUsed = false;
                    invalidCombineButton.gameObject.SetActive(true);
                    Debug.Log("Invalid combination created");
                }
            }
        }

        /*
        public void AcceptMetaComb()
        {
            amountOfCorrectGuesses += 1;
            textMan.positionChanged = true;
            textMan.arrayPos = 20;
            RemoveClayFromBox1();
            RemoveClayFromBox2();
            RemoveMicaFromBox1();
            RemoveMicaFromBox2();
        }
        */

        public void AcceptMetaComb()
        {
            metamorphicUsed = true;    // mark as used

            amountOfCorrectGuesses += 1;
            textMan.positionChanged = true;
            textMan.arrayPos = 20;

            RemoveClayFromBox1();
            RemoveClayFromBox2();
            RemoveMicaFromBox1();
            RemoveMicaFromBox2();
        }

        /*
        public void AcceptMetaComb()
        {
            // If we've already used this combo, treat as invalid / do nothing special
            if (metamorphicUsed)
            {
                // Optional: show "invalid/already used" text instead of giving credit
                AcceptInvalidComb();
                return;
            }

            metamorphicUsed = true;  // mark as used

            amountOfCorrectGuesses += 1;
            textMan.positionChanged = true;
            textMan.arrayPos = 20;

            RemoveClayFromBox1();
            RemoveClayFromBox2();
            RemoveMicaFromBox1();
            RemoveMicaFromBox2();
        }
        /*
        public void AcceptIgenousComb()
        {
            amountOfCorrectGuesses += 1;
            textMan.positionChanged = true;
            textMan.arrayPos = 16;
            RemoveQuartzFromBox1();
            RemoveQuartzFromBox2();
            RemoveFeldsparFromBox1();
            RemoveFeldsparFromBox2();
        }
       
        public void AcceptIgenousComb()
        {
            if (igneousUsed)
            {
                AcceptInvalidComb();
                return;
            }

            igneousUsed = true;

            amountOfCorrectGuesses += 1;
            textMan.positionChanged = true;
            textMan.arrayPos = 16;

            RemoveQuartzFromBox1();
            RemoveQuartzFromBox2();
            RemoveFeldsparFromBox1();
            RemoveFeldsparFromBox2();
        }
         */

        public void AcceptIgenousComb()
        {
            igneousUsed = true;

            amountOfCorrectGuesses += 1;
            textMan.positionChanged = true;
            textMan.arrayPos = 16;

            RemoveQuartzFromBox1();
            RemoveQuartzFromBox2();
            RemoveFeldsparFromBox1();
            RemoveFeldsparFromBox2();
        }
        /*
        public void AcceptSedimentaryComb()
        {
            amountOfCorrectGuesses += 1;
            textMan.positionChanged = true;
            textMan.arrayPos = 18;
            RemoveClayFromBox1();
            RemoveClayFromBox2();
            RemoveCalciteFromBox1();
            RemoveCalciteFromBox2();
        }
        
        public void AcceptSedimentaryComb()
        {
            if (sedimentaryUsed)
            {
                AcceptInvalidComb();
                return;
            }

            sedimentaryUsed = true;

            amountOfCorrectGuesses += 1;
            textMan.positionChanged = true;
            textMan.arrayPos = 18;

            RemoveClayFromBox1();
            RemoveClayFromBox2();
            RemoveCalciteFromBox1();
            RemoveCalciteFromBox2();
        }
*/

        public void AcceptSedimentaryComb()
        {
            sedimentaryUsed = true;

            amountOfCorrectGuesses += 1;
            textMan.positionChanged = true;
            textMan.arrayPos = 18;

            RemoveClayFromBox1();
            RemoveClayFromBox2();
            RemoveCalciteFromBox1();
            RemoveCalciteFromBox2();
        }
        /*
        public void AcceptInvalidComb()
        {
            textMan.ResetBools();
            textMan.positionChanged = true;
            textMan.arrayPos = 21;

            RemoveClayFromBox1();
            RemoveClayFromBox2();
            RemoveMicaFromBox1();
            RemoveMicaFromBox2();
            RemoveCalciteFromBox1();
            RemoveCalciteFromBox2();
            RemoveQuartzFromBox1();
            RemoveQuartzFromBox2();
            RemoveFeldsparFromBox1();
            RemoveFeldsparFromBox2();
        }
        */

        public void AcceptInvalidComb()
        {
            textMan.ResetBools();
            textMan.positionChanged = true;

            if (comboAlreadyUsed)
            {
                // New "you've already tried this combination" text
                textMan.arrayPos = 41;
            }
            else
            {
                // Original incorrect-combination text
                textMan.arrayPos = 21;
            }

            // Clear boxes and show mineral buttons again
            RemoveClayFromBox1();
            RemoveClayFromBox2();
            RemoveMicaFromBox1();
            RemoveMicaFromBox2();
            RemoveCalciteFromBox1();
            RemoveCalciteFromBox2();
            RemoveQuartzFromBox1();
            RemoveQuartzFromBox2();
            RemoveFeldsparFromBox1();
            RemoveFeldsparFromBox2();
        }
    }
}
