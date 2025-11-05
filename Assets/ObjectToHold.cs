using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alpha.Phases.Geoquest
{
    public class ObjectToHold : MonoBehaviour
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
                if (!playerCont.IsHeld)
                {
                    PickUpObject();
                }
                else if (playerCont.heldObject == this.transform)
                {
                    DropObject();
                }
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
            playerCont.IsHeld = true;
            playerCont.heldObject = this.transform;

            // Optional: parent immediately if using parentToHoldPoint
            if (playerCont.parentToHoldPoint)
            {
                transform.SetParent(playerCont.holdPointDown);
                transform.localPosition = Vector3.zero;
                transform.localRotation = Quaternion.identity;
            }
            if (!textPlayed)
            {
                textMan.positionChanged = true;
                textMan.arrayPos = 12;
                textPlayed = true;
            }
            col.enabled = false;
        }

        public void DropObject()
        {
            playerCont.IsHeld = false;
            playerCont.heldObject = null;

            // Unparent and leave at current position
            transform.SetParent(null);

            // Re-enable collider so it can be picked up again
            col.enabled = true;
        }
    }
}
