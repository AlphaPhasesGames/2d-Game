using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Alpha.Phases.Geoquest
{
    public class RemoveRock : MonoBehaviour
    {
        public bool inRange;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Hammer"))
            {
                inRange = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Hammer"))
            {
                inRange = false;
            }
        }

        private void Update()
        {
            if (inRange == true)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    RemoveRockFunc();
                }
            }
        }

        public void RemoveRockFunc()
        {
          
            Destroy(this.gameObject);
        }
    }
}
