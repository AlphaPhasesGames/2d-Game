using UnityEngine;
using UnityEngine.EventSystems;
namespace Alpha.Phases.Geoquest
{

    public class DiagramMetaMorphismSlot : MonoBehaviour, IPointerClickHandler
    {
        public GameObject placedVisual;
        public GameObject heldLabel;
        public DiagramPickupMetaMorphism metamorph;
        public DiagramManager diagMan;


        public void OnPointerClick(PointerEventData eventData)
        {
            if (metamorph.isMetamorphismHeld)
            {
                diagMan.MetamorphismtCorrect();
                placedVisual.gameObject.SetActive(true);
                metamorph.isMetamorphismHeld = false;
                heldLabel.gameObject.SetActive(false);
            }

        }
    }
}

