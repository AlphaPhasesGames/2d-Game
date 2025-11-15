using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Alpha.Phases.Geoquest
{
    public class SignManager : MonoBehaviour
    {
        public int amountOfSwitches;
        public Stage1TextManager textMan;
        public Animator moveRock;
        private void Update()
        {
            if(amountOfSwitches >= 2)
            {
                moveRock.SetBool("moveRock", true);
                textMan.positionChanged = true;
                textMan.arrayPos = 43;
            }
        }
    }
}
