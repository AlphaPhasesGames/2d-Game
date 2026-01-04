using UnityEngine;
using UnityEngine.EventSystems;
namespace Alpha.Phases.Geoquest
{

    public class DiagramMetaMorphismSlot : MonoBehaviour, IPointerClickHandler
    {
        public GameObject placedVisual;
        public GameObject heldLabel;
        public DiagramPickupMetaMorphism metamorph;



        public void OnPointerClick(PointerEventData eventData)
        {
            if (metamorph.isMetamorphismHeld)
            {
                placedVisual.gameObject.SetActive(true);
                metamorph.isMetamorphismHeld = false;
                heldLabel.gameObject.SetActive(false);
            }

        }
    }
}

