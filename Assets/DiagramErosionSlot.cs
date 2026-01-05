using UnityEngine;
using UnityEngine.EventSystems;
namespace Alpha.Phases.Geoquest
{

    public class DiagramErosionSlot : MonoBehaviour, IPointerClickHandler
    {
        public GameObject placedVisual;
        public GameObject heldLabel;
        public DiagramPickupErosion weather;
        public DiagramManager diagMan;


        public void OnPointerClick(PointerEventData eventData)
        {
            if (weather.isErosionHeld)
            {
                diagMan.ErosionCorrect();
                placedVisual.gameObject.SetActive(true);
                weather.isErosionHeld = false;
                heldLabel.gameObject.SetActive(false);
            }

        }
    }
}

