using UnityEngine; 
using UnityEngine.EventSystems;
namespace Alpha.Phases.Geoquest
{

    public class DiagramMeltingSlot : MonoBehaviour, IPointerClickHandler
    {
        public GameObject placedVisual;
        public GameObject heldLabel;
        public DiagramPickupMelting melting;



        public void OnPointerClick(PointerEventData eventData)
        {
            if (melting.isMeltingHeld)
            {
                placedVisual.gameObject.SetActive(true);
                melting.isMeltingHeld = false;
                heldLabel.gameObject.SetActive(false);
            }

        }
    }
}

