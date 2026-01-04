using UnityEngine;
using UnityEngine.EventSystems;
namespace Alpha.Phases.Geoquest
{

    public class DiagramCrystalIsationSlot : MonoBehaviour, IPointerClickHandler
    {
        public GameObject placedVisual;
        public GameObject heldLabel;
        public DiagramPickupCrystalisation crystal;



        public void OnPointerClick(PointerEventData eventData)
        {
            if (crystal.isCrystalisationHeld)
            {
                placedVisual.gameObject.SetActive(true);
                crystal.isCrystalisationHeld = false;
                heldLabel.gameObject.SetActive(false);
            }

        }
    }
}


