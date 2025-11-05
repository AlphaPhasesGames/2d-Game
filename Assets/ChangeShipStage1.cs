using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alpha.Phases.Geoquest
{
    public class ChangeShipStage1 : MonoBehaviour
    {
        public GameObject backShip;
        public GameObject player;
        public Stage1TextManager s1TextMan;
        public CameraMan camMan;

        public void ShowBackShip()
        {
            
            backShip.gameObject.SetActive(true);
        }

        public void ShowPlayer()
        {
            camMan.MoveToPlayer();
            player.gameObject.SetActive(true);
           // s1TextMan.StartStage1();
        }
    }
}
