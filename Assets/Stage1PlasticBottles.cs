using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Alpha.Phases.Geoquest
{
    public class Stage1PlasticBottles : MonoBehaviour
    {
        public TopDownPlayerController playerCont;
        public Stage1TextManager textMan;
        public Stage1BottleManager bottleMan;
        public bool isInRange;
       // public CircleCollider2D col;
        public bool textPlayed;
        public AudioSource gemSFX;
        private void Update()
        {
            if (isInRange && Input.GetKeyDown(KeyCode.E))
            {
               
                    PickUpObject();

            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                isInRange = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                isInRange = false;
            }
        }

        public void PickUpObject()
        {
         
            Destroy(this.gameObject);
            bottleMan.amountOfBottles++;
            bottleMan.amountOfGems += 5;
            gemSFX.Play();
            MainGameManager.Instance.collectedGems = bottleMan.amountOfGems += 5;
            MainGameManager.Instance.SaveTaskS1();
            if (!textPlayed)
            {
                textMan.positionChanged = true;
                textMan.arrayPos = 11;
              
                textPlayed = true;
            }
        }

       
    }
}