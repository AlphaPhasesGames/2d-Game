using UnityEngine;
using UnityEngine.EventSystems;
namespace Alpha.Phases.Geoquest
{
    public class DiagramSlotWeatheringSlot : MonoBehaviour, IPointerClickHandler
    {
        public GameObject placedVisual;
        public GameObject heldLabel;
        public DiagramPickUpWeathering weather;
        public DiagramManager diagMan;
        private void Awake()
        {

        }


        public void OnPointerClick(PointerEventData eventData)
        {
            if (weather.isWeatherHeld)
            {
                diagMan.WeatheringCorrect();
                placedVisual.gameObject.SetActive(true);
                weather.isWeatherHeld = false;
                heldLabel.gameObject.SetActive(false);
            }

        }
    }
}
