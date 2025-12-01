using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Alpha.Phases.Geoquest
{
    public class Stage2SwitchMaps : MonoBehaviour
    {
        public GameObject section1;
        public GameObject section2;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                section1.gameObject.SetActive(false);
                section2.gameObject.SetActive(true);
                Debug.Log("LevelsChanges");
            }
        }
    }
}
