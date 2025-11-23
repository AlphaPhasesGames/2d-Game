using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Alpha.Phases.Geoquest
{
    public class Stage2CombinationManager : MonoBehaviour
    {

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


        public bool amountOFCorrectAnswers;
        public bool boxOneFilled;
        public bool boxTwoFilled;

        public GameObject slate;
        public bool slatePlaced;


        private void Awake()
        {
            clayButton.onClick.AddListener(PlaceClay);
            clayButtonPlaced1.onClick.AddListener(RemoveClayFromBox1);
            clayButtonPlaced2.onClick.AddListener(RemoveClayFromBox2);

            micaButton.onClick.AddListener(PlaceMica);
            micaButtonPlaced1.onClick.AddListener(RemoveMicaFromBox1);
            micaButtonPlaced2.onClick.AddListener(RemoveMicaFromBox2);
        }

        private void Update()
        {
            if (micaIsPlaced && clayIsPlaced)
            {
                slatePlaced = true;
                slate.gameObject.SetActive(true);

            }

            else
            {
                slatePlaced = false;
                slate.gameObject.SetActive(false);
            }
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
          
        }
        /*
        public void RemoveClay()
        {
            if (clayIsPlaced && boxOneFilled)
            {
                clayButton.gameObject.SetActive(true);
                clayPlaced1.gameObject.SetActive(false);
                clayIsPlaced = false;
                boxOneFilled = false;
            }
            if (clayIsPlaced && boxTwoFilled)
            {
                clayButton.gameObject.SetActive(true);
                clayPlaced2.gameObject.SetActive(false);
                clayIsPlaced = false;
                boxTwoFilled = false;
            }
        }
        */


        public void RemoveClayFromBox1()
        {
            clayPlaced1.gameObject.SetActive(false);
            clayButton.gameObject.SetActive(true);
            boxOneFilled = false;
            clayIsPlaced = false; // still true if clay in box2
        }

        public void RemoveClayFromBox2()
        {
            clayPlaced2.gameObject.SetActive(false);
            clayButton.gameObject.SetActive(true);
            boxTwoFilled = false;
            clayIsPlaced = false; // still true if clay in box1
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

        }


        public void RemoveMicaFromBox1()
        {
            micaPlaced1.gameObject.SetActive(false);
            micaButton.gameObject.SetActive(true);
            boxOneFilled = false;
            micaIsPlaced = false; // still true if clay in box2
        }

        public void RemoveMicaFromBox2()
        {
            micaPlaced2.gameObject.SetActive(false);
            micaButton.gameObject.SetActive(true);
            boxTwoFilled = false;
            micaIsPlaced = false; // still true if clay in box1
        }


        /*
        public void RemoveMica()
        {
            if (micaIsPlaced && boxOneFilled)
            {
                micaButton.gameObject.SetActive(true);
              //  micaPlaced1.gameObject.SetActive(false);
                micaIsPlaced = false;
                boxOneFilled = false;
            }
           if (micaIsPlaced && boxTwoFilled)
            {
                micaButton.gameObject.SetActive(true);
              //  micaPlaced2.gameObject.SetActive(false);
                micaIsPlaced = false;
                boxTwoFilled = false;
            }
        }
        */

        public void ShowFinalRock()
        {
           
        }
    }
}
