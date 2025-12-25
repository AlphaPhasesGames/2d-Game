using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Alpha.Phases.Geoquest
{
    public class Stage1ChestManager : MonoBehaviour
    {
        public Sprite closedChest;  // assign in Inspector
        public Sprite openChest;    // assign in Inspector
        private SpriteRenderer sr;
        public Stage1ChessMan chestMan;
        public bool inRange;
        public Stage1BottleManager gemMan;
        public GameObject chestToHide;
        void Start()
        {
            sr = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            if (inRange)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    OpenChest();
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                inRange = true;
            }
           
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                inRange = false;
            }
            
        }

        public void OpenChest()
        {
            chestToHide.gameObject.SetActive(false);
            chestMan.chestCollected++;
            gemMan.amountOfGems += 10;
            sr.sprite = openChest; // changes to the open chest sprite
        }
/*
        public void CloseChest()
        {
            sr.sprite = closedChest; // back to closed sprite if needed
        }
*/
    }
}
