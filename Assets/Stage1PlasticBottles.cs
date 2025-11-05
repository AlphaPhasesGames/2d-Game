using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Alpha.Phases.Geoquest
{
    public class Stage1PlasticBottles : MonoBehaviour
    {
        public TopDownPlayerController playerCont;
        public Stage1TextManager textMan;
        public bool isInRange;
        public CircleCollider2D col;
        public bool textPlayed;
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

            if (!textPlayed)
            {
                textMan.positionChanged = true;
                textMan.arrayPos = 11;
              
                textPlayed = true;
            }
        }

       
    }
}