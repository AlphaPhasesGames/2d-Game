using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Alpha.Phases.Geoquest
{
    public class Stage2Step2StartTrigger : MonoBehaviour
    {
        public Stage2TextManager textMan;
        public GameObject wayPointArrow;
        public TopDownPlayerController playerCont;
        public bool runOnce;
    private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!runOnce)
            {
                wayPointArrow.gameObject.SetActive(false);
                MainGameManager.Instance.SaveStage2Part2Location();
                playerCont.moveSpeed = 0;
                textMan.positionChanged = true;
                textMan.arrayPos = 24;
                runOnce = true;
            }

        }
    }
}
