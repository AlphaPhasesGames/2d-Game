using UnityEngine;
using UnityEngine.EventSystems;
namespace Alpha.Phases.Geoquest
{

    public class DiagramDepostionSlot : MonoBehaviour, IPointerClickHandler
    {
        public GameObject placedVisual;
        public GameObject heldLabel;
        public DiagramPickupDeposition deposition;
        public DiagramManager diagMan;


        public void OnPointerClick(PointerEventData eventData)
        {
            if (deposition.isDepositionHeld)
            {
                diagMan.DepositionCorrect();
                placedVisual.gameObject.SetActive(true);
                deposition.isDepositionHeld = false;
                heldLabel.gameObject.SetActive(false);
            }

        }
    }
}


