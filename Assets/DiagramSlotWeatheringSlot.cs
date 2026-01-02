using UnityEngine;
using UnityEngine.EventSystems;
namespace Alpha.Phases.Geoquest
{
    public class DiagramSlotWeatheringSlot : MonoBehaviour, IPointerClickHandler
    {
        public GameObject placedVisual;
        public GameObject heldLabel;
        public DiagramPickUpWeathering weather;
        private void Awake()
        {

        }


        public void OnPointerClick(PointerEventData eventData)
        {
            if (weather.isWeatherHeld)
            {
                placedVisual.gameObject.SetActive(true);
                weather.isWeatherHeld = false;
                heldLabel.gameObject.SetActive(false);
            }

        }
    }
}
