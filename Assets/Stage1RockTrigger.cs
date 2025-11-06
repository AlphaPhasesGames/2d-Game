using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Alpha.Phases.Geoquest
{
    public class Stage1RockTrigger : MonoBehaviour
    {
        public Stage1TextManager textMan;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Rock"))
            {
                textMan.positionChanged = true;
                textMan.arrayPos = 13;
                Debug.Log("Rock in trigger");
            }
        }
    }
}
