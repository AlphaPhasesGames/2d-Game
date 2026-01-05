using UnityEngine; 
using UnityEngine.EventSystems;
namespace Alpha.Phases.Geoquest
{

    public class DiagramMeltingSlot : MonoBehaviour, IPointerClickHandler
    {
        public GameObject placedVisual;
        public GameObject heldLabel;
        public DiagramPickupMelting melting;
        public DiagramManager diagMan;


        public void OnPointerClick(PointerEventData eventData)
        {
            if (melting.isMeltingHeld)
            {
                diagMan.MeltingCorrect();
                placedVisual.gameObject.SetActive(true);
                melting.isMeltingHeld = false;
                heldLabel.gameObject.SetActive(false);
            }

        }
    }
}

